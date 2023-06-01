using NiGardenScore.Score;
using OfficeOpenXml;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace NiGardenScore
{
    internal class TableGenerator
    {
        private string path;
        private ExcelPackage _package;

        internal TableGenerator() 
        {
            path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Result {DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss")}.xlsx");
            _package = new ExcelPackage();
        }

        internal void GenerateTable(IList<SurveyResult> surveyResults, Dictionary<string, (int, bool)> ratingScheme)
        {
            var summaryWorksheet = _package.Workbook.Worksheets.Add("Zusammenfassung");
            var ratingCellMap = new Dictionary<string, int>();

            summaryWorksheet.Cells[1, 1].Value = "Name";
            summaryWorksheet.Cells[1, 2].Value = "Punktezahl";

            for (int i = 0; i < surveyResults.Count; i++)
            {
                var surveyResult = surveyResults[i];

                if (_package.Workbook.Worksheets.Any(w =>
                    w.Name == surveyResult.Name.Truncate(31)))
                {
                    MessageBox.Show($"Die ersten 31 Zeichen dieser Schaugartendatei sind nicht eindeutig: [{surveyResult.Name}]." +
                        $"Dieser Schaugarten wird vorerst übersprungen.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }


                var scoreWorksheet = _package.Workbook.Worksheets.Add(surveyResult.Name);

                double totalScore = 0;

                // You can also turn this into an object (Header?), and create this dynamically
                scoreWorksheet.Cells[1, 1].Value = "Name";
                scoreWorksheet.Cells[1, 2].Value = "Anzahl";
                scoreWorksheet.Cells[1, 3].Value = "Fragen";

                var ratingKeys = ratingScheme.Keys.ToList();
                for (int j = 0; j < ratingScheme.Count; j++)
                {
                    var ratingKey = ratingKeys[j];
                    scoreWorksheet.Cells[2, 4 + j].Value = ratingKey;

                    if (ratingCellMap.ContainsKey(ratingKey))
                        continue;

                    ratingCellMap.Add(ratingKey, 4 + j);
                }

                int gap = ratingScheme.Values.Count;
                scoreWorksheet.Cells[1, 4 + gap].Value = "Punktezahl";

                scoreWorksheet.Cells[1, 3, 1, 3 + gap].Merge = true;

                scoreWorksheet.Cells[2, 3].Value = "Text";

                var ratings = surveyResult.Ratings.ToList();
                for (int j = 0; j < ratings.Count; j++)
                {
                    var rating = ratings[j];
                    scoreWorksheet.Cells[3 + j, 3].Value = rating.Question;

                    foreach (var score in rating.Scores)
                    {
                        if (!ratingScheme.TryGetValue(score.Key, out (int Multiplier, bool Rated) ratingModifier))
                        {
                            MessageBox.Show($"Antwortmöglichkeit [{score.Key}] hat keine zugehörige Punktezahl. Anwendung wird geschlossen.",
                                "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Process.GetCurrentProcess().Kill();
                        }

                        int multiplier = ratingModifier.Multiplier;
                        double multipliedScore = score.Value * multiplier;
                        scoreWorksheet.Cells[3 + j, ratingCellMap[score.Key]].Value = multipliedScore;

                        if (ratingModifier.Rated)
                        {
                            totalScore += multipliedScore;
                        }
                    }
                }

                double finalScore = Math.Round(totalScore / surveyResult.ResponseAmount, 2);
                scoreWorksheet.Cells[2, 4 + gap].Value = finalScore;

                summaryWorksheet.Cells[2 + i, 1].Value = surveyResult.Name;
                summaryWorksheet.Cells[2 + i, 2].Value = finalScore;
            }

            File.WriteAllBytes(path, _package.GetAsByteArray());

            MessageBox.Show($"Datei wurde im Pfad [{path}] abgespeichert.", "Fertig", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
