using NiGardenScore.Score;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace NiGardenScore
{
    internal partial class MainForm : Form
    {
        internal MainForm()
        {
            InitializeComponent();
        }

        private void addFileButton_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Multiselect = true
            };

            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            fileListView.Items.Clear();

            foreach (var file in  openFileDialog.FileNames)
            {
                string fileName = Path.GetFileNameWithoutExtension(file);
                var item = new ListViewItem(fileName);
                item.SubItems.Add(file);

                fileListView.Items.Add(item);
            }
        }

        private void btnGenerateTable_Click(object sender, EventArgs e)
        {
            var surveyResults = getSurveyResults();
            var ratingScheme = getRatingScheme();

            var tableGenerator = new TableGenerator();
            tableGenerator.GenerateTable(surveyResults.ToList(), ratingScheme);

            Dictionary<string, (int, bool)> getRatingScheme()
            {
                var rs = new Dictionary<string, (int, bool)>();
                for (int i = 0; i < ratingSchemeDataGridView.Rows.Count - 1; i++)
                {
                    string text = (string)ratingSchemeDataGridView.Rows[i].Cells[0].Value;
                    int score = int.Parse((string)ratingSchemeDataGridView.Rows[i].Cells[1].Value);
                    bool rated = ratingSchemeDataGridView.Rows[i].Cells[2].Value is null ? false : true;

                    rs.Add(text, (score, rated));
                }

                return rs;
            }

            IEnumerable<SurveyResult> getSurveyResults()
            {
                foreach (ListViewItem item in fileListView.Items)
                {
                    string path = item.SubItems[1].Text;
                    yield return new SurveyResult(path);
                }
            }
        }
    }
}
