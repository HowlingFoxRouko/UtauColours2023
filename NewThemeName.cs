using MyProg;
using System;
using System.Linq;
using System.Windows.Forms;

namespace UTAUColours2023
{
    public partial class NewThemeName : Form
    {
        public string overwriteDialogText = "";
        public string overwriteDialogTitle = "";

        public NewThemeName()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            IniFile userSettings = new IniFile("uc2023_prefs.ini");
            string filePath = System.IO.Path.Combine(Application.StartupPath, "lang", userSettings.Read("ActiveLangueage", "Language") + ".ini");
            IniFile SettingsIni = new IniFile("utaucolours2023.ini");
            string[] themeNames = SettingsIni.GetSectionNames();
            if (themeNames.Any(s => s == ThemeNameTextbox.Text))
            {
                SettingsIni = new IniFile("utaucolours2023.ini");
                IniFile langIni = new IniFile(filePath);
                if (MessageBox.Show(overwriteDialogText, overwriteDialogTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SettingsIni.Write("COLOR_PIANO1", "&HFFFFFF", ThemeNameTextbox.Text);
                    SettingsIni.Write("COLOR_PIANO2", "&H404040", ThemeNameTextbox.Text);
                    SettingsIni.Write("COLOR_ROLL1", "&HFFFFFF", ThemeNameTextbox.Text);
                    SettingsIni.Write("COLOR_ROLL2", "&HE0E0E0", ThemeNameTextbox.Text);
                    SettingsIni.Write("COLOR_SEPA1", "&HFF40FF", ThemeNameTextbox.Text);
                    SettingsIni.Write("COLOR_SEPA2", "&HFF8080", ThemeNameTextbox.Text);
                    SettingsIni.Write("COLOR_BACK", "&HFFFFFF", ThemeNameTextbox.Text);
                    SettingsIni.Write("COLOR_FORE", "&H000000", ThemeNameTextbox.Text);
                    SettingsIni.Write("COLOR_SHADOW", "&H808080", ThemeNameTextbox.Text);
                    SettingsIni.Write("COLOR_NOTE_NOR", "&HFFC000", ThemeNameTextbox.Text);
                    SettingsIni.Write("COLOR_NOTE_TOP", "&HFF80FF", ThemeNameTextbox.Text);
                    SettingsIni.Write("COLOR_NOTE_SEL", "&HFF40FF", ThemeNameTextbox.Text);
                    SettingsIni.Write("COLOR_NOTE_TNOR", "&H000000", ThemeNameTextbox.Text);
                    SettingsIni.Write("COLOR_NOTE_TTOP", "&H800000", ThemeNameTextbox.Text);
                    SettingsIni.Write("COLOR_NOTE_TSEL", "&H800000", ThemeNameTextbox.Text);
                    SettingsIni.Write("COLOR_NOTE_RNOR", "&HFFFFFF", ThemeNameTextbox.Text);
                    SettingsIni.Write("COLOR_NOTE_RTOP", "&HC0C0C0", ThemeNameTextbox.Text);
                    SettingsIni.Write("COLOR_NOTE_RSEL", "&H808080", ThemeNameTextbox.Text);
                    SettingsIni.Write("COLOR_PTCH_SEL", "&H0000FF", ThemeNameTextbox.Text);
                    SettingsIni.Write("COLOR_PTCH_NOR", "&HFF0000", ThemeNameTextbox.Text);
                    SettingsIni.Write("COLOR_TEMPO_NOR", "&H0000FF", ThemeNameTextbox.Text);
                    SettingsIni.Write("COLOR_TEMPO_ALL", "&HFF0000", ThemeNameTextbox.Text);
                    SettingsIni.Write("TransformTitle", "", ThemeNameTextbox.Text);
                }
            }
            SettingsIni.Write("COLOR_PIANO1", "&HFFFFFF", ThemeNameTextbox.Text);
            SettingsIni.Write("COLOR_PIANO2", "&H404040", ThemeNameTextbox.Text);
            SettingsIni.Write("COLOR_ROLL1", "&HFFFFFF", ThemeNameTextbox.Text);
            SettingsIni.Write("COLOR_ROLL2", "&HE0E0E0", ThemeNameTextbox.Text);
            SettingsIni.Write("COLOR_SEPA1", "&HFF40FF", ThemeNameTextbox.Text);
            SettingsIni.Write("COLOR_SEPA2", "&HFF8080", ThemeNameTextbox.Text);
            SettingsIni.Write("COLOR_BACK", "&HFFFFFF", ThemeNameTextbox.Text);
            SettingsIni.Write("COLOR_FORE", "&H000000", ThemeNameTextbox.Text);
            SettingsIni.Write("COLOR_SHADOW", "&H808080", ThemeNameTextbox.Text);
            SettingsIni.Write("COLOR_NOTE_NOR", "&HFFC000", ThemeNameTextbox.Text);
            SettingsIni.Write("COLOR_NOTE_TOP", "&HFF80FF", ThemeNameTextbox.Text);
            SettingsIni.Write("COLOR_NOTE_SEL", "&HFF40FF", ThemeNameTextbox.Text);
            SettingsIni.Write("COLOR_NOTE_TNOR", "&H000000", ThemeNameTextbox.Text);
            SettingsIni.Write("COLOR_NOTE_TTOP", "&H800000", ThemeNameTextbox.Text);
            SettingsIni.Write("COLOR_NOTE_TSEL", "&H800000", ThemeNameTextbox.Text);
            SettingsIni.Write("COLOR_NOTE_RNOR", "&HFFFFFF", ThemeNameTextbox.Text);
            SettingsIni.Write("COLOR_NOTE_RTOP", "&HC0C0C0", ThemeNameTextbox.Text);
            SettingsIni.Write("COLOR_NOTE_RSEL", "&H808080", ThemeNameTextbox.Text);
            SettingsIni.Write("COLOR_PTCH_SEL", "&H0000FF", ThemeNameTextbox.Text);
            SettingsIni.Write("COLOR_PTCH_NOR", "&HFF0000", ThemeNameTextbox.Text);
            SettingsIni.Write("COLOR_TEMPO_NOR", "&H0000FF", ThemeNameTextbox.Text);
            SettingsIni.Write("COLOR_TEMPO_ALL", "&HFF0000", ThemeNameTextbox.Text);
            SettingsIni.Write("TransformTitle", "", ThemeNameTextbox.Text);
            this.Close();
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            IniFile SettingsIni = new IniFile("uc2023_pref.ini");
            string filePath = System.IO.Path.Combine(Application.StartupPath, "lang", SettingsIni.Read("ActiveLanguage", "Language") + ".ini");
            IniFile langINI = new IniFile(filePath);
            overwriteDialogText = langINI.Read("overwriteThemeNameDialogText", "Dialog");
            overwriteDialogTitle = langINI.Read("overwriteThemeNameDialogTitle", "Dialog");
            foreach (Control c in this.Controls)
            {
                if (langINI.KeyExists(c.Name, this.Name))
                {
                    c.Text = langINI.Read(c.Name, this.Name);
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
