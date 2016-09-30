using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SYNTool.Src.Util
{
    public static class UConfig
    {
        private static void writeConfig(string name, string value)
        {
            string filePath = Directory.GetCurrentDirectory() + "/conf.txt";
            if (!File.Exists(filePath))
            {
                StreamWriter sw = new StreamWriter(filePath);
                sw.Close();
            }
            if (File.Exists(filePath))
            {
                string[] lines = null;
                lines = File.ReadAllLines(filePath);
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Split(':')[0] == name)
                    {
                        lines[i] = lines[i].Split(':')[0] + ':' + value;
                        File.WriteAllLines(filePath, lines);
                        return;
                    }
                }
                string[] newLines = new string[lines.Length + 1];
                for (int i = 0; i < lines.Length; i++)
                {
                    newLines[i] = lines[i];
                }
                newLines[lines.Length] = name + ':' + value;
                File.WriteAllLines(filePath, newLines);
                return;
            }
        }

        private static string readConfig(string name)
        {
            string filePath = Directory.GetCurrentDirectory() + "/conf.txt";
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Split(':')[0] == name)
                    {
                        return lines[i].Split(':')[1];
                    }
                }
            }
            return null;
        }
        public static bool writeAll(string comboName, string oldPath, string newPath)
        {
            string filePath = Directory.GetCurrentDirectory() + "/conf.txt";
            if (!File.Exists(filePath))
            {
                StreamWriter sw = new StreamWriter(filePath);
                sw.Close();
            }
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                for (int i = 0; i < lines.Length; i += 3)
                {
                    if (lines[i] == "comboName?" + comboName)
                    {
                        return false;
                    }
                }
                string[] newLines = new string[lines.Length + 3];
                for (int i = 0; i < lines.Length; i++)
                {
                    newLines[i] = lines[i];

                }
                newLines[lines.Length] = "comboName" + '?' + comboName;
                newLines[lines.Length + 1] = oldPath;
                newLines[lines.Length + 2] = newPath;
                File.WriteAllLines(filePath, newLines);
                return true;
            }
            return false;
        }
        public static string[] readAll(string comboName)
        {
            string[] r = null;
            string filePath = Directory.GetCurrentDirectory() + "/conf.txt";
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                for (int i = 0; i < lines.Length; i += 3)
                {
                    if (lines[i] == "comboName?" + comboName)
                    {
                        r = new string[2];
                        r[0] = lines[i + 1];
                        r[1] = lines[i + 2];
                        return r;
                    }
                }
            }
            return null;
        }
        public static string[] GetAllLines()
        {
            string filePath = Directory.GetCurrentDirectory() + "/conf.txt";
            if (File.Exists(filePath))
            {
                return File.ReadAllLines(filePath);
            }
            return null;
        }
        public static List<string> readComboName()
        {
            List<string> r = new List<string>();
            string filePath = Directory.GetCurrentDirectory() + "/conf.txt";
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                for (int i = 0; i < lines.Length; i += 3)
                {
                    string temp = lines[i].Split('?')[1];
                    r.Add(temp);
                }
            }
            return r;

        }
        public static bool delete(string comboName)
        {
            string filePath = Directory.GetCurrentDirectory() + "/conf.txt";
            if (!File.Exists(filePath))
            {
                return false;
            }
            string[] lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i = i + 3)
            {
                string temp = lines[i].Split('?')[1];
                if (temp != comboName)
                {
                    continue;
                }
                if (lines.Length == 3)
                {
                    File.Delete(filePath);
                    return true;
                }
                string[] newLines = new string[lines.Length - 3];
                if (i < lines.Length - 3)
                {
                    for (int ii = 0; ii < i; ii++)
                    {
                        newLines[ii] = lines[ii];
                    }
                    for (int iii = i; iii < newLines.Length; iii++)
                    {
                        newLines[iii] = lines[iii + 3];
                    }
                    File.WriteAllLines(filePath, newLines);
                    return true;
                }
                else
                {
                    for (int ii = 0; ii < i; ii++)
                    {
                        newLines[ii] = lines[ii];
                    }
                    File.WriteAllLines(filePath, newLines);
                    return true;
                }
            }
            return false;
        }
    }
}
