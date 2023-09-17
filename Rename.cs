using MyProg;
using System;
using System.Windows.Forms;

namespace UTAUColours2023
{
    public partial class Rename : Form
    {
        public string newname;
        public Rename()
        {
            InitializeComponent();

        }

        private void RenameButton_Click(object sender, EventArgs e)
        {
            newname = RenameTextBox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Rename_Load(object sender, EventArgs e)
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

        private void renCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
