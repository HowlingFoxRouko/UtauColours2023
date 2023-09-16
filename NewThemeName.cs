using MyProg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UTAUColours2023
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            IniFile SettingsIni = new IniFile("utaucolours2023.ini");
            string[] themeNames = SettingsIni.GetSectionNames();
            Form1 form1 = new Form1();
            string WhiteKeyTextBox = form1.Controls[1].Text;
            string BlackKeyTextBox = form1.Controls[3].Text;
            string PianoRollKeyWhiteTextBox = form1.Controls[5].Text;
            string PianoRollKeyBlackTextBox = form1.Controls[7].Text;
            string MeasureLineTextBox = form1.Controls[9].Text;
            string QuarterNoteLineTextBox = form1.Controls[11].Text;
            string TempoInitialTextBox = form1.Controls[13].Text;
            string MeasureBackgroundTextBox = form1.Controls[15].Text;
            string MeasureToneTextTextBox = form1.Controls[17].Text;
            string PianoRollNoteDividerTextBox = form1.Controls[19].Text;
            string NoteDeselectedTextBox = form1.Controls[21].Text;
            string NoteFirstSelectedTextBox = form1.Controls[23].Text;
            string NoteSelectedTextBox = form1.Controls[25].Text;
            string PitchDeselectedTextBox = form1.Controls[27].Text;
            string NoteFontDeselectedTextBox = form1.Controls[29].Text;
            string NoteFontFirstSelectedTextBox = form1.Controls[31].Text;
            string NoteFontSelectedTextBox = form1.Controls[33].Text;
            string RestDeselectedTextBox = form1.Controls[35].Text;
            string RestFirstSelectedTextBox = form1.Controls[37].Text;
            string RestSelectedTextBox = form1.Controls[39].Text;
            string PitchSelectedTextBox = form1.Controls[41].Text;
            string TempoChangeTextBox = form1.Controls[43].Text;
            string TitlebarTextTextBox = form1.Controls[45].Text;

            if (themeNames.Any(s => s == ThemeNameTextbox.Text))
            {
                SettingsIni = new IniFile("utaucolours2023.ini");
                if (MessageBox.Show("This theme already exists. Overwrite?","Overwrite?", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
    }
}
