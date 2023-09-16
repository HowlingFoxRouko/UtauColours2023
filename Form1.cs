using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyProg;
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography;

namespace UTAUColours2023
{
    public partial class Form1 : Form
    {
        public Image preview;
        public bool TextWasChanged = false;
        int previousThemeIndex = -1; // Variable to track SelectedIndex of theme Listbox
        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TextWasChanged)
            {
                saveChanges(null,null);
            }
            this.Close();
        }

        private void openSavedThemesListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        // A function that takes a graphics object and draws a rectangle with text and border on it
        private void drawPreview(Graphics g)
        {
            // Create a pen with the desired color and width for the border using the Color.FromArgb and Pen constructors
            Pen borderPen = new Pen(Color.FromArgb(0, 0, 255), 1);
            // Create a pen with the desired color for the rectangle using the Color.FromArgb constructor
            Pen WhiteKeyPen = new Pen(Color.FromArgb(hexToRgb(WhiteKeyTextBox.Text)[0], hexToRgb(WhiteKeyTextBox.Text)[1], hexToRgb(WhiteKeyTextBox.Text)[2]));
            Pen BlackKeyPen = new Pen(Color.FromArgb(hexToRgb(BlackKeyTextBox.Text)[0], hexToRgb(BlackKeyTextBox.Text)[1], hexToRgb(BlackKeyTextBox.Text)[2]));
            Pen PianoRollKeyWhitePen = new Pen(Color.FromArgb(hexToRgb(PianoRollKeyWhiteTextBox.Text)[0], hexToRgb(PianoRollKeyWhiteTextBox.Text)[1], hexToRgb(PianoRollKeyWhiteTextBox.Text)[2]));
            Pen PianoRollKeyBlackPen = new Pen(Color.FromArgb(hexToRgb(PianoRollKeyBlackTextBox.Text)[0], hexToRgb(PianoRollKeyBlackTextBox.Text)[1], hexToRgb(PianoRollKeyBlackTextBox.Text)[2]));
            Pen MeasureLinePen = new Pen(Color.FromArgb(hexToRgb(MeasureLineTextBox.Text)[0], hexToRgb(MeasureLineTextBox.Text)[1], hexToRgb(MeasureLineTextBox.Text)[2]));
            Pen QuarterNoteLinePen = new Pen(Color.FromArgb(hexToRgb(QuarterNoteLineTextBox.Text)[0], hexToRgb(QuarterNoteLineTextBox.Text)[1], hexToRgb(QuarterNoteLineTextBox.Text)[2]));
            Pen TempoInitialTextPen = new Pen(Color.FromArgb(hexToRgb(TempoInitialTextBox.Text)[0], hexToRgb(TempoInitialTextBox.Text)[1], hexToRgb(TempoInitialTextBox.Text)[2]));
            Pen TempoChangeTextPen = new Pen(Color.FromArgb(hexToRgb(TempoChangeTextBox.Text)[0], hexToRgb(TempoChangeTextBox.Text)[1], hexToRgb(TempoChangeTextBox.Text)[2]));
            Pen MeasureBackgroundPen = new Pen(Color.FromArgb(hexToRgb(MeasureBackgroundTextBox.Text)[0], hexToRgb(MeasureBackgroundTextBox.Text)[1], hexToRgb(MeasureBackgroundTextBox.Text)[2]));
            Pen PianoRollNoteDividerLinePen = new Pen(Color.FromArgb(hexToRgb(PianoRollNoteDividerTextBox.Text)[0], hexToRgb(PianoRollNoteDividerTextBox.Text)[1], hexToRgb(PianoRollNoteDividerTextBox.Text)[2]));
            Pen MeasureToneTextPen = new Pen(Color.FromArgb(hexToRgb(MeasureOctaveTextTextBox.Text)[0], hexToRgb(MeasureOctaveTextTextBox.Text)[1], hexToRgb(MeasureOctaveTextTextBox.Text)[2]));
            Font MeasureTextFont = new Font("ＭＳ Ｐゴシック", 9);
            Font NoteTextFont = new Font("ＭＳ Ｐゴシック", 9);
            Pen NoteDeselectedPen = new Pen(Color.FromArgb(hexToRgb(NoteDeselectedTextBox.Text)[0], hexToRgb(NoteDeselectedTextBox.Text)[1], hexToRgb(NoteDeselectedTextBox.Text)[2]));
            Pen NoteFirstSelectedPen = new Pen(Color.FromArgb(hexToRgb(NoteFirstSelectedTextBox.Text)[0], hexToRgb(NoteFirstSelectedTextBox.Text)[1], hexToRgb(NoteFirstSelectedTextBox.Text)[2]));
            Pen NoteSelectedPen = new Pen(Color.FromArgb(hexToRgb(NoteSelectedTextBox.Text)[0], hexToRgb(NoteSelectedTextBox.Text)[1], hexToRgb(NoteSelectedTextBox.Text)[2]));
            Pen NoteFontDeselectedPen = new Pen(Color.FromArgb(hexToRgb(NoteFontDeselectedTextBox.Text)[0], hexToRgb(NoteFontDeselectedTextBox.Text)[1], hexToRgb(NoteFontDeselectedTextBox.Text)[2]));
            Pen NoteFontFirstSelectedPen = new Pen(Color.FromArgb(hexToRgb(NoteFontFirstSelectedTextBox.Text)[0], hexToRgb(NoteFontFirstSelectedTextBox.Text)[1], hexToRgb(NoteFontFirstSelectedTextBox.Text)[2]));
            Pen NoteFontSelectedPen = new Pen(Color.FromArgb(hexToRgb(NoteFontSelectedTextBox.Text)[0], hexToRgb(NoteFontSelectedTextBox.Text)[1], hexToRgb(NoteFontSelectedTextBox.Text)[2]));
            Pen RestDeselectedPen = new Pen(Color.FromArgb(hexToRgb(RestDeselectedTextBox.Text)[0], hexToRgb(RestDeselectedTextBox.Text)[1], hexToRgb(RestDeselectedTextBox.Text)[2]));
            Pen RestFirstSelectedPen = new Pen(Color.FromArgb(hexToRgb(RestFirstSelectedTextBox.Text)[0], hexToRgb(RestFirstSelectedTextBox.Text)[1], hexToRgb(RestFirstSelectedTextBox.Text)[2]));
            Pen RestSelectedPen = new Pen(Color.FromArgb(hexToRgb(RestSelectedTextBox.Text)[0], hexToRgb(RestSelectedTextBox.Text)[1], hexToRgb(RestSelectedTextBox.Text)[2]));
            Pen PitchLineDeselectedPen = new Pen(Color.FromArgb(hexToRgb(PitchLineDeselectedTextBox.Text)[0], hexToRgb(PitchLineDeselectedTextBox.Text)[1], hexToRgb(PitchLineDeselectedTextBox.Text)[2]));
            Pen PitchLineSelectedPen = new Pen(Color.FromArgb(hexToRgb(PitchLineSelectedTextBox.Text)[0], hexToRgb(PitchLineSelectedTextBox.Text)[1], hexToRgb(PitchLineSelectedTextBox.Text)[2]));
            //Draw black key background and Measure area background:
            g.FillRectangle(MeasureBackgroundPen.Brush, 0, 0, 489, 28);
            g.FillRectangle(BlackKeyPen.Brush, 0, 29, 104, 212);
//          g.DrawRectangle(borderPen, 10, 15, 300, 28);
            //White Keys:
            g.FillRectangle(WhiteKeyPen.Brush, 0, 29, 61, 13);
            g.FillRectangle(WhiteKeyPen.Brush, 0, 57, 61, 13);
            g.FillRectangle(WhiteKeyPen.Brush, 0, 85, 61, 13);
            g.FillRectangle(WhiteKeyPen.Brush, 0, 113, 61, 13);
            g.FillRectangle(WhiteKeyPen.Brush, 0, 127, 61, 13);
            g.FillRectangle(WhiteKeyPen.Brush, 0, 155, 61, 13);
            g.FillRectangle(WhiteKeyPen.Brush, 0, 183, 61, 13);
            g.FillRectangle(WhiteKeyPen.Brush, 0, 197, 61, 13);
            g.FillRectangle(WhiteKeyPen.Brush, 0, 225, 61, 13);
            g.FillRectangle(WhiteKeyPen.Brush, 61, 29, 43, 19);
            g.FillRectangle(WhiteKeyPen.Brush, 61, 49, 43, 27);
            g.FillRectangle(WhiteKeyPen.Brush, 61, 77, 43, 27);
            g.FillRectangle(WhiteKeyPen.Brush, 61, 105, 43, 21);
            g.FillRectangle(WhiteKeyPen.Brush, 61, 127, 43, 19);
            g.FillRectangle(WhiteKeyPen.Brush, 61, 147, 43, 27);
            g.FillRectangle(WhiteKeyPen.Brush, 61, 175, 43, 21);
            g.FillRectangle(WhiteKeyPen.Brush, 61, 197, 43, 19);
            g.FillRectangle(WhiteKeyPen.Brush, 61, 217, 43, 27);
            //Tone Text:
            g.DrawString("C4", MeasureTextFont, MeasureToneTextPen.Brush, 70, 181);
            //Piano Roll:
            g.FillRectangle(PianoRollKeyWhitePen.Brush, 104, 28, 385, 213);
            g.FillRectangle(PianoRollKeyBlackPen.Brush, 104, 42, 385, 15);
            g.FillRectangle(PianoRollKeyBlackPen.Brush, 104, 70, 385, 15);
            g.FillRectangle(PianoRollKeyBlackPen.Brush, 104, 99, 385, 15);
            g.FillRectangle(PianoRollKeyBlackPen.Brush, 104, 140, 385, 15);
            g.FillRectangle(PianoRollKeyBlackPen.Brush, 104, 168, 385, 15);
            g.FillRectangle(PianoRollKeyBlackPen.Brush, 104, 210, 385, 15);
            g.FillRectangle(PianoRollKeyBlackPen.Brush, 104, 238, 385, 3);
            g.DrawLine(PianoRollNoteDividerLinePen, 104, 42, 489, 42);
            g.DrawLine(PianoRollNoteDividerLinePen, 104, 56, 489, 56);
            g.DrawLine(PianoRollNoteDividerLinePen, 104, 70, 489, 70);
            g.DrawLine(PianoRollNoteDividerLinePen, 104, 84, 489, 84);
            g.DrawLine(PianoRollNoteDividerLinePen, 104, 98, 489, 98);
            g.DrawLine(PianoRollNoteDividerLinePen, 104, 113, 489, 113);
            g.DrawLine(PianoRollNoteDividerLinePen, 104, 126, 489, 126);
            g.DrawLine(PianoRollNoteDividerLinePen, 104, 140, 489, 140);
            g.DrawLine(PianoRollNoteDividerLinePen, 104, 154, 489, 154);
            g.DrawLine(PianoRollNoteDividerLinePen, 104, 168, 489, 168);
            g.DrawLine(PianoRollNoteDividerLinePen, 104, 182, 489, 182);
            g.DrawLine(PianoRollNoteDividerLinePen, 104, 196, 489, 196);
            g.DrawLine(PianoRollNoteDividerLinePen, 104, 210, 489, 210);
            g.DrawLine(PianoRollNoteDividerLinePen, 104, 224, 489, 224);
            g.DrawLine(PianoRollNoteDividerLinePen, 104, 238, 489, 238);
            //Measure Divider and Text:
            g.DrawString("0", MeasureTextFont, MeasureToneTextPen.Brush, 102, 3);
            g.DrawString("1", MeasureTextFont, MeasureToneTextPen.Brush, 274, 3);
            g.DrawString("2", MeasureTextFont, MeasureToneTextPen.Brush, 444, 3);
            g.DrawString("120.00", MeasureTextFont, TempoInitialTextPen.Brush, 102, 14);
            g.DrawString("150.00", MeasureTextFont, TempoChangeTextPen.Brush, 278, 14);
            g.DrawLine(MeasureToneTextPen, 0, 28, 489, 28);
            g.DrawLine(MeasureLinePen, 104, 28, 104, 241);
            g.DrawLine(MeasureLinePen, 275, 28, 275, 241);
            g.DrawLine(MeasureLinePen, 445, 28, 445, 241);
            g.DrawLine(QuarterNoteLinePen, 147, 28, 147, 241);
            g.DrawLine(QuarterNoteLinePen, 189, 28, 189, 241);
            g.DrawLine(QuarterNoteLinePen, 232, 28, 232, 241);
            g.DrawLine(QuarterNoteLinePen, 317, 28, 317, 241);
            g.DrawLine(QuarterNoteLinePen, 360, 28, 360, 241);
            g.DrawLine(QuarterNoteLinePen, 403, 28, 403, 241);
            g.DrawLine(QuarterNoteLinePen, 488, 28, 488, 241);
            //Notes:
            //Check if the checkbox to show the pitchbends is selected:
            if (PitchLinesCheckBox.Checked)
            {
                //Draw Notes with pitchbends:

            }
            else
            {
                g.FillRectangle(NoteDeselectedPen.Brush, 104, 182, 43, 14);
                g.DrawRectangle(NoteFontDeselectedPen, 104, 182, 43, 14);
                g.DrawString("ど", MeasureTextFont, NoteFontDeselectedPen.Brush, 103, 183);
                g.FillRectangle(NoteDeselectedPen.Brush, 147, 154, 42, 14);
                g.DrawRectangle(NoteFontDeselectedPen, 147, 154, 42, 14);
                g.DrawString("れ", MeasureTextFont, NoteFontDeselectedPen.Brush, 146, 155);
                g.FillRectangle(NoteDeselectedPen.Brush, 189, 126, 43, 14);
                g.DrawRectangle(NoteFontDeselectedPen, 189, 126, 43, 14);
                g.DrawString("み", MeasureTextFont, NoteFontDeselectedPen.Brush, 188, 127);
                g.FillRectangle(RestDeselectedPen.Brush, 232, 182, 43, 14);
                g.DrawRectangle(NoteFontDeselectedPen, 232, 182, 43, 14);
                g.DrawString("R", MeasureTextFont, NoteFontDeselectedPen.Brush, 231, 183);
                g.FillRectangle(NoteFirstSelectedPen.Brush, 275, 113, 42, 13);
                g.DrawRectangle(NoteFontFirstSelectedPen, 275, 113, 42, 13);
                g.DrawString("ふぁ", MeasureTextFont, NoteFontFirstSelectedPen.Brush, 274, 114);
                g.FillRectangle(NoteSelectedPen.Brush, 317, 84, 43, 14);
                g.DrawRectangle(NoteFontSelectedPen, 317, 84, 43, 14);
                g.DrawString("そ", MeasureTextFont, NoteFontSelectedPen.Brush, 316, 85);
                g.FillRectangle(NoteSelectedPen.Brush, 360, 56, 43, 14);
                g.DrawRectangle(NoteFontSelectedPen, 360, 56, 43, 14);
                g.DrawString("ら", MeasureTextFont, NoteFontSelectedPen.Brush, 359, 57);
                g.FillRectangle(RestFirstSelectedPen.Brush, 360, 196, 43, 14);
                g.DrawRectangle(NoteFontFirstSelectedPen, 360, 196, 43, 14);
                g.DrawString("R", MeasureTextFont, NoteFontFirstSelectedPen.Brush, 359, 197);
                g.FillRectangle(RestSelectedPen.Brush, 403, 182, 42, 14);
                g.DrawRectangle(NoteFontSelectedPen, 403, 182, 42, 14);
                g.DrawString("R", MeasureTextFont, NoteFontSelectedPen.Brush, 402, 183);
            }
            borderPen.Dispose();
            BlackKeyPen.Dispose();
            MeasureTextFont.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IniFile SettingsIni;
            if (!File.Exists("utaucolours2023.ini")) {
                SettingsIni = new IniFile("utaucolours2023.ini");
                SettingsIni.Write("COLOR_PIANO1", "&HFFFFFF", "標準配色");
                SettingsIni.Write("COLOR_PIANO2", "&H404040", "標準配色");
                SettingsIni.Write("COLOR_ROLL1", "&HFFFFFF", "標準配色");
                SettingsIni.Write("COLOR_ROLL2", "&HE0E0E0", "標準配色");
                SettingsIni.Write("COLOR_SEPA1", "&HFF40FF", "標準配色");
                SettingsIni.Write("COLOR_SEPA2", "&HFF8080", "標準配色");
                SettingsIni.Write("COLOR_BACK", "&HFFFFFF", "標準配色");
                SettingsIni.Write("COLOR_FORE", "&H000000", "標準配色");
                SettingsIni.Write("COLOR_SHADOW", "&H808080", "標準配色");
                SettingsIni.Write("COLOR_NOTE_NOR", "&HFFC000", "標準配色");
                SettingsIni.Write("COLOR_NOTE_TOP", "&HFF80FF", "標準配色");
                SettingsIni.Write("COLOR_NOTE_SEL", "&HFF40FF", "標準配色");
                SettingsIni.Write("COLOR_NOTE_TNOR", "&H000000", "標準配色");
                SettingsIni.Write("COLOR_NOTE_TTOP", "&H800000", "標準配色");
                SettingsIni.Write("COLOR_NOTE_TSEL", "&H800000", "標準配色");
                SettingsIni.Write("COLOR_NOTE_RNOR", "&HFFFFFF", "標準配色");
                SettingsIni.Write("COLOR_NOTE_RTOP", "&HC0C0C0", "標準配色");
                SettingsIni.Write("COLOR_NOTE_RSEL", "&H808080", "標準配色");
                SettingsIni.Write("COLOR_PTCH_SEL", "&H0000FF", "標準配色");
                SettingsIni.Write("COLOR_PTCH_NOR", "&HFF0000", "標準配色");
                SettingsIni.Write("COLOR_TEMPO_NOR", "&H0000FF", "標準配色");
                SettingsIni.Write("COLOR_TEMPO_ALL", "&HFF0000", "標準配色");
                SettingsIni.Write("TransformTitle", "", "標準配色");
            }
            SettingsIni = new IniFile("utaucolours2023.ini");
            string[] sectionNames = SettingsIni.GetSectionNames();
            themesListBox.Items.Clear();
            foreach (string sectionName in sectionNames)
            {
                themesListBox.Items.Add(sectionName);
            }
            themesListBox.SelectedIndex = 0;

            WhiteKeyTextBox.Text = SettingsIni.Read("COLOR_PIANO1", themesListBox.GetItemText(themesListBox.SelectedItem)).Substring(2);
            BlackKeyTextBox.Text = SettingsIni.Read("COLOR_PIANO2", themesListBox.GetItemText(themesListBox.SelectedItem)).Substring(2);
            PianoRollKeyWhiteTextBox.Text = SettingsIni.Read("COLOR_ROLL1", themesListBox.GetItemText(themesListBox.SelectedItem)).Substring(2);
            PianoRollKeyBlackTextBox.Text = SettingsIni.Read("COLOR_ROLL2", themesListBox.GetItemText(themesListBox.SelectedItem)).Substring(2);
            MeasureLineTextBox.Text = SettingsIni.Read("COLOR_SEPA1", themesListBox.GetItemText(themesListBox.SelectedItem)).Substring(2);
            QuarterNoteLineTextBox.Text = SettingsIni.Read("COLOR_SEPA2", themesListBox.GetItemText(themesListBox.SelectedItem)).Substring(2);
            MeasureBackgroundTextBox.Text = SettingsIni.Read("COLOR_BACK", themesListBox.GetItemText(themesListBox.SelectedItem)).Substring(2);
            MeasureOctaveTextTextBox.Text = SettingsIni.Read("COLOR_FORE", themesListBox.GetItemText(themesListBox.SelectedItem)).Substring(2);
            PianoRollNoteDividerTextBox.Text = SettingsIni.Read("COLOR_SHADOW", themesListBox.GetItemText(themesListBox.SelectedItem)).Substring(2);
            NoteDeselectedTextBox.Text = SettingsIni.Read("COLOR_NOTE_NOR", themesListBox.GetItemText(themesListBox.SelectedItem)).Substring(2);
            NoteFirstSelectedTextBox.Text = SettingsIni.Read("COLOR_NOTE_TOP", themesListBox.GetItemText(themesListBox.SelectedItem)).Substring(2);
            NoteSelectedTextBox.Text = SettingsIni.Read("COLOR_NOTE_SEL", themesListBox.GetItemText(themesListBox.SelectedItem)).Substring(2);
            NoteFontDeselectedTextBox.Text = SettingsIni.Read("COLOR_NOTE_TNOR", themesListBox.GetItemText(themesListBox.SelectedItem)).Substring(2);
            NoteFontFirstSelectedTextBox.Text = SettingsIni.Read("COLOR_NOTE_TTOP", themesListBox.GetItemText(themesListBox.SelectedItem)).Substring(2);
            NoteFontSelectedTextBox.Text = SettingsIni.Read("COLOR_NOTE_TSEL", themesListBox.GetItemText(themesListBox.SelectedItem)).Substring(2);
            RestDeselectedTextBox.Text = SettingsIni.Read("COLOR_NOTE_RNOR", themesListBox.GetItemText(themesListBox.SelectedItem)).Substring(2);
            RestFirstSelectedTextBox.Text = SettingsIni.Read("COLOR_NOTE_RTOP", themesListBox.GetItemText(themesListBox.SelectedItem)).Substring(2);
            RestSelectedTextBox.Text = SettingsIni.Read("COLOR_NOTE_RSEL", themesListBox.GetItemText(themesListBox.SelectedItem)).Substring(2);
            PitchLineDeselectedTextBox.Text = SettingsIni.Read("COLOR_PTCH_SEL", themesListBox.GetItemText(themesListBox.SelectedItem)).Substring(2);
            PitchLineSelectedTextBox.Text = SettingsIni.Read("COLOR_PTCH_NOR", themesListBox.GetItemText(themesListBox.SelectedItem)).Substring(2);
            TempoInitialTextBox.Text = SettingsIni.Read("COLOR_TEMPO_ALL", themesListBox.GetItemText(themesListBox.SelectedItem)).Substring(2);
            TempoChangeTextBox.Text = SettingsIni.Read("COLOR_TEMPO_NOR", themesListBox.GetItemText(themesListBox.SelectedItem)).Substring(2);
            TitlebarTextTextBox.Text = SettingsIni.Read("TransformTitle", themesListBox.GetItemText(themesListBox.SelectedItem));
            Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
            Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
            drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
            previewPictureBox.Image = bmp; // Displays the bitmap on the picture box
            //Event Check if Text in Text Box was changed.
            WhiteKeyTextBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            BlackKeyTextBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            PianoRollKeyWhiteTextBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            PianoRollKeyBlackTextBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            MeasureLineTextBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            QuarterNoteLineTextBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            MeasureBackgroundTextBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            MeasureOctaveTextTextBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            PianoRollNoteDividerTextBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            NoteDeselectedTextBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            NoteFirstSelectedTextBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            NoteSelectedTextBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            NoteFontDeselectedTextBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            NoteFontFirstSelectedTextBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            NoteFontSelectedTextBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            RestDeselectedTextBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            RestFirstSelectedTextBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            RestSelectedTextBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            PitchLineSelectedTextBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            PitchLineDeselectedTextBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            TempoInitialTextBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            TempoChangeTextBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            TitlebarTextTextBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            previousThemeIndex = themesListBox.SelectedIndex;
        }
        
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 newTheme = new Form2();
            newTheme.ShowDialog();
            loadThemeList();
            themesListBox.SelectedIndex = themesListBox.Items.Count - 1;
        }

        private void loadThemeList()
        {
            IniFile SettingsIni = new IniFile("utaucolours2023.ini");
            string[] sectionNames = SettingsIni.GetSectionNames();
            themesListBox.Items.Clear();
            foreach (string sectionName in sectionNames)
            {
                themesListBox.Items.Add(sectionName);
            }
        }

        // A function that takes a hex color string and returns an RGB array
        public int[] hexToRgb(string hex)
        {
            // Split the string into three pairs of hex digits
            string b = hex.Substring(0, 2);
            string g = hex.Substring(2, 2);
            string r = hex.Substring(4, 2);
            // Convert each pair of hex digits to a decimal number
            int B = Convert.ToInt32(b, 16);
            int G = Convert.ToInt32(g, 16);
            int R = Convert.ToInt32(r, 16);
            // Return the RGB array
            return new int[] {R, G, B};
        }

        private void WhiteKeyButton_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            color.Color = Color.FromArgb(hexToRgb(WhiteKeyTextBox.Text)[0], hexToRgb(WhiteKeyTextBox.Text)[1], hexToRgb(WhiteKeyTextBox.Text)[2]);
            color.FullOpen = true;
            color.ShowDialog();
            string hex_color = String.Format("{0:X2}{1:X2}{2:X2}", color.Color.B, color.Color.G, color.Color.R);
            WhiteKeyTextBox.Text = hex_color;
            previewPictureBox.Image.Dispose();
            Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
            Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
            drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
            previewPictureBox.Image = bmp; // Displays the bitmap on the picture box
        }

        private void BlackKeyButton_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            color.Color = Color.FromArgb(hexToRgb(BlackKeyTextBox.Text)[0], hexToRgb(BlackKeyTextBox.Text)[1], hexToRgb(BlackKeyTextBox.Text)[2]);
            color.FullOpen = true;
            color.ShowDialog();
            string hex_color = String.Format("{0:X2}{1:X2}{2:X2}", color.Color.B, color.Color.G, color.Color.R);
            BlackKeyTextBox.Text = hex_color;
            previewPictureBox.Image.Dispose();
            Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
            Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
            drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
            previewPictureBox.Image = bmp; // Displays the bitmap on the picture box
        }

        private void MeasureNumberButton_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            color.Color = Color.FromArgb(hexToRgb(MeasureOctaveTextTextBox.Text)[0], hexToRgb(MeasureOctaveTextTextBox.Text)[1], hexToRgb(MeasureOctaveTextTextBox.Text)[2]);
            color.FullOpen = true;
            color.ShowDialog();
            string hex_color = String.Format("{0:X2}{1:X2}{2:X2}", color.Color.B, color.Color.G, color.Color.R);
            MeasureOctaveTextTextBox.Text = hex_color;
            previewPictureBox.Image.Dispose();
            Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
            Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
            drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
            previewPictureBox.Image = bmp; // Displays the bitmap on the picture box

        }

        private void MeasureBackgrounButton_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            color.Color = Color.FromArgb(hexToRgb(MeasureBackgroundTextBox.Text)[0], hexToRgb(MeasureBackgroundTextBox.Text)[1], hexToRgb(MeasureBackgroundTextBox.Text)[2]);
            color.FullOpen = true;
            color.ShowDialog();
            string hex_color = String.Format("{0:X2}{1:X2}{2:X2}", color.Color.B, color.Color.G, color.Color.R);
            MeasureBackgroundTextBox.Text = hex_color;
            previewPictureBox.Image.Dispose();
            Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
            Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
            drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
            previewPictureBox.Image = bmp; // Displays the bitmap on the picture box
        }

        private void PianoRollWhiteButton_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            color.Color = Color.FromArgb(hexToRgb(PianoRollKeyWhiteTextBox.Text)[0], hexToRgb(PianoRollKeyWhiteTextBox.Text)[1], hexToRgb(PianoRollKeyWhiteTextBox.Text)[2]);
            color.FullOpen = true;
            color.ShowDialog();
            string hex_color = String.Format("{0:X2}{1:X2}{2:X2}", color.Color.B, color.Color.G, color.Color.R);
            PianoRollKeyWhiteTextBox.Text = hex_color;
            previewPictureBox.Image.Dispose();
            Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
            Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
            drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
            previewPictureBox.Image = bmp; // Displays the bitmap on the picture box
        }

        private void PianoRollBlackButton_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            color.Color = Color.FromArgb(hexToRgb(PianoRollKeyBlackTextBox.Text)[0], hexToRgb(PianoRollKeyBlackTextBox.Text)[1], hexToRgb(PianoRollKeyBlackTextBox.Text)[2]);
            color.FullOpen = true;
            color.ShowDialog();
            string hex_color = String.Format("{0:X2}{1:X2}{2:X2}", color.Color.B, color.Color.G, color.Color.R);
            PianoRollKeyBlackTextBox.Text = hex_color;
            previewPictureBox.Image.Dispose();
            Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
            Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
            drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
            previewPictureBox.Image = bmp; // Displays the bitmap on the picture box
        }

        private void MeasureLineButton_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            color.Color = Color.FromArgb(hexToRgb(MeasureLineTextBox.Text)[0], hexToRgb(MeasureLineTextBox.Text)[1], hexToRgb(MeasureLineTextBox.Text)[2]);
            color.FullOpen = true;
            color.ShowDialog();
            string hex_color = String.Format("{0:X2}{1:X2}{2:X2}", color.Color.B, color.Color.G, color.Color.R);
            MeasureLineTextBox.Text = hex_color;
            previewPictureBox.Image.Dispose();
            Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
            Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
            drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
            previewPictureBox.Image = bmp; // Displays the bitmap on the picture box
        }

        private void QuarterNoteLineButton_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            color.Color = Color.FromArgb(hexToRgb(QuarterNoteLineTextBox.Text)[0], hexToRgb(QuarterNoteLineTextBox.Text)[1], hexToRgb(QuarterNoteLineTextBox.Text)[2]);
            color.FullOpen = true;
            color.ShowDialog();
            string hex_color = String.Format("{0:X2}{1:X2}{2:X2}", color.Color.B, color.Color.G, color.Color.R);
            QuarterNoteLineTextBox.Text = hex_color;
            previewPictureBox.Image.Dispose();
            Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
            Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
            drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
            previewPictureBox.Image = bmp; // Displays the bitmap on the picture box
        }

        private void TempoIndicatorButton_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            color.Color = Color.FromArgb(hexToRgb(TempoInitialTextBox.Text)[0], hexToRgb(TempoInitialTextBox.Text)[1], hexToRgb(TempoInitialTextBox.Text)[2]);
            color.FullOpen = true;
            color.ShowDialog();
            string hex_color = String.Format("{0:X2}{1:X2}{2:X2}", color.Color.B, color.Color.G, color.Color.R);
            TempoInitialTextBox.Text = hex_color;
            previewPictureBox.Image.Dispose();
            Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
            Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
            drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
            previewPictureBox.Image = bmp; // Displays the bitmap on the picture box
        }

        private void TempoChangeButton_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            color.Color = Color.FromArgb(hexToRgb(TempoChangeTextBox.Text)[0], hexToRgb(TempoChangeTextBox.Text)[1], hexToRgb(TempoChangeTextBox.Text)[2]);
            color.FullOpen = true;
            color.ShowDialog();
            string hex_color = String.Format("{0:X2}{1:X2}{2:X2}", color.Color.B, color.Color.G, color.Color.R);
            TempoChangeTextBox.Text = hex_color;
            previewPictureBox.Image.Dispose();
            Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
            Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
            drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
            previewPictureBox.Image = bmp; // Displays the bitmap on the picture box
        }

        private void PianoRollNoteDividerButton_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            color.Color = Color.FromArgb(hexToRgb(PianoRollNoteDividerTextBox.Text)[0], hexToRgb(PianoRollNoteDividerTextBox.Text)[1], hexToRgb(PianoRollNoteDividerTextBox.Text)[2]);
            color.FullOpen = true;
            color.ShowDialog();
            string hex_color = String.Format("{0:X2}{1:X2}{2:X2}", color.Color.B, color.Color.G, color.Color.R);
            PianoRollNoteDividerTextBox.Text = hex_color;
            previewPictureBox.Image.Dispose();
            Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
            Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
            drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
            previewPictureBox.Image = bmp; // Displays the bitmap on the picture box
        }

        private void NoteDeselectedButton_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            color.Color = Color.FromArgb(hexToRgb(NoteDeselectedTextBox.Text)[0], hexToRgb(NoteDeselectedTextBox.Text)[1], hexToRgb(NoteDeselectedTextBox.Text)[2]);
            color.FullOpen = true;
            color.ShowDialog();
            string hex_color = String.Format("{0:X2}{1:X2}{2:X2}", color.Color.B, color.Color.G, color.Color.R);
            NoteDeselectedTextBox.Text = hex_color;
            previewPictureBox.Image.Dispose();
            Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
            Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
            drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
            previewPictureBox.Image = bmp; // Displays the bitmap on the picture box
        }

        private void NoteFirstSelectedButton_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            color.Color = Color.FromArgb(hexToRgb(NoteFirstSelectedTextBox.Text)[0], hexToRgb(NoteFirstSelectedTextBox.Text)[1], hexToRgb(NoteFirstSelectedTextBox.Text)[2]);
            color.FullOpen = true;
            color.ShowDialog();
            string hex_color = String.Format("{0:X2}{1:X2}{2:X2}", color.Color.B, color.Color.G, color.Color.R);
            NoteFirstSelectedTextBox.Text = hex_color;
            previewPictureBox.Image.Dispose();
            Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
            Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
            drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
            previewPictureBox.Image = bmp; // Displays the bitmap on the picture box
        }

        private void NoteSelectedButton_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            color.Color = Color.FromArgb(hexToRgb(NoteSelectedTextBox.Text)[0], hexToRgb(NoteSelectedTextBox.Text)[1], hexToRgb(NoteSelectedTextBox.Text)[2]);
            color.FullOpen = true;
            color.ShowDialog();
            string hex_color = String.Format("{0:X2}{1:X2}{2:X2}", color.Color.B, color.Color.G, color.Color.R);
            NoteSelectedTextBox.Text = hex_color;
            previewPictureBox.Image.Dispose();
            Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
            Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
            drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
            previewPictureBox.Image = bmp; // Displays the bitmap on the picture box
        }

        private void saveThemeListAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveThemeListDialog = new SaveFileDialog();
            saveThemeListDialog.Filter = "Text File|*.txt|All Files|*.*";
            saveThemeListDialog.Title = "Save Themes List...";
          
            if(saveThemeListDialog.ShowDialog() == DialogResult.OK)
            {
                if(saveThemeListDialog.FileName != "")
                {
                    switch (saveThemeListDialog.FilterIndex)
                    {
                        case 1:
                            File.WriteAllText(saveThemeListDialog.FileName, File.ReadAllText("utaucolours2023.ini"), Encoding.Default);
                            break;
                        case 2:
                            File.WriteAllText(saveThemeListDialog.FileName, File.ReadAllText("utaucolours2023.ini"), Encoding.Default);
                            break;
                    }
                }
            }
        }

        private void PitchLineDeselectedButton_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            color.Color = Color.FromArgb(hexToRgb(PitchLineDeselectedTextBox.Text)[0], hexToRgb(PitchLineDeselectedTextBox.Text)[1], hexToRgb(PitchLineDeselectedTextBox.Text)[2]);
            color.FullOpen = true;
            color.ShowDialog();
            string hex_color = String.Format("{0:X2}{1:X2}{2:X2}", color.Color.B, color.Color.G, color.Color.R);
            PitchLineDeselectedTextBox.Text = hex_color;
            previewPictureBox.Image.Dispose();
            Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
            Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
            drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
            previewPictureBox.Image = bmp; // Displays the bitmap on the picture box
        }

        private void PitchLineSelectedButton_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            color.Color = Color.FromArgb(hexToRgb(PitchLineSelectedTextBox.Text)[0], hexToRgb(PitchLineSelectedTextBox.Text)[1], hexToRgb(PitchLineSelectedTextBox.Text)[2]);
            color.FullOpen = true;
            color.ShowDialog();
            string hex_color = String.Format("{0:X2}{1:X2}{2:X2}", color.Color.B, color.Color.G, color.Color.R);
            PitchLineSelectedTextBox.Text = hex_color;
            previewPictureBox.Image.Dispose();
            Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
            Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
            drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
            previewPictureBox.Image = bmp; // Displays the bitmap on the picture box
        }

        private void NoteFontDeselectedButton_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            color.Color = Color.FromArgb(hexToRgb(NoteFontDeselectedTextBox.Text)[0], hexToRgb(NoteFontDeselectedTextBox.Text)[1], hexToRgb(NoteFontDeselectedTextBox.Text)[2]);
            color.FullOpen = true;
            color.ShowDialog();
            string hex_color = String.Format("{0:X2}{1:X2}{2:X2}", color.Color.B, color.Color.G, color.Color.R);
            NoteFontDeselectedTextBox.Text = hex_color;
            previewPictureBox.Image.Dispose();
            Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
            Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
            drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
            previewPictureBox.Image = bmp; // Displays the bitmap on the picture box
        }

        private void NoteFontFirstSelectedButton_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            color.Color = Color.FromArgb(hexToRgb(NoteFontFirstSelectedTextBox.Text)[0], hexToRgb(NoteFontFirstSelectedTextBox.Text)[1], hexToRgb(NoteFontFirstSelectedTextBox.Text)[2]);
            color.FullOpen = true;
            color.ShowDialog();
            string hex_color = String.Format("{0:X2}{1:X2}{2:X2}", color.Color.B, color.Color.G, color.Color.R);
            NoteFontFirstSelectedTextBox.Text = hex_color;
            previewPictureBox.Image.Dispose();
            Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
            Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
            drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
            previewPictureBox.Image = bmp; // Displays the bitmap on the picture box
        }

        private void NoteFontSelectedButton_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            color.Color = Color.FromArgb(hexToRgb(NoteFontSelectedTextBox.Text)[0], hexToRgb(NoteFontSelectedTextBox.Text)[1], hexToRgb(NoteFontSelectedTextBox.Text)[2]);
            color.FullOpen = true;
            color.ShowDialog();
            string hex_color = String.Format("{0:X2}{1:X2}{2:X2}", color.Color.B, color.Color.G, color.Color.R);
            NoteFontSelectedTextBox.Text = hex_color;
            previewPictureBox.Image.Dispose();
            Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
            Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
            drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
            previewPictureBox.Image = bmp; // Displays the bitmap on the picture box
        }

        private void RestDeselectedButton_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            color.Color = Color.FromArgb(hexToRgb(RestDeselectedTextBox.Text)[0], hexToRgb(RestDeselectedTextBox.Text)[1], hexToRgb(RestDeselectedTextBox.Text)[2]);
            color.FullOpen = true;
            color.ShowDialog();
            string hex_color = String.Format("{0:X2}{1:X2}{2:X2}", color.Color.B, color.Color.G, color.Color.R);
            RestDeselectedTextBox.Text = hex_color;
            previewPictureBox.Image.Dispose();
            Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
            Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
            drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
            previewPictureBox.Image = bmp; // Displays the bitmap on the picture box
        }

        private void RestFirstSelectedButton_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            color.Color = Color.FromArgb(hexToRgb(RestFirstSelectedTextBox.Text)[0], hexToRgb(RestFirstSelectedTextBox.Text)[1], hexToRgb(RestFirstSelectedTextBox.Text)[2]);
            color.FullOpen = true;
            color.ShowDialog();
            string hex_color = String.Format("{0:X2}{1:X2}{2:X2}", color.Color.B, color.Color.G, color.Color.R);
            RestFirstSelectedTextBox.Text = hex_color;
            previewPictureBox.Image.Dispose();
            Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
            Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
            drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
            previewPictureBox.Image = bmp; // Displays the bitmap on the picture box
        }

        private void RestSelectedButton_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            color.Color = Color.FromArgb(hexToRgb(RestSelectedTextBox.Text)[0], hexToRgb(RestSelectedTextBox.Text)[1], hexToRgb(RestSelectedTextBox.Text)[2]);
            color.FullOpen = true;
            color.ShowDialog();
            string hex_color = String.Format("{0:X2}{1:X2}{2:X2}", color.Color.B, color.Color.G, color.Color.R);
            RestSelectedTextBox.Text = hex_color;
            previewPictureBox.Image.Dispose();
            Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
            Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
            drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
            previewPictureBox.Image = bmp; // Displays the bitmap on the picture box
        }

        private void themesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int currentIndex = themesListBox.SelectedIndex;
            if (TextWasChanged)
            {
                saveChanges(null,null);
                themesListBox.SetSelected(currentIndex,true);
                previousThemeIndex = currentIndex;
            }
            previousThemeIndex = currentIndex;
            IniFile SettingsIni = new IniFile("utaucolours2023.ini");
            WhiteKeyTextBox.Text = SettingsIni.Read("COLOR_PIANO1", themesListBox.GetItemText(themesListBox.SelectedItem)).Substring(2);
            BlackKeyTextBox.Text = SettingsIni.Read("COLOR_PIANO2", themesListBox.GetItemText(themesListBox.SelectedItem)).Substring(2);
            PianoRollKeyWhiteTextBox.Text = SettingsIni.Read("COLOR_ROLL1", themesListBox.GetItemText(themesListBox.SelectedItem)).Substring(2);
            PianoRollKeyBlackTextBox.Text = SettingsIni.Read("COLOR_ROLL2", themesListBox.GetItemText(themesListBox.SelectedItem)).Substring(2);
            MeasureLineTextBox.Text = SettingsIni.Read("COLOR_SEPA1", themesListBox.GetItemText(themesListBox.SelectedItem)).Substring(2);
            QuarterNoteLineTextBox.Text = SettingsIni.Read("COLOR_SEPA2", themesListBox.GetItemText(themesListBox.SelectedItem)).Substring(2);
            MeasureBackgroundTextBox.Text = SettingsIni.Read("COLOR_BACK", themesListBox.GetItemText(themesListBox.SelectedItem)).Substring(2);
            MeasureOctaveTextTextBox.Text = SettingsIni.Read("COLOR_FORE", themesListBox.GetItemText(themesListBox.SelectedItem)).Substring(2);
            PianoRollNoteDividerTextBox.Text = SettingsIni.Read("COLOR_SHADOW", themesListBox.GetItemText(themesListBox.SelectedItem)).Substring(2);
            NoteDeselectedTextBox.Text = SettingsIni.Read("COLOR_NOTE_NOR", themesListBox.GetItemText(themesListBox.SelectedItem)).Substring(2);
            NoteFirstSelectedTextBox.Text = SettingsIni.Read("COLOR_NOTE_TOP", themesListBox.GetItemText(themesListBox.SelectedItem)).Substring(2);
            NoteSelectedTextBox.Text = SettingsIni.Read("COLOR_NOTE_SEL", themesListBox.GetItemText(themesListBox.SelectedItem)).Substring(2);
            NoteFontDeselectedTextBox.Text = SettingsIni.Read("COLOR_NOTE_TNOR", themesListBox.GetItemText(themesListBox.SelectedItem)).Substring(2);
            NoteFontFirstSelectedTextBox.Text = SettingsIni.Read("COLOR_NOTE_TTOP", themesListBox.GetItemText(themesListBox.SelectedItem)).Substring(2);
            NoteFontSelectedTextBox.Text = SettingsIni.Read("COLOR_NOTE_TSEL", themesListBox.GetItemText(themesListBox.SelectedItem)).Substring(2);
            RestDeselectedTextBox.Text = SettingsIni.Read("COLOR_NOTE_RNOR", themesListBox.GetItemText(themesListBox.SelectedItem)).Substring(2);
            RestFirstSelectedTextBox.Text = SettingsIni.Read("COLOR_NOTE_RTOP", themesListBox.GetItemText(themesListBox.SelectedItem)).Substring(2);
            RestSelectedTextBox.Text = SettingsIni.Read("COLOR_NOTE_RSEL", themesListBox.GetItemText(themesListBox.SelectedItem)).Substring(2);
            PitchLineSelectedTextBox.Text = SettingsIni.Read("COLOR_PTCH_SEL", themesListBox.GetItemText(themesListBox.SelectedItem)).Substring(2);
            PitchLineDeselectedTextBox.Text = SettingsIni.Read("COLOR_PTCH_NOR", themesListBox.GetItemText(themesListBox.SelectedItem)).Substring(2);
            TempoInitialTextBox.Text = SettingsIni.Read("COLOR_TEMPO_ALL", themesListBox.GetItemText(themesListBox.SelectedItem)).Substring(2);
            TempoChangeTextBox.Text = SettingsIni.Read("COLOR_TEMPO_NOR", themesListBox.GetItemText(themesListBox.SelectedItem)).Substring(2);
            if (SettingsIni.Read("TransformTitle", themesListBox.GetItemText(themesListBox.SelectedItem)) != null && SettingsIni.Read("TransformTitle", themesListBox.GetItemText(themesListBox.SelectedItem)) != "")
            {
                TitlebarTextTextBox.Text = SettingsIni.Read("TransformTitle", themesListBox.GetItemText(themesListBox.SelectedItem));
            }
            else
            {
                TitlebarTextTextBox.Text = "";
            }
            if (previewPictureBox.Image != null)
            {
                previewPictureBox.Image.Dispose();
            }
            Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
            Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
            drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
            previewPictureBox.Image = bmp; // Displays the bitmap on the picture box
            TextWasChanged = false;
        }
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            TextWasChanged = true;
        }
        void saveChanges(object sender, EventArgs e)
        {
            if (MessageBox.Show("You have unsaved changes. Save?", "Save?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                IniFile SettingsIni = new IniFile("utaucolours2023.ini");
                SettingsIni.Write("COLOR_PIANO1", "&H" + WhiteKeyTextBox.Text, themesListBox.GetItemText(themesListBox.Items[previousThemeIndex]));
                SettingsIni.Write("COLOR_PIANO2", "&H" + BlackKeyTextBox.Text, themesListBox.GetItemText(themesListBox.Items[previousThemeIndex]));
                SettingsIni.Write("COLOR_ROLL1", "&H" + PianoRollKeyWhiteTextBox.Text, themesListBox.GetItemText(themesListBox.Items[previousThemeIndex]));
                SettingsIni.Write("COLOR_ROLL2", "&H" + PianoRollKeyBlackTextBox.Text, themesListBox.GetItemText(themesListBox.Items[previousThemeIndex]));
                SettingsIni.Write("COLOR_SEPA1", "&H" + MeasureLineTextBox.Text, themesListBox.GetItemText(themesListBox.Items[previousThemeIndex]));
                SettingsIni.Write("COLOR_SEPA2", "&H" + QuarterNoteLineTextBox.Text, themesListBox.GetItemText(themesListBox.Items[previousThemeIndex]));
                SettingsIni.Write("COLOR_BACK", "&H" + MeasureBackgroundTextBox.Text, themesListBox.GetItemText(themesListBox.Items[previousThemeIndex]));
                SettingsIni.Write("COLOR_FORE", "&H" + MeasureOctaveTextTextBox.Text, themesListBox.GetItemText(themesListBox.Items[previousThemeIndex]));
                SettingsIni.Write("COLOR_SHADOW", "&H" + PianoRollNoteDividerTextBox.Text, themesListBox.GetItemText(themesListBox.Items[previousThemeIndex]));
                SettingsIni.Write("COLOR_NOTE_NOR", "&H" + NoteDeselectedTextBox.Text, themesListBox.GetItemText(themesListBox.Items[previousThemeIndex]));
                SettingsIni.Write("COLOR_NOTE_TOP", "&H" + NoteFirstSelectedTextBox.Text, themesListBox.GetItemText(themesListBox.Items[previousThemeIndex]));
                SettingsIni.Write("COLOR_NOTE_SEL", "&H" + NoteSelectedTextBox.Text, themesListBox.GetItemText(themesListBox.Items[previousThemeIndex]));
                SettingsIni.Write("COLOR_NOTE_TNOR", "&H" + NoteFontDeselectedTextBox.Text, themesListBox.GetItemText(themesListBox.Items[previousThemeIndex]));
                SettingsIni.Write("COLOR_NOTE_TTOP", "&H" + NoteFontFirstSelectedTextBox.Text, themesListBox.GetItemText(themesListBox.Items[previousThemeIndex]));
                SettingsIni.Write("COLOR_NOTE_TSEL", "&H" + NoteFontSelectedTextBox.Text, themesListBox.GetItemText(themesListBox.Items[previousThemeIndex]));
                SettingsIni.Write("COLOR_NOTE_RNOR", "&H" + RestDeselectedTextBox.Text, themesListBox.GetItemText(themesListBox.Items[previousThemeIndex]));
                SettingsIni.Write("COLOR_NOTE_RTOP", "&H" + RestFirstSelectedTextBox.Text, themesListBox.GetItemText(themesListBox.Items[previousThemeIndex]));
                SettingsIni.Write("COLOR_NOTE_RSEL", "&H" + RestSelectedTextBox.Text, themesListBox.GetItemText(themesListBox.Items[previousThemeIndex]));
                SettingsIni.Write("COLOR_PTCH_SEL", "&H" + PitchLineSelectedTextBox.Text, themesListBox.GetItemText(themesListBox.Items[previousThemeIndex]));
                SettingsIni.Write("COLOR_PTCH_NOR", "&H" + PitchLineDeselectedTextBox.Text, themesListBox.GetItemText(themesListBox.Items[previousThemeIndex]));
                SettingsIni.Write("COLOR_TEMPO_NOR", "&H" + TempoChangeTextBox.Text, themesListBox.GetItemText(themesListBox.Items[previousThemeIndex]));
                SettingsIni.Write("COLOR_TEMPO_ALL", "&H" + TempoInitialTextBox.Text, themesListBox.GetItemText(themesListBox.Items[previousThemeIndex]));
                if (TitlebarTextTextBox.Text != null)
                {
                    SettingsIni.Write("TransformTitle", TitlebarTextTextBox.Text, themesListBox.GetItemText(themesListBox.Items[previousThemeIndex]));
                }
                TextWasChanged = false;
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int currentIndex = themesListBox.SelectedIndex;
            IniFile SettingsIni = new IniFile("utaucolours2023.ini");
            if (themesListBox.Items.Count > 1)
            {
                if (MessageBox.Show("This will remove this theme entirely and its values will be lost. This cannot be undone. Do you want to continue?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    SettingsIni.DeleteSection(themesListBox.GetItemText(themesListBox.SelectedItem));
                }
                loadThemeList();
                if (themesListBox.SelectedIndex > themesListBox.Items.Count - 1)
                {
                    if (currentIndex != 0)
                    {
                        themesListBox.SetSelected(currentIndex - 2, true);
                    }
                    else
                    {
                        themesListBox.SetSelected(0, true);
                    }
                }
                else
                {
                    if (currentIndex != 0)
                    {
                        themesListBox.SetSelected(currentIndex - 1, true);
                    }
                    else
                    {
                        themesListBox.SetSelected(0, true);
                    }
                }
            }
            else
            {
                MessageBox.Show("Your themes list cannot be blank.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            TextWasChanged = false;
        }

        private void initializeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You are about to reset the current theme back to the original UTAU settings. Do you wish to continue?", "Initialize", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                IniFile SettingsIni = new IniFile("utaucolours2023.ini");
                SettingsIni.Write("COLOR_PIANO1", "&HFFFFFF", themesListBox.GetItemText(themesListBox.SelectedItem));
                SettingsIni.Write("COLOR_PIANO2", "&H404040", themesListBox.GetItemText(themesListBox.SelectedItem));
                SettingsIni.Write("COLOR_ROLL1", "&HFFFFFF", themesListBox.GetItemText(themesListBox.SelectedItem));
                SettingsIni.Write("COLOR_ROLL2", "&HE0E0E0", themesListBox.GetItemText(themesListBox.SelectedItem));
                SettingsIni.Write("COLOR_SEPA1", "&HFF40FF", themesListBox.GetItemText(themesListBox.SelectedItem));
                SettingsIni.Write("COLOR_SEPA2", "&HFF8080", themesListBox.GetItemText(themesListBox.SelectedItem));
                SettingsIni.Write("COLOR_BACK", "&HFFFFFF", themesListBox.GetItemText(themesListBox.SelectedItem));
                SettingsIni.Write("COLOR_FORE", "&H000000", themesListBox.GetItemText(themesListBox.SelectedItem));
                SettingsIni.Write("COLOR_SHADOW", "&H808080", themesListBox.GetItemText(themesListBox.SelectedItem));
                SettingsIni.Write("COLOR_NOTE_NOR", "&HFFC000", themesListBox.GetItemText(themesListBox.SelectedItem));
                SettingsIni.Write("COLOR_NOTE_TOP", "&HFF80FF", themesListBox.GetItemText(themesListBox.SelectedItem));
                SettingsIni.Write("COLOR_NOTE_SEL", "&HFF40FF", themesListBox.GetItemText(themesListBox.SelectedItem));
                SettingsIni.Write("COLOR_NOTE_TNOR", "&H000000", themesListBox.GetItemText(themesListBox.SelectedItem));
                SettingsIni.Write("COLOR_NOTE_TTOP", "&H800000", themesListBox.GetItemText(themesListBox.SelectedItem));
                SettingsIni.Write("COLOR_NOTE_TSEL", "&H800000", themesListBox.GetItemText(themesListBox.SelectedItem));
                SettingsIni.Write("COLOR_NOTE_RNOR", "&HFFFFFF", themesListBox.GetItemText(themesListBox.SelectedItem));
                SettingsIni.Write("COLOR_NOTE_RTOP", "&HC0C0C0", themesListBox.GetItemText(themesListBox.SelectedItem));
                SettingsIni.Write("COLOR_NOTE_RSEL", "&H808080", themesListBox.GetItemText(themesListBox.SelectedItem));
                SettingsIni.Write("COLOR_PTCH_SEL", "&H0000FF", themesListBox.GetItemText(themesListBox.SelectedItem));
                SettingsIni.Write("COLOR_PTCH_NOR", "&HFF0000", themesListBox.GetItemText(themesListBox.SelectedItem));
                SettingsIni.Write("COLOR_TEMPO_NOR", "&H0000FF", themesListBox.GetItemText(themesListBox.SelectedItem));
                SettingsIni.Write("COLOR_TEMPO_ALL", "&HFF0000", themesListBox.GetItemText(themesListBox.SelectedItem));
                SettingsIni.Write("TransformTitle", "", themesListBox.GetItemText(themesListBox.SelectedItem));
                previewPictureBox.Image.Dispose();
                Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
                Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
                drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
                previewPictureBox.Image = bmp; // Displays the bitmap on the picture box
                TextWasChanged = false;
            }
        }

        private void duplicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = 1;
            IniFile SettingsIni = new IniFile("utaucolours2023.ini");
            string[] sectionNames = SettingsIni.GetSectionNames();
            if (sectionNames.Contains(themesListBox.GetItemText(themesListBox.SelectedItem) + "(" + i.ToString() + ")"))
            {
                while (sectionNames.Contains(themesListBox.GetItemText(themesListBox.SelectedItem) + "(" + i.ToString() + ")"))
                {
                    i++;
                }
                SettingsIni.Write("COLOR_PIANO1", "&H" + WhiteKeyTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " (" + i + ")");
                SettingsIni.Write("COLOR_PIANO2", "&H" + BlackKeyTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " (" + i + ")");
                SettingsIni.Write("COLOR_ROLL1", "&H" + PianoRollKeyWhiteTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " (" + i + ")");
                SettingsIni.Write("COLOR_ROLL2", "&H" + PianoRollKeyBlackTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " (" + i + ")");
                SettingsIni.Write("COLOR_SEPA1", "&H" + MeasureLineTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " (" + i + ")");
                SettingsIni.Write("COLOR_SEPA2", "&H" + QuarterNoteLineTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " (" + i + ")");
                SettingsIni.Write("COLOR_BACK", "&H" + MeasureBackgroundTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " (" + i + ")");
                SettingsIni.Write("COLOR_FORE", "&H" + MeasureOctaveTextTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " (" + i + ")");
                SettingsIni.Write("COLOR_SHADOW", "&H" + PianoRollNoteDividerTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " (" + i + ")");
                SettingsIni.Write("COLOR_NOTE_NOR", "&H" + NoteDeselectedTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " (" + i + ")");
                SettingsIni.Write("COLOR_NOTE_TOP", "&H" + NoteFirstSelectedTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " (" + i + ")");
                SettingsIni.Write("COLOR_NOTE_SEL", "&H" + NoteSelectedTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " (" + i + ")");
                SettingsIni.Write("COLOR_NOTE_TNOR", "&H" + NoteFontDeselectedTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " (" + i + ")");
                SettingsIni.Write("COLOR_NOTE_TTOP", "&H" + NoteFontFirstSelectedTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " (" + i + ")");
                SettingsIni.Write("COLOR_NOTE_TSEL", "&H" + NoteFontSelectedTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " (" + i + ")");
                SettingsIni.Write("COLOR_NOTE_RNOR", "&H" + RestDeselectedTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " (" + i + ")");
                SettingsIni.Write("COLOR_NOTE_RTOP", "&H" + RestFirstSelectedTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " (" + i + ")");
                SettingsIni.Write("COLOR_NOTE_RSEL", "&H" + RestSelectedTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " (" + i + ")");
                SettingsIni.Write("COLOR_PTCH_SEL", "&H" + PitchLineSelectedTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " (" + i + ")");
                SettingsIni.Write("COLOR_PTCH_NOR", "&H" + PitchLineDeselectedTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " (" + i + ")");
                SettingsIni.Write("COLOR_TEMPO_NOR", "&H" + TempoChangeTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " (" + i + ")");
                SettingsIni.Write("COLOR_TEMPO_ALL", "&H" + TempoInitialTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " (" + i + ")");
            }
            SettingsIni.Write("COLOR_PIANO1", "&H" + WhiteKeyTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " (" + i + ")");
            SettingsIni.Write("COLOR_PIANO2", "&H" + BlackKeyTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " (" + i + ")");
            SettingsIni.Write("COLOR_ROLL1", "&H" + PianoRollKeyWhiteTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " (" + i + ")");
            SettingsIni.Write("COLOR_ROLL2", "&H" + PianoRollKeyBlackTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " (" + i + ")");
            SettingsIni.Write("COLOR_SEPA1", "&H" + MeasureLineTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " (" + i + ")");
            SettingsIni.Write("COLOR_SEPA2", "&H" + QuarterNoteLineTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " (" + i + ")");
            SettingsIni.Write("COLOR_BACK", "&H" + MeasureBackgroundTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " (" + i + ")");
            SettingsIni.Write("COLOR_FORE", "&H" + MeasureOctaveTextTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " (" + i + ")");
            SettingsIni.Write("COLOR_SHADOW", "&H" + PianoRollNoteDividerTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " (" + i + ")");
            SettingsIni.Write("COLOR_NOTE_NOR", "&H" + NoteDeselectedTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " (" + i + ")");
            SettingsIni.Write("COLOR_NOTE_TOP", "&H" + NoteFirstSelectedTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " (" + i + ")");
            SettingsIni.Write("COLOR_NOTE_SEL", "&H" + NoteSelectedTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " (" + i + ")");
            SettingsIni.Write("COLOR_NOTE_TNOR", "&H" + NoteFontDeselectedTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " (" + i + ")");
            SettingsIni.Write("COLOR_NOTE_TTOP", "&H" + NoteFontFirstSelectedTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " (" + i + ")");
            SettingsIni.Write("COLOR_NOTE_TSEL", "&H" + NoteFontSelectedTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " (" + i + ")");
            SettingsIni.Write("COLOR_NOTE_RNOR", "&H" + RestDeselectedTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " (" + i + ")");
            SettingsIni.Write("COLOR_NOTE_RTOP", "&H" + RestFirstSelectedTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " (" + i + ")");
            SettingsIni.Write("COLOR_NOTE_RSEL", "&H" + RestSelectedTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " (" + i + ")");
            SettingsIni.Write("COLOR_PTCH_SEL", "&H" + PitchLineSelectedTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " (" + i + ")");
            SettingsIni.Write("COLOR_PTCH_NOR", "&H" + PitchLineDeselectedTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " (" + i + ")");
            SettingsIni.Write("COLOR_TEMPO_NOR", "&H" + TempoChangeTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " (" + i + ")");
            SettingsIni.Write("COLOR_TEMPO_ALL", "&H" + TempoInitialTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " (" + i + ")");
            if (TitlebarTextTextBox.Text != null)
            {
                SettingsIni.Write("TransformTitle", TitlebarTextTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " (" + i + ")");
            }
            TextWasChanged = false;
            loadThemeList();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
