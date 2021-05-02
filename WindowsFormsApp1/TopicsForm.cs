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

namespace WindowsFormsApp1
{
    public partial class TopicsForm : Form
    {
        private UnsplashAPI api;
        private static TopicsForm form;
        private TopicsForm()
        {
            InitializeComponent();
            this.Icon = Resources.AppIcon;
            this.api = UnsplashAPI.GetInstance();

            List<string> topicsSelected = Utils.GetSetting("topicsSelected").Split(',').ToList();

            topicsBox.CheckOnClick = true;
            topicsBox.BeginUpdate();

            foreach (var topic in api.GetTopicsList())
            {
                var selected = topicsSelected.FirstOrDefault(x => x == topic.title);

                if (selected != null)
                {
                    topicsBox.Items.Add(topic.title, CheckState.Checked);
                }
                else
                {
                    topicsBox.Items.Add(topic.title);
                }                
            }

            topicsBox.EndUpdate();
        }

        public static TopicsForm GetInstance()
        {
            if (form == null)
            {
                form = new TopicsForm();
            }

            return form;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            string saveSelectedItems = string.Empty;

            foreach (var item in topicsBox.CheckedItems)
            {
                saveSelectedItems = saveSelectedItems == string.Empty ? item.ToString() : saveSelectedItems + "," + item.ToString();
            }

            Utils.SetSetting("topicsSelected", saveSelectedItems);

            this.Hide();
        }
    }
}
