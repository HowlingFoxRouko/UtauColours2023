using MyProg;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace UTAUColours2023
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/HowlingFoxRouko/UtauColours2023");
        }

        private void About_Load(object sender, EventArgs e)
        {
            IniFile SettingsIni = new IniFile("uc2023_pref.ini");
            string filePath = System.IO.Path.Combine(Application.StartupPath, "lang", SettingsIni.Read("ActiveLanguage", "Language") + ".ini");
            IniFile langINI = new IniFile(filePath);
            foreach (Control c in this.Controls)
            {
                if (langINI.KeyExists(c.Name, this.Name))
                {
                    c.Text = langINI.Read(c.Name, this.Name);
                    c.Text = c.Text.Replace("%n", Environment.NewLine);
                    c.Refresh();
                }
            }
            if (langINI.KeyExists(this.Name, this.Name))
            {
                this.Text = langINI.Read(this.Name, this.Name);
            }
        }

    }
}
