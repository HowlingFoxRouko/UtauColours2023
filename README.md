
# UTAU Colours 2023

utaucolors.exe was originally a program by 飴屋／菖蒲 (AmeyaP) which allowed customization of themes in UTAU歌声合成ツール. While the original is still available for download, there were some areas that could be improved upon as well as quality of life improvements to be made.

About a week ago or so, I, HowlingFoxRouko, took it upon myself to make this update. This is not just a recreation of the original by AmeyaP; it's an improvement on the original concept.

I have also decided to include the original themes that AmeyaP has provided, as well as one for my own UTAU, ROUKOPOID. There's also a joke theme just for fun.

Fair warning: This is my first C# program, but not my first time programming. Stuff's probably gonna break, but it does the thing. It even saves a backup of your setting.ini to its own folder. If something breaks, let me know either through Discord (HowlingFoxRouko), BlueSky (@howlingfoxsrouko.bsky.social), Twitter/X (@HowlingFoxRouko) or through the contact form of my website: https://howlingfoxstudios.xyz/

## How To Use

The usage is pretty straightforward. Use the "..." buttons to open a colour-selection dialog box, pick your colours, and watch as the preview image updates in real time to reflect your changes. When you're done, you can press the `Generate UTAU Settings.ini` button to generate a base Setting.ini

### Create a New theme

From the `Theme` Menu, select `New` to enter a new theme name. From here, it will be added to the themes list with the initial colour scheme of UTAU歌声合成ツール. If you have changes that need to be saved on your current theme, you'll be asked to save before continuing.

### Rename a theme

From the `Theme` Menu, select `Rename` to receive a prompt for a new name for the currently selected theme.

### Saving your changes

To save changes to your current theme, select another theme and when prompted, select "Yes".

**Note:** If you select "No", then even if it was an accidental click off of the current theme, you will lose your changes. I tried to get a cancel button to work, but it did not want to participate. Sorry!!
## Installation

From the **Releases** section to the right, download the latest release of UTAU_Colours_2023.zip and unzip to your preferred destination. At this time, only Windows machines are supported, but compatibility for Mac and Linux will be considered in future releases.
## Adding Languages

In order to make this software as simple as possible, I have opted for the usage of `.ini` Files to store label information. The included languages are English and Japanese. 

If you ever make a change to the English or Japanese `.ini` files and want to re-generate the original, delete the `lang` folder and run the program again. This will restore those files in-code.

Below is a copy of `English.ini` which you can use as a template to use to add your own language, but please note that the labels on the form are a set length. If you add too much text, it can make things look odd. **In order for UC2023 to recognize the language, the name of the `.ini` file *MUST* match the `languageName` value**

If you complete a language `.ini` file, you can feel free to either send to me directly through above contact methods for implementation in future versions!

```
[Language Settings]
languageName=English
languageTag=en-US
[UtauColoursMain]
generateSettingsIniButton=&Generate UTAU setting.ini
TitlebarTextLabel=Titlebar Text:
TempoChangeLabel=Tempo Change Colour
InitialTempoLabel=Initial Tempo Colour
QuarterNoteLineLabel=Quarter Note Line Colour
MeasureLineLabel=Measure Line Colour
PianoRollKeyBlackLabel=Piano Roll Key Colour (Black)
PianoRollKeyWhiteLabel=Piano Roll Key Colour (White)
BlackKeyLabel=Black Key Colour
PitchLineSelectedLabel=Pitch Line Colour (Selection)
RestSelectedLabel=Rest Colour (Selection)
PitchLineDeselectedLabel=Pitch Line Colour (Deselected)
NoteSelectedLabel=Note Colour (Selection)
RestFirstOfSelectedLabel=Rest Colour (First of Selection)
NoteFirstSelectedLabel=Note Colour (First of Selection)
RestDeselectedLabel=Rest Colour (Deselected)
NoteDeselectedLabel=Note Colour (Deselected)
PianoRollNoteDividerLabel=Piano Roll Note Divider Colour
MeasureOctaveTextLabel=Measure/Octave Text Colour
NoteFontSelectedLabel=Note Font Colour (Selected)
NoteFontFirstSelectedLabel=Note Font Colour (First Selected)
NoteFontDeselectedLabel=Note Font Colour (Deselected)
MeasureBackgroundLabel=Measure Background Colour
WhiteKeyLabel=White Key Colour
fileToolStripMenuItem=&File
openSavedThemesListToolStripMenuItem=&Open Saved Themes List...
saveThemesListAsToolStripMenuItem=&Save Theme List As...
exitToolStripMenuItem=E&xit
themeToolStripMenuItem=&Theme
newToolStripMenuItem=&New
duplicateToolStripMenuItem=D&uplicate
renameToolStripMenuItem=Rena&me
deleteToolStripMenuItem=&Delete
initializeToolStripMenuItem=&Initialize
languageToolStripMenuItem=&Language
aboutToolStripMenuItem=&About
PitchLinesCheckBox=Show Pitch Lines
[NewThemeName]
NewThemeName=Name Your Theme
cancelButton=&Cancel
okButton=&Ok
ThemeNameTextbox=Untitled
[About]
About=About
closeAboutButton=&Close
aboutUC2023Label=UTAU Colours 2023 is based%non the original utaucolors program%nby Ameya-P%n%nTranslation, Coding, and Design by HowlingFoxRouko%nIcon by Kotozaki
[Rename]
Rename=Rename
renNewNameLabel=New Theme Name:
renCancelButton=&Cancel
renRenameButton=&Rename
[Dialog]
saveDialogText=You have unsaved changes to the current theme. Save?
saveDialogTitle=Save?
deleteDialogText=This will remove this theme entirely and its values will be lost. This cannot be undone. Do you want to continue?
deleteDialogTitle=Delete
initializeDialogText=You are about to reset the current theme back to the original UTAU settings. Do you wish to continue?
initializeDialogTitle=Initialize
overwriteThemeNameDialogText=This theme already exists. Overwrite?
overwriteThemeNameDialogTitle=Overwrite?
```
