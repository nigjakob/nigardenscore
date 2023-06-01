using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiGardenScore.Score
{
    internal class SurveyResultFileScheme
    {
        internal string Name { get; }

        internal int StartingRow { get; }

        internal int StartingColumn { get; }

        internal int Step { get; }

        internal SurveyResultFileScheme(string name, int startingRow, int startingColumn, int step)
        {
            Name = name;
            StartingRow = startingRow;
            StartingColumn = startingColumn;
            Step = step;
        }

        internal SurveyResultFileScheme()
        {
            Name = "Kumulierte Ergebnisse";
            StartingRow = 8;
            StartingColumn = 3;
            Step = 9;
        }

    }
}
