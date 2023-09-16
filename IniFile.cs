using System.Collections.Generic;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

// Change this to match your program's normal namespace
namespace MyProg
{
    class IniFile   // revision 11
    {
        string Path;
        string EXE = Assembly.GetExecutingAssembly().GetName().Name;

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

        public IniFile(string IniPath = null)
        {
            Path = new FileInfo(IniPath ?? EXE + ".ini").FullName;
        }

        // A function that returns an array of section names in the INI file
        public string[] GetSectionNames()
        {
            string IniPath = null;
            string path = new FileInfo(IniPath ?? EXE + ".ini").FullName;
            // Check the validity of the file path and the existence of the file
            if (string.IsNullOrEmpty(path)) throw new ArgumentNullException("path");
            if (!File.Exists(path)) return new string[0];

            // Create a list to store the section names
            List<string> sections = new List<string>();

            // Read all the lines from the file
            string[] lines = File.ReadAllLines(path, Encoding.Default);

            // Loop through each line
            foreach (string line in lines)
            {
                // Trim any whitespace from the line
                string trimmedLine = line.Trim();

                // Check if the line is a section header
                if (trimmedLine.StartsWith("[") && trimmedLine.EndsWith("]"))
                {
                    // Remove the brackets and add the section name to the list
                    string sectionName = trimmedLine.Substring(1, trimmedLine.Length - 2);
                    sections.Add(sectionName);
                }
            }

            // Return the array of section names
            return sections.ToArray();
        }

        public string Read(string Key, string Section = null)
        {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section ?? EXE, Key, "", RetVal, 255, Path);
            return RetVal.ToString();
        }

        public void Write(string Key, string Value, string Section = null)
        {
            WritePrivateProfileString(Section ?? EXE, Key, Value, Path);
        }

        public void DeleteKey(string Key, string Section = null)
        {
            Write(Key, null, Section ?? EXE);
        }

        public void DeleteSection(string Section = null)
        {
            Write(null, null, Section ?? EXE);
        }

        public bool KeyExists(string Key, string Section = null)
        {
            return Read(Key, Section).Length > 0;
        }
    }
}