using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Properties;
using System.Collections;

namespace WindowsFormsApp1
{
    public partial class SettingsForm : Form
    {
        private string folderLocation;
        private List<KeyValuePair<string, string>> comboValues;
        private List<KeyValuePair<string, string>> sortByValues;
        public SettingsForm()
        {
            InitializeComponent();
            this.Icon = Resources.AppIcon;
            this.folderLocation = Utils.GetSetting("defaultFolder");
            this.comboValues = new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>( "landscape", "Landscape" ),
                                                                        new KeyValuePair<string, string>( "portrait", "Portrait" ),
                                                                        new KeyValuePair<string, string>( "squarish", "Squarish" ) };

            this.sortByValues = new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>( "latest", "Latest" ),
                                                                         new KeyValuePair<string, string>( "oldest", "Oldest" ),
                                                                         new KeyValuePair<string, string>( "popular", "Popular" ) };
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            // Init timer
            decimal value = 0;
            decimal.TryParse(Utils.GetSetting("defaultUpdateInterval"), out value);
            this.updateTimeInterval.Value = value;

            decimal.TryParse(Utils.GetSetting("photoCount"), out value);
            this.photoCount.Value = value;

            decimal.TryParse(Utils.GetSetting("perPageCount"), out value);
            this.photosPerPage.Value = value;


            // Init comboBox
            orientationBox.DataSource = new BindingSource(comboValues, null);
            orientationBox.DisplayMember = "Value";
            orientationBox.ValueMember = "Key";

            var currentOrientation = comboValues.FirstOrDefault(x => x.Key == Utils.GetSetting("orientation"));
            orientationBox.SelectedItem = currentOrientation;

            // Init comboBox
            sortByBox.DataSource = new BindingSource(sortByValues, null);
            sortByBox.DisplayMember = "Value";
            sortByBox.ValueMember = "Key";

            var currentSortBy = sortByValues.FirstOrDefault(x => x.Key == Utils.GetSetting("sortBy"));
            sortByBox.SelectedItem = currentSortBy;
        }
        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chooseFolderBtn_Click(object sender, EventArgs e)
        {
            using (CommonOpenFileDialog dialog = new CommonOpenFileDialog { IsFolderPicker = true })
            {
                dialog.InitialDirectory = folderLocation;

                var result = dialog.ShowDialog();
                if (result == CommonFileDialogResult.Ok)
                {
                    folderLocation = dialog.FileName;
                }
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            Utils.SetSetting("defaultFolder", folderLocation);
            Utils.SetSetting("defaultUpdateInterval", this.updateTimeInterval.Value.ToString());
            Utils.SetSetting("photoCount", this.updateTimeInterval.Value.ToString());
            Utils.SetSetting("perPageCount", this.photosPerPage.Value.ToString());
            Utils.SetSetting("orientation", ((KeyValuePair<string, string>)orientationBox.SelectedItem).Key);
            Utils.SetSetting("sortBy", ((KeyValuePair<string, string>)sortByBox.SelectedItem).Key);
            this.Close();
        }

        private void collectionBtn_Click(object sender, EventArgs e)
        {
            TopicsForm form = TopicsForm.GetInstance();

            form.Show();
        }
    }
}
