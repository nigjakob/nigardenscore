using System.Collections.Generic;

namespace NiGardenScore.Score
{
    internal class Rating
    {
        internal string Question { get; }
        internal Dictionary<string, uint> Scores { get; }

        internal Rating(string question, Dictionary<string, uint> scores)
        {
            Question = question;
            Scores = scores;
        }
    }
}
