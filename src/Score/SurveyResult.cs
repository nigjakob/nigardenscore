using OfficeOpenXml;

using System.Collections.Generic;
using System.IO;

namespace NiGardenScore.Score
{
    internal class SurveyResult
    {
        private ExcelPackage _package;
        
        internal string Name { get; }

        private uint? responseAmount = null;
        internal uint ResponseAmount {
            get
            {
                if (responseAmount is null)
                    return 0;

                return responseAmount.Value;
            }
            private set
            {
                if (responseAmount is null)
                    responseAmount = value;
            }
        }

        internal IEnumerable<Rating> Ratings
            => ExtractResults();

        internal SurveyResult(string path)
        {
            Name = Path.GetFileNameWithoutExtension(path);

            _package = new ExcelPackage(path);
            _package.Workbook.CalcMode = ExcelCalcMode.Automatic;
        }

        internal IEnumerable<Rating> ExtractResults()
        {
            // TODO: Allow editing of the file scheme via GUI.
            var surveyResultFileScheme = new SurveyResultFileScheme();
            var worksheet = _package.Workbook.Worksheets[surveyResultFileScheme.Name];

            bool done = false;
            uint totalAmount = 0;
            for (int row = surveyResultFileScheme.StartingRow; ; row += surveyResultFileScheme.Step)
            {
                string question = (string)worksheet.Cells[row - 4, 2].Value;
                var ratings = new Dictionary<string, uint>();

                for (int column = surveyResultFileScheme.StartingColumn; ; column++)
                {
                    string ratingName = (string)worksheet.Cells[row, column].Value;

                    if (string.IsNullOrEmpty(ratingName))
                    {
                        if (column == surveyResultFileScheme.StartingColumn)
                        {
                            done = true;
                        }

                        ResponseAmount = totalAmount;

                        break;
                    }

                    double amount = (double)worksheet.Cells[row + 1, column].Value;
                    totalAmount += (uint)amount;
                    ratings.Add(ratingName, (uint)amount);
                }

                if (done)
                    break;

               yield return new Rating(question, ratings);
            }
        }
    }
}
