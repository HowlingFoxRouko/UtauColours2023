﻿using MyProg;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace UTAUColours2023
{
    public partial class UtauColoursMain : Form
    {
        public string currentLang = "";
        public bool TextWasChanged = false;
        int previousThemeIndex = -1; // Variable to track SelectedIndex of theme Listbox
        IniFile userSettings = new IniFile("uc2023_pref.ini");
        public string deleteDialogText = "";
        public string deleteDialogTitle = "";
        public string saveDialogText = "";
        public string saveDialogTitle = "";
        public string initializeDialogText = "";
        public string initializeDialogTitle = "";
        public string overwriteDialogText = "";
        public string overwriteDialogTitle = "";
        public int LastSelectedThemeIndex = 0;
        public UtauColoursMain()
        {
            InitializeComponent();
            currentLang = userSettings.Read("ActiveLanguage", "Language");
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
                saveChanges(null, null);
            }
            this.Close();
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
                g.FillRectangle(NoteDeselectedPen.Brush, 104, 194, 43, 3);
                g.DrawLine(NoteDeselectedPen, 104, 182, 104, 182 + 14);
                g.DrawLine(NoteDeselectedPen, 104, 182, 104 + 43 - 10, 182);
                g.DrawLine(NoteDeselectedPen, 104 + 43 - 10, 182, 104 + 43 - 5, 182 + 14);
                g.DrawString("ど", MeasureTextFont, NoteFontDeselectedPen.Brush, 103, 183);
                g.FillRectangle(NoteDeselectedPen.Brush, 147, 166, 42, 3);
                g.DrawLine(NoteDeselectedPen, 147 - 10, 154, 147 - 11, 154 + 14);
                g.DrawLine(NoteDeselectedPen, 147 - 10, 154, 147 + 42 - 25, 154);
                g.DrawLine(NoteDeselectedPen, 147 + 42 - 25, 154, 147 + 42 - 10, 154 + 14);
                g.DrawString("れ", MeasureTextFont, NoteFontDeselectedPen.Brush, 146, 155);
                g.FillRectangle(NoteDeselectedPen.Brush, 189, 138, 43, 3);
                g.DrawLine(NoteDeselectedPen, 189 - 20, 126, 189 - 23, 126 + 14);
                g.DrawLine(NoteDeselectedPen, 189 - 20, 126, 189 + 43 - 7, 126);
                g.DrawLine(NoteDeselectedPen, 189 + 43 - 7, 126, 189 + 43, 126 + 14);
                g.DrawString("み", MeasureTextFont, NoteFontDeselectedPen.Brush, 188, 127);
                g.FillRectangle(RestDeselectedPen.Brush, 232, 193, 43, 3);
                g.DrawString("R", MeasureTextFont, NoteFontDeselectedPen.Brush, 231, 183);
                g.FillRectangle(NoteFirstSelectedPen.Brush, 275, 124, 42, 3);
                g.DrawLine(NoteFirstSelectedPen, 275 - 10, 113, 275 - 11, 113 + 13);
                g.DrawLine(NoteFirstSelectedPen, 275 - 10, 113, 275 + 42 - 15, 113);
                g.DrawLine(NoteFirstSelectedPen, 275 + 42 - 15, 113, 275 + 42 - 10, 113 + 13);
                g.DrawRectangle(PitchLineSelectedPen, 275 - 7, 118, 4, 4);
                g.DrawRectangle(PitchLineSelectedPen, 275 + 5, 118, 4, 4);
                g.DrawLine(PitchLineSelectedPen, 275 - 4, 120, 275 + 4, 120);
                g.DrawString("ふぁ", MeasureTextFont, NoteFontFirstSelectedPen.Brush, 274, 114);
                g.FillRectangle(NoteSelectedPen.Brush, 317, 96, 43, 3);
                g.DrawLine(NoteSelectedPen, 317 - 10, 84, 317 - 12, 84 + 13);
                g.DrawLine(NoteSelectedPen, 317 - 10, 84, 317 + 42 - 10, 84);
                g.DrawLine(NoteSelectedPen, 317 + 42 - 10, 84, 317 + 42 - 5, 84 + 13);
                g.DrawString("そ", MeasureTextFont, NoteFontSelectedPen.Brush, 316, 85);
                g.FillRectangle(NoteSelectedPen.Brush, 360, 68, 43, 3);
                g.DrawLine(NoteSelectedPen, 360 - 10, 56, 360 - 11, 56 + 13);
                g.DrawLine(NoteSelectedPen, 360 - 10, 56, 360 + 42 - 10, 56);
                g.DrawLine(NoteSelectedPen, 360 + 42 - 10, 56, 360 + 42 - 5, 56 + 13);
                g.DrawString("ら", MeasureTextFont, NoteFontSelectedPen.Brush, 359, 57);
                g.FillRectangle(RestFirstSelectedPen.Brush, 360, 208, 43, 3);
                g.DrawString("R", MeasureTextFont, NoteFontFirstSelectedPen.Brush, 359, 197);
                g.FillRectangle(RestSelectedPen.Brush, 403, 194, 42, 3);
                g.DrawString("R", MeasureTextFont, NoteFontSelectedPen.Brush, 402, 183);
                g.DrawLine(PitchLineDeselectedPen, 104, 190, 116, 190);
                g.DrawBezier(PitchLineDeselectedPen, 141, 189, 145, 190, 145, 164, 154, 161);
                g.DrawBezier(PitchLineDeselectedPen, 184, 161, 187, 165, 189, 138, 195, 135);
                g.DrawBezier(PitchLineSelectedPen, 307, 119, 314, 122, 316, 93, 323, 92);
                g.DrawBezier(PitchLineSelectedPen, 353, 91, 356, 92, 365, 64, 367, 64);
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
            if (!File.Exists("utaucolours2023.ini"))
            {
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
            PitchLineSelectedTextBox.Text = SettingsIni.Read("COLOR_PTCH_SEL", themesListBox.GetItemText(themesListBox.SelectedItem)).Substring(2);
            PitchLineDeselectedTextBox.Text = SettingsIni.Read("COLOR_PTCH_NOR", themesListBox.GetItemText(themesListBox.SelectedItem)).Substring(2);
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
            bool langFolderExists = Directory.Exists("./lang/");
            if (!langFolderExists)
            {
                Directory.CreateDirectory("./lang/");
                string EnglishIni = "[Language Settings]||languageName=English||languageTag=en-US||[UtauColoursMain]||generateSettingsIniButton=&Generate UTAU setting.ini||TitlebarTextLabel=Titlebar Text:||TempoChangeLabel=Tempo Change Colour||InitialTempoLabel=Initial Tempo Colour||QuarterNoteLineLabel=Quarter Note Line Colour||MeasureLineLabel=Measure Line Colour||PianoRollKeyBlackLabel=Piano Roll Key Colour (Black)||PianoRollKeyWhiteLabel=Piano Roll Key Colour (White)||BlackKeyLabel=Black Key Colour||PitchLineSelectedLabel=Pitch Line Colour (Selection)||RestSelectedLabel=Rest Colour (Selection)||PitchLineDeselectedLabel=Pitch Line Colour (Deselected)||NoteSelectedLabel=Note Colour (Selection)||RestFirstOfSelectedLabel=Rest Colour (First of Selection)||NoteFirstSelectedLabel=Note Colour (First of Selection)||RestDeselectedLabel=Rest Colour (Deselected)||NoteDeselectedLabel=Note Colour (Deselected)||PianoRollNoteDividerLabel=Piano Roll Note Divider Colour||MeasureOctaveTextLabel=Measure/Octave Text Colour||NoteFontSelectedLabel=Note Font Colour (Selected)||NoteFontFirstSelectedLabel=Note Font Colour (First Selected)||NoteFontDeselectedLabel=Note Font Colour (Deselected)||MeasureBackgroundLabel=Measure Background Colour||WhiteKeyLabel=White Key Colour||fileToolStripMenuItem=&File||openSavedThemesListToolStripMenuItem=&Open Saved Themes List...||saveThemesListAsToolStripMenuItem=&Save Theme List As...||exitToolStripMenuItem=E&xit||themeToolStripMenuItem=&Theme||newToolStripMenuItem=&New||duplicateToolStripMenuItem=D&uplicate||renameToolStripMenuItem=Rena&me||deleteToolStripMenuItem=&Delete||initializeToolStripMenuItem=&Initialize||languageToolStripMenuItem=&Language||aboutToolStripMenuItem=&About||PitchLinesCheckBox=Show Pitch Lines||[NewThemeName]||NewThemeName=Name Your Theme||cancelButton=&Cancel||okButton=&Ok||ThemeNameTextbox=Untitled||[About]||About=About||closeAboutButton=&Close||aboutUC2023Label=UTAU Colours 2023 is based%non the original utaucolors program%nby Ameya-P%n%nTranslation, Coding, and Design by HowlingFoxRouko%nIcon by Kotozaki||[Rename]||Rename=Rename||renNewNameLabel=New Theme Name:||renCancelButton=&Cancel||renRenameButton=&Rename||[Dialog]||saveDialogText=You have unsaved changes to the current theme. Save?||saveDialogTitle=Save?||deleteDialogText=This will remove this theme entirely and its values will be lost. This cannot be undone. Do you want to continue?||deleteDialogTitle=Delete||initializeDialogText=You are about to reset the current theme back to the original UTAU settings. Do you wish to continue?||initializeDialogTitle=Initialize||overwriteThemeNameDialogText=This theme already exists. Overwrite?||overwriteThemeNameDialogTitle=Overwrite?";
                string JapaneseIni = "[Language Settings]||languageName=日本語||languageTag=jp-JP||[UtauColoursMain]||generateSettingsIniButton=UTAUのsetting.iniを生成する (&G)||TitlebarTextLabel=タイトル変更||TempoChangeLabel=テンポ指標テキストの色(変更)||InitialTempoLabel=テンポ指標テキストの色(開始)||QuarterNoteLineLabel=縦線の色(1/4小節)||MeasureLineLabel=縦線の色(1小節)||PianoRollKeyBlackLabel=ロールの色(濃)||PianoRollKeyWhiteLabel=ロールの色(薄)||BlackKeyLabel=黒鍵色||PitchLineSelectedLabel=ピッチカーブの色(選択領域)||RestSelectedLabel=休符の色(選択領域)||PitchLineDeselectedLabel=ピッチカーブの色(通常)||NoteSelectedLabel=音符の色(選択領域)||RestFirstOfSelectedLabel=休符の色(選択トップ)||NoteFirstSelectedLabel=音符の色(選択トップ)||RestDeselectedLabel=休符の色(通常)||NoteDeselectedLabel=音符の色(通常)||PianoRollNoteDividerLabel=ロールの区切り横線||MeasureOctaveTextLabel=文字色||NoteFontSelectedLabel=音符の文字色(選択領域)||NoteFontFirstSelectedLabel=音符の文字色(選択トップ)||NoteFontDeselectedLabel=音符の文字色(通常)||MeasureBackgroundLabel=バック色||WhiteKeyLabel=白鍵色||fileToolStripMenuItem=ファイル(&F)||openSavedThemesListToolStripMenuItem=読み込む(&O)...||saveThemesListAsToolStripMenuItem=名前を付けて保存(&S)...||exitToolStripMenuItem=反映して閉じる(&Q)||themeToolStripMenuItem=テーマ(&T)||newToolStripMenuItem=新規作成(&N)...||duplicateToolStripMenuItem=複製(&C)||renameToolStripMenuItem=名前を変更(&M)...||deleteToolStripMenuItem=削除(&D)||initializeToolStripMenuItem=標準配色にする(&I)||languageToolStripMenuItem=言語(&L)||aboutToolStripMenuItem=UTAU Colours 2023について(&A)||PitchLinesCheckBox=ピッチカーブ線を見せる||[NewThemeName]||NewThemeName=新しいテーマの名前を入ってください||cancelButton=キャンセル(&C)||okButton=受け入る(&O)||ThemeNameTextbox=無題のテーマ||[About]||About=UTAU Colours 2023について||closeAboutButton=閉じる(&C)||aboutUC2023Label=UTAU Colours 2023は飴屋／菖蒲の作者に本物の%nutaucolorsプログラムに基づいています。%n%n翻訳／コードする／設計の作手：HowlingFoxRouko%nロゴのイラストと設計作者： Kotozaki||[Rename]||Rename=名前を変更||renNewNameLabel=テーマの新名前:||renCancelButton=キャンセル(&C)||renRenameButton=名前を変更する(&R)||[Dialog]||saveDialogText=設定が変わってきました。保存するが欲しいですか？||saveDialogTitle=変更設定を保存する通知||deleteDialogText=この行動はこのテーマとテーマのデータ値がを削除します。この行動の後で、元に戻するは出来ませんです。続くを願いますか？||deleteDialogTitle=削除する行動確認||initializeDialogText=この行動は選んでいますのテーマをUTAUの標準配色に戻しています。続くを願いますか？||initializeDialogTitle=標準配色にするの行動確認||overwriteThemeNameDialogText=入れたのテーマ名前は既に存在します。上書きするを願いますか？||overwriteThemeNameDialogTitle=上書き確認";
                File.WriteAllText("./lang/English.ini", EnglishIni.Replace("||", Environment.NewLine), Encoding.Default);
                File.WriteAllText("./lang/日本語.ini", JapaneseIni.Replace("||", Environment.NewLine), Encoding.Default);
            }
            if (!userSettings.KeyExists("ActiveLanguage", "Language"))
            {
                userSettings.Write("ActiveLanguage", "English", "Language");
            }
            // Get all the .ini files in the "lang" folder
            string[] files = Directory.GetFiles(System.IO.Path.Combine(Application.StartupPath, "lang"), "*.ini");
            // Loop through each file
            foreach (string file in files)
            {
                IniFile langINI = new IniFile(file);
                // Get the file name without extension
                string fileName = langINI.Read("languageName", "Language Settings");
                // Create a new menu item with the file name as text
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Text = fileName;
                // Add an event handler for the click event
                item.Click += new EventHandler(LanguageOption_Click);
                item.Tag = langINI.Read("tag", "Language Settings");

                // Add the menu item to the languageToolStripMenuItem.DropDownItems collection
                if (fileName == userSettings.Read("ActiveLanguage", "Language"))
                {

                    if (userSettings.KeyExists("ActiveLanguage", "Language"))
                    {
                        item.Checked = true;
                        currentLang = userSettings.Read("ActiveLanguage", "Language");
                    }
                    else
                    {
                        currentLang = "English";
                        userSettings.Write("ActiveLanguage", currentLang, "Language");
                        item.Checked = true;
                    }
                    CheckSelectedLanguageOption(languageToolStripMenuItem);
                }
                languageToolStripMenuItem.DropDownItems.Add(item);
            }
            userSettings.Write("ActiveLanguage", currentLang, "Language");
            string filePath = Path.Combine(Application.StartupPath, "lang", userSettings.Read("ActiveLanguage", "Language") + ".ini");
            IniFile langIni = new IniFile(filePath);
            foreach (Control c in this.Controls)
            {
                if (langIni.KeyExists(c.Name, this.Name))
                {
                    c.Text = langIni.Read(c.Name, this.Name);
                    c.Refresh();
                }
            }
            if (langIni.KeyExists(fileToolStripMenuItem.Name, this.Name))
            {
                fileToolStripMenuItem.Text = langIni.Read(fileToolStripMenuItem.Name, this.Name);
            }
            if (langIni.KeyExists(openSavedThemesListToolStripMenuItem.Name, this.Name))
            {
                openSavedThemesListToolStripMenuItem.Text = langIni.Read(openSavedThemesListToolStripMenuItem.Name, this.Name);
            }
            if (langIni.KeyExists(saveThemesListAsToolStripMenuItem.Name, this.Name))
            {
                saveThemesListAsToolStripMenuItem.Text = langIni.Read(saveThemesListAsToolStripMenuItem.Name, this.Name);
            }
            if (langIni.KeyExists(exitToolStripMenuItem.Name, this.Name))
            {
                exitToolStripMenuItem.Text = langIni.Read(exitToolStripMenuItem.Name, this.Name);
            }
            if (langIni.KeyExists(themeToolStripMenuItem.Name, this.Name))
            {
                themeToolStripMenuItem.Text = langIni.Read(themeToolStripMenuItem.Name, this.Name);
            }
            if (langIni.KeyExists(newToolStripMenuItem.Name, this.Name))
            {
                newToolStripMenuItem.Text = langIni.Read(newToolStripMenuItem.Name, this.Name);
            }
            if (langIni.KeyExists(duplicateToolStripMenuItem.Name, this.Name))
            {
                duplicateToolStripMenuItem.Text = langIni.Read(duplicateToolStripMenuItem.Name, this.Name);
            }
            if (langIni.KeyExists(renameToolStripMenuItem.Name, this.Name))
            {
                renameToolStripMenuItem.Text = langIni.Read(renameToolStripMenuItem.Name, this.Name);
            }
            if (langIni.KeyExists(deleteToolStripMenuItem.Name, this.Name))
            {
                deleteToolStripMenuItem.Text = langIni.Read(deleteToolStripMenuItem.Name, this.Name);
            }
            if (langIni.KeyExists(initializeToolStripMenuItem.Name, this.Name))
            {
                initializeToolStripMenuItem.Text = langIni.Read(initializeToolStripMenuItem.Name, this.Name);
            }
            if (langIni.KeyExists(languageToolStripMenuItem.Name, this.Name))
            {
                languageToolStripMenuItem.Text = langIni.Read(languageToolStripMenuItem.Name, this.Name);
            }
            if (langIni.KeyExists(aboutToolStripMenuItem.Name, this.Name))
            {
                aboutToolStripMenuItem.Text = langIni.Read(aboutToolStripMenuItem.Name, this.Name);
            }
            menuStrip1.Refresh();
            deleteDialogText = langIni.Read("deleteDialogText", "Dialog");
            deleteDialogTitle = langIni.Read("deleteDialogTitle", "Dialog");
            saveDialogText = langIni.Read("saveDialogText", "Dialog");
            saveDialogTitle = langIni.Read("saveDialogTitle", "Dialog");
            initializeDialogText = langIni.Read("initializeDialogText", "Dialog");
            initializeDialogTitle = langIni.Read("initializeDialogTitle", "Dialog");
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewThemeName newTheme = new NewThemeName();
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
            return new int[] { R, G, B };
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
        public bool inhibit = false;
        private void themesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            int currentIndex = themesListBox.SelectedIndex;
            if (TextWasChanged)
            {
                saveChanges(null, null);
                themesListBox.SetSelected(currentIndex, true);
                previousThemeIndex = currentIndex;
            }
            if (previousThemeIndex < 0)
            {
                previousThemeIndex = 0;
                themesListBox.SetSelected(previousThemeIndex, true);
            }
            if (currentIndex > themesListBox.Items.Count - 1)
            {
                currentIndex = themesListBox.Items.Count - 1;
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
            string filePath = System.IO.Path.Combine(Application.StartupPath, "lang", userSettings.Read("ActiveLangueage", "Language") + ".ini");
            IniFile langIni = new IniFile(filePath);
            if (MessageBox.Show(saveDialogText, saveDialogTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
            else
            {
                TextWasChanged = false;
            }
        }

        private void saveThemeListAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveThemeListDialog = new SaveFileDialog();
            saveThemeListDialog.Filter = "Text File|*.txt|All Files|*.*";
            saveThemeListDialog.Title = "Save Themes List...";

            if (saveThemeListDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveThemeListDialog.FileName != "")
                {
                    switch (saveThemeListDialog.FilterIndex)
                    {
                        case 1:
                            File.WriteAllText(saveThemeListDialog.FileName, "UTAU Colours 2023 Theme List - Exported From UTAU Colours 2023" + Environment.NewLine + File.ReadAllText("utaucolours2023.ini", Encoding.Default), Encoding.Default);
                            break;
                        case 2:
                            File.WriteAllText(saveThemeListDialog.FileName, "UTAU Colours 2023 Theme List - Exported From UTAU Colours 2023" + Environment.NewLine + File.ReadAllText("utaucolours2023.ini", Encoding.Default), Encoding.Default);
                            break;
                    }
                }
            }
        }

        private void openSavedThemesListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openThemeListDialog = new OpenFileDialog();
            openThemeListDialog.Filter = "Text File|*.txt";
            openThemeListDialog.Title = "Open Themes List...";

            if (openThemeListDialog.ShowDialog() == DialogResult.OK)
            {
                if (openThemeListDialog.FileName != "")
                {
                    string fileValidation = File.ReadAllText(openThemeListDialog.FileName);
                    if (!fileValidation.Contains("UTAU Colours 2023 Theme List - Exported From UTAU Colours 2023"))
                    {
                        MessageBox.Show("This is not a valid themes list. Please choose carefully.", "Invalid File");
                    }
                    else
                    {
                        File.WriteAllText("utaucolours2023.ini", File.ReadAllText(openThemeListDialog.FileName, Encoding.Default), Encoding.Default);
                        loadThemeList();
                        themesListBox.SetSelected(previousThemeIndex, true);
                    }
                    loadThemeList();
                    themesListBox.SetSelected(previousThemeIndex, true);
                }
                else
                {
                    return;
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int currentIndex = themesListBox.SelectedIndex;
            IniFile SettingsIni = new IniFile("utaucolours2023.ini");
            if (themesListBox.Items.Count > 1)
            {
                if (MessageBox.Show(deleteDialogText, deleteDialogTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
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
            string filePath = System.IO.Path.Combine(Application.StartupPath, "lang", userSettings.Read("ActiveLangueage", "Language") + ".ini");
            IniFile langIni = new IniFile(filePath);
            if (MessageBox.Show(initializeDialogText, initializeDialogTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
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
                loadThemeList();
                themesListBox.SelectedIndex = previousThemeIndex;

            }
            else
            {
                TextWasChanged = false;
            }
        }

        private void duplicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IniFile SettingsIni = new IniFile("utaucolours2023.ini");
            string[] sectionNames = SettingsIni.GetSectionNames();
            SettingsIni.Write("COLOR_PIANO1", "&H" + WhiteKeyTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " - Copy");
            SettingsIni.Write("COLOR_PIANO2", "&H" + BlackKeyTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " - Copy");
            SettingsIni.Write("COLOR_ROLL1", "&H" + PianoRollKeyWhiteTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " - Copy");
            SettingsIni.Write("COLOR_ROLL2", "&H" + PianoRollKeyBlackTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " - Copy");
            SettingsIni.Write("COLOR_SEPA1", "&H" + MeasureLineTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " - Copy");
            SettingsIni.Write("COLOR_SEPA2", "&H" + QuarterNoteLineTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " - Copy");
            SettingsIni.Write("COLOR_BACK", "&H" + MeasureBackgroundTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " - Copy");
            SettingsIni.Write("COLOR_FORE", "&H" + MeasureOctaveTextTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " - Copy");
            SettingsIni.Write("COLOR_SHADOW", "&H" + PianoRollNoteDividerTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " - Copy");
            SettingsIni.Write("COLOR_NOTE_NOR", "&H" + NoteDeselectedTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " - Copy");
            SettingsIni.Write("COLOR_NOTE_TOP", "&H" + NoteFirstSelectedTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " - Copy");
            SettingsIni.Write("COLOR_NOTE_SEL", "&H" + NoteSelectedTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " - Copy");
            SettingsIni.Write("COLOR_NOTE_TNOR", "&H" + NoteFontDeselectedTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " - Copy");
            SettingsIni.Write("COLOR_NOTE_TTOP", "&H" + NoteFontFirstSelectedTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " - Copy");
            SettingsIni.Write("COLOR_NOTE_TSEL", "&H" + NoteFontSelectedTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " - Copy");
            SettingsIni.Write("COLOR_NOTE_RNOR", "&H" + RestDeselectedTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " - Copy");
            SettingsIni.Write("COLOR_NOTE_RTOP", "&H" + RestFirstSelectedTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " - Copy");
            SettingsIni.Write("COLOR_NOTE_RSEL", "&H" + RestSelectedTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " - Copy");
            SettingsIni.Write("COLOR_PTCH_SEL", "&H" + PitchLineSelectedTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " - Copy");
            SettingsIni.Write("COLOR_PTCH_NOR", "&H" + PitchLineDeselectedTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " - Copy");
            SettingsIni.Write("COLOR_TEMPO_NOR", "&H" + TempoChangeTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " - Copy");
            SettingsIni.Write("COLOR_TEMPO_ALL", "&H" + TempoInitialTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " - Copy");
            if (TitlebarTextTextBox.Text != null)
            {
                SettingsIni.Write("TransformTitle", TitlebarTextTextBox.Text, themesListBox.GetItemText(themesListBox.SelectedItem) + " - Copy");
            }
            TextWasChanged = false;
            loadThemeList();
            themesListBox.SelectedIndex = previousThemeIndex;
        }

        private void generateSettingsIniButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveSettingsFileDialog = new SaveFileDialog();
            saveSettingsFileDialog.Filter = "setting.ini|*.ini";
            saveSettingsFileDialog.FileName = "setting.ini";
            saveSettingsFileDialog.InitialDirectory = "./";
            string[] settings = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
            settings[0] += "Tool1Path=./wavtool.exe";
            settings[1] += "Tool2Path=./resampler.exe";
            settings[2] += "COLOR_PIANO1=&H" + WhiteKeyTextBox.Text;
            settings[3] += "COLOR_PIANO2=&H" + BlackKeyTextBox.Text;
            settings[4] += "COLOR_ROLL1=&H" + PianoRollKeyWhiteTextBox.Text;
            settings[5] += "COLOR_ROLL2=&H" + PianoRollKeyBlackTextBox.Text;
            settings[6] += "COLOR_SEPA1=&H" + MeasureLineTextBox.Text;
            settings[7] += "COLOR_SEPA2=&H" + QuarterNoteLineTextBox.Text;
            settings[8] += "COLOR_BACK=&H" + MeasureBackgroundTextBox.Text;
            settings[9] += "COLOR_FORE=&H" + MeasureOctaveTextTextBox.Text;
            settings[10] += "COLOR_SHADOW=&H" + PianoRollNoteDividerTextBox.Text;
            settings[11] += "COLOR_NOTE_NOR=&H" + NoteDeselectedTextBox.Text;
            settings[12] += "COLOR_NOTE_TOP=&H" + NoteFirstSelectedTextBox.Text;
            settings[13] += "COLOR_NOTE_SEL=&H" + NoteSelectedTextBox.Text;
            settings[14] += "COLOR_NOTE_TNOR=&H" + NoteFontDeselectedTextBox.Text;
            settings[15] += "COLOR_NOTE_TTOP=&H" + NoteFontFirstSelectedTextBox.Text;
            settings[16] += "COLOR_NOTE_TSEL=&H" + NoteFontSelectedTextBox.Text;
            settings[17] += "COLOR_NOTE_RNOR=&H" + RestDeselectedTextBox.Text;
            settings[18] += "COLOR_NOTE_RTOP=&H" + RestFirstSelectedTextBox.Text;
            settings[19] += "COLOR_NOTE_RSEL=&H" + RestSelectedTextBox.Text;
            settings[20] += "COLOR_PTCH_SEL=&H" + PitchLineSelectedTextBox.Text;
            settings[21] += "COLOR_PTCH_NOR=&H" + PitchLineDeselectedTextBox.Text;
            settings[22] += "COLOR_TEMPO_NOR=&H" + TempoChangeTextBox.Text;
            settings[23] += "COLOR_TEMPO_ALL=&H" + TempoInitialTextBox.Text;
            settings[24] += "COLOR_PITCH_NOR=&H808080";
            settings[25] += "COLOR_SELECTBAR=&HC0C0C0";
            settings[26] += "COLOR_HILIGHT=&H00FFFF";
            settings[27] += "TransformTitle=" + TitlebarTextTextBox.Text;
            settings[28] += "MainWindow=562,211,956,574";
            settings[29] += "Mode2PBS=-40";
            settings[30] += "Mode2PBW=80";
            settings[31] += "MTCFrameRate=30";
            settings[32] += "SharpFlat=#";
            settings[33] += "CrossFadeAutoren=True";

            if (saveSettingsFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(saveSettingsFileDialog.FileName))
                {
                    string settingsBackup = File.ReadAllText(saveSettingsFileDialog.FileName, Encoding.Default);
                    File.WriteAllText("setting-backup.ini", settingsBackup, Encoding.Default);
                }
                string settingsIni = "";
                int i = 0;
                while (i < 33)
                {
                    settingsIni += settings[i] + Environment.NewLine;
                    i++;
                }
                File.WriteAllText(saveSettingsFileDialog.FileName, settingsIni, Encoding.Default);
                
            }
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rename rename = new Rename();
            if (rename.ShowDialog(this) == DialogResult.OK)
            {
                string iniFile = File.ReadAllText("utaucolours2023.ini", Encoding.Default);
                iniFile = iniFile.Replace(themesListBox.SelectedItem.ToString(), rename.newname);
                File.WriteAllText("utaucolours2023.ini", iniFile, Encoding.Default);
                loadThemeList();
                themesListBox.SetSelected(previousThemeIndex, true);
            }
        }

        private void WhiteKeyTextBox_Leave(object sender, EventArgs e)
        {
            if (TextWasChanged)
            {
                previewPictureBox.Image.Dispose();
                Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
                Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
                drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
                previewPictureBox.Image = bmp; // Displays the bitmap on the picture box
            }
        }

        private void BlackKeyTextBox_Leave(object sender, EventArgs e)
        {
            if (TextWasChanged)
            {
                previewPictureBox.Image.Dispose();
                Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
                Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
                drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
                previewPictureBox.Image = bmp; // Displays the bitmap on the picture box
            }
        }

        private void PianoRollKeyWhiteTextBox_Leave(object sender, EventArgs e)
        {
            previewPictureBox.Image.Dispose();
            Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
            Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
            drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
            previewPictureBox.Image = bmp; // Displays the bitmap on the picture box
        }

        private void PianoRollKeyBlackTextBox_Leave(object sender, EventArgs e)
        {
            previewPictureBox.Image.Dispose();
            Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
            Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
            drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
            previewPictureBox.Image = bmp; // Displays the bitmap on the picture box
        }

        private void MeasureLineTextBox_Leave(object sender, EventArgs e)
        {
            previewPictureBox.Image.Dispose();
            Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
            Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
            drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
            previewPictureBox.Image = bmp; // Displays the bitmap on the picture box
        }

        private void QuarterNoteLineTextBox_Leave(object sender, EventArgs e)
        {
            previewPictureBox.Image.Dispose();
            Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
            Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
            drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
            previewPictureBox.Image = bmp; // Displays the bitmap on the picture box
        }

        private void TempoInitialTextBox_Leave(object sender, EventArgs e)
        {
            previewPictureBox.Image.Dispose();
            Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
            Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
            drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
            previewPictureBox.Image = bmp; // Displays the bitmap on the picture box
        }

        private void TempoChangeTextBox_Leave(object sender, EventArgs e)
        {
            previewPictureBox.Image.Dispose();
            Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
            Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
            drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
            previewPictureBox.Image = bmp; // Displays the bitmap on the picture box

        }

        private void MeasureBackgroundTextBox_Leave(object sender, EventArgs e)
        {
            previewPictureBox.Image.Dispose();
            Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
            Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
            drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
            previewPictureBox.Image = bmp; // Displays the bitmap on the picture box

        }

        private void MeasureOctaveTextTextBox_Leave(object sender, EventArgs e)
        {
            previewPictureBox.Image.Dispose();
            Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
            Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
            drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
            previewPictureBox.Image = bmp; // Displays the bitmap on the picture box

        }

        private void PianoRollNoteDividerTextBox_Leave(object sender, EventArgs e)
        {
            previewPictureBox.Image.Dispose();
            Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
            Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
            drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
            previewPictureBox.Image = bmp; // Displays the bitmap on the picture box

        }

        private void NoteDeselectedTextBox_Leave(object sender, EventArgs e)
        {
            previewPictureBox.Image.Dispose();
            Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
            Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
            drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
            previewPictureBox.Image = bmp; // Displays the bitmap on the picture box
        }

        private void NoteFirstSelectedTextBox_Leave(object sender, EventArgs e)
        {
            previewPictureBox.Image.Dispose();
            Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
            Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
            drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
            previewPictureBox.Image = bmp; // Displays the bitmap on the picture box
        }

        private void NoteSelectedTextBox_Layout(object sender, LayoutEventArgs e)
        {
            previewPictureBox.Image.Dispose();
            Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
            Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
            drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
            previewPictureBox.Image = bmp; // Displays the bitmap on the picture box
        }

        private void PitchLineDeselectedTextBox_Leave(object sender, EventArgs e)
        {
            previewPictureBox.Image.Dispose();
            Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
            Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
            drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
            previewPictureBox.Image = bmp; // Displays the bitmap on the picture box
        }

        private void NoteFontDeselectedTextBox_Leave(object sender, EventArgs e)
        {
            previewPictureBox.Image.Dispose();
            Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
            Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
            drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
            previewPictureBox.Image = bmp; // Displays the bitmap on the picture box
        }

        private void NoteFontFirstSelectedTextBox_Leave(object sender, EventArgs e)
        {
            previewPictureBox.Image.Dispose();
            Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
            Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
            drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
            previewPictureBox.Image = bmp; // Displays the bitmap on the picture box
        }

        private void NoteFontSelectedTextBox_Leave(object sender, EventArgs e)
        {
            previewPictureBox.Image.Dispose();
            Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
            Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
            drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
            previewPictureBox.Image = bmp; // Displays the bitmap on the picture box
        }

        private void RestDeselectedTextBox_Leave(object sender, EventArgs e)
        {
            previewPictureBox.Image.Dispose();
            Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
            Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
            drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
            previewPictureBox.Image = bmp; // Displays the bitmap on the picture box
        }

        private void RestFirstSelectedTextBox_Leave(object sender, EventArgs e)
        {
            previewPictureBox.Image.Dispose();
            Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
            Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
            drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
            previewPictureBox.Image = bmp; // Displays the bitmap on the picture box
        }

        private void RestSelectedTextBox_Leave(object sender, EventArgs e)
        {
            previewPictureBox.Image.Dispose();
            Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
            Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
            drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
            previewPictureBox.Image = bmp; // Displays the bitmap on the picture box
        }

        private void PitchLineSelectedTextBox_Leave(object sender, EventArgs e)
        {
            previewPictureBox.Image.Dispose();
            Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
            Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
            drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
            previewPictureBox.Image = bmp; // Displays the bitmap on the picture box
        }

        private void PitchLinesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            previewPictureBox.Image.Dispose();
            Bitmap bmp = new Bitmap(489, 241); // Creates a blank image of 489x241 pixels
            Graphics g = Graphics.FromImage(bmp); // Creates a graphics object from the bitmap
            drawPreview(g); // Draws a rectangle with text and border on the bitmap using the function
            previewPictureBox.Image = bmp; // Displays the bitmap on the picture box
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (TextWasChanged)
            {
                saveChanges(null, null);
                TextWasChanged = false;
            }
        }

        private void CheckSelectedLanguageOption(object sender)
        { // Loop through the languageToolStripMenuItem’s DropDownItems collection
            foreach (ToolStripItem item in languageToolStripMenuItem.DropDownItems)
            { // Cast the item to a ToolStripMenuItem
                ToolStripMenuItem menuItem = item as ToolStripMenuItem;

                // Check if the menuItem is not null
                if (menuItem != null)
                {
                    // Check if the menuItem is the same as the sender object
                    if (menuItem == sender)
                    {
                        // Set the menuItem's Checked property to true
                        menuItem.Checked = true;
                    }
                    else
                    {
                        // Set the menuItem's Checked property to false
                        menuItem.Checked = false;
                    }
                }
            }
        }
        // This method will handle the Click event of each language option
        private void LanguageOption_Click(object sender, EventArgs e)
        {
            // Cast the sender object to a ToolStripMenuItem
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            // Check if the item is not null
            if (item != null)
            {
                // Get the text of the item, which is the file name
                string fileName = item.Text;
                // Do something with the file name, such as loading the .ini file
                // or changing the language of the application
                // ...

                // Note: You need to use the correct path of the .ini file, which is in the "lang" folder
                string filePath = System.IO.Path.Combine(Application.StartupPath, "lang", fileName + ".ini");
                IniFile langINI = new IniFile(filePath);
                item.Name = langINI.Read("languageName", "LanguageSettings");
                item.Tag = langINI.Read("languageTag", "LanguageSettings");
                if (currentLang != "")
                {
                    currentLang.Replace(currentLang, item.Text);
                    userSettings.Write("ActiveLanguage", item.Text, "Language");
                }
                else
                {
                    currentLang = item.Text;
                    userSettings.Write("ActiveLanguage", item.Text, "Language");
                }
                foreach (Control c in this.Controls)
                {
                    if (langINI.KeyExists(c.Name, this.Name))
                    {
                        c.Text = langINI.Read(c.Name, this.Name);
                        c.Refresh();
                    }
                }
                if (langINI.KeyExists(fileToolStripMenuItem.Name, this.Name))
                {
                    fileToolStripMenuItem.Text = langINI.Read(fileToolStripMenuItem.Name, this.Name);
                }
                if (langINI.KeyExists(openSavedThemesListToolStripMenuItem.Name, this.Name))
                {
                    openSavedThemesListToolStripMenuItem.Text = langINI.Read(openSavedThemesListToolStripMenuItem.Name, this.Name);
                }
                if (langINI.KeyExists(saveThemesListAsToolStripMenuItem.Name, this.Name))
                {
                    saveThemesListAsToolStripMenuItem.Text = langINI.Read(saveThemesListAsToolStripMenuItem.Name, this.Name);
                }
                if (langINI.KeyExists(exitToolStripMenuItem.Name, this.Name))
                {
                    exitToolStripMenuItem.Text = langINI.Read(exitToolStripMenuItem.Name, this.Name);
                }
                if (langINI.KeyExists(themeToolStripMenuItem.Name, this.Name))
                {
                    themeToolStripMenuItem.Text = langINI.Read(themeToolStripMenuItem.Name, this.Name);
                }
                if (langINI.KeyExists(newToolStripMenuItem.Name, this.Name))
                {
                    newToolStripMenuItem.Text = langINI.Read(newToolStripMenuItem.Name, this.Name);
                }
                if (langINI.KeyExists(duplicateToolStripMenuItem.Name, this.Name))
                {
                    duplicateToolStripMenuItem.Text = langINI.Read(duplicateToolStripMenuItem.Name, this.Name);
                }
                if (langINI.KeyExists(renameToolStripMenuItem.Name, this.Name))
                {
                    renameToolStripMenuItem.Text = langINI.Read(renameToolStripMenuItem.Name, this.Name);
                }
                if (langINI.KeyExists(deleteToolStripMenuItem.Name, this.Name))
                {
                    deleteToolStripMenuItem.Text = langINI.Read(deleteToolStripMenuItem.Name, this.Name);
                }
                if (langINI.KeyExists(initializeToolStripMenuItem.Name, this.Name))
                {
                    initializeToolStripMenuItem.Text = langINI.Read(initializeToolStripMenuItem.Name, this.Name);
                }
                if (langINI.KeyExists(languageToolStripMenuItem.Name, this.Name))
                {
                    languageToolStripMenuItem.Text = langINI.Read(languageToolStripMenuItem.Name, this.Name);
                }
                if (langINI.KeyExists(aboutToolStripMenuItem.Name, this.Name))
                {
                    aboutToolStripMenuItem.Text = langINI.Read(aboutToolStripMenuItem.Name, this.Name);
                }
                if (langINI.KeyExists("deleteDialogText", "Dialog"))
                {
                    deleteDialogText = deleteDialogText.Replace(deleteDialogText, langINI.Read("deleteDialogText", "Dialog"));
                }
                if (langINI.KeyExists("deleteDialogTitle", "Dialog"))
                {
                    deleteDialogTitle = deleteDialogTitle.Replace(deleteDialogTitle, langINI.Read("deleteDialogTitle", "Dialog"));
                }
                if (langINI.KeyExists("saveDialogText", "Dialog"))
                {
                    saveDialogText = saveDialogText.Replace(saveDialogText, langINI.Read("saveDialogText", "Dialog"));
                }
                if (langINI.KeyExists("saveDialogTitle", "Dialog"))
                {
                    saveDialogTitle = saveDialogTitle.Replace(saveDialogTitle, langINI.Read("saveDialogTitle", "Dialog"));
                }
                if (langINI.KeyExists("initializeDialogText", "Dialog"))
                {
                    initializeDialogText = initializeDialogText.Replace(initializeDialogText, langINI.Read("initializeDialogText", "Dialog"));
                }
                if (langINI.KeyExists("initializeDialogTitle", "Dialog"))
                {
                    initializeDialogTitle = initializeDialogTitle.Replace(initializeDialogTitle, langINI.Read("initializeDialogTitle", "Dialog"));
                }
                menuStrip1.Refresh();
                // Call the CheckSelectedLanguageOption method to make sure only one sub-menu item is selected
                CheckSelectedLanguageOption(sender);

            }
        }
    }
}
