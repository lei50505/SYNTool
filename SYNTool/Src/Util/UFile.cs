using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SYNTool.Src.Util
{
    public static class UFile
    {
        public static string getDriverName(string path)
        {
            return path.Substring(0, 1);
        }
        public static string getLastDir(string path)
        {
            string[] dirs = null;
            dirs = path.Split('\\');
            return dirs[dirs.Length - 1];
        }
        private static void getFiles(string path, ref List<string> files)
        {
            string[] fs = Directory.GetFiles(path);
            foreach (string f in fs)
            {
                files.Add(f);
            }
            string[] ds = Directory.GetDirectories(path);
            foreach (string d in ds)
            {
                getFiles(d, ref files);
            }
        }
        public static List<string> getFiles(string path)
        {
            List<string> files = new List<string>();
            List<string> referrors = new List<string>();
            getFiles(path, ref files);
            return files;
        }
        private static void getDirs(string path, ref List<string> dirs)
        {
            string[] ds = Directory.GetDirectories(path);
            foreach (string d in ds)
            {
                getDirs(d, ref dirs);
                dirs.Add(d);
            }
        }
        public static List<string> getDirs(string path)
        {
            List<string> dirs = new List<string>();
            List<string> referrors = new List<string>();
            getDirs(path, ref dirs);

            return dirs;
        }
        public static bool copyDir(string oldDir, string oldPath, string newPath)
        {
            string newDir = newPath + oldDir.Substring(oldPath.Length);
            if (!Directory.Exists(newDir))
            {
                Directory.CreateDirectory(newDir);
                return true;
            }
            return false;
        }
        private static bool compareFiles(string oldFile, string newFile)
        {
            int oldYear = File.GetLastWriteTime(oldFile).Year;
            int newYear = File.GetLastWriteTime(newFile).Year;
            int oldMonth = File.GetLastWriteTime(oldFile).Month;
            int newMonth = File.GetLastWriteTime(newFile).Month;
            int oldDay = File.GetLastWriteTime(oldFile).Day;
            int newDay = File.GetLastWriteTime(newFile).Day;
            int oldHour = File.GetLastWriteTime(oldFile).Hour;
            int newHour = File.GetLastWriteTime(newFile).Hour;
            int oldMinute = File.GetLastWriteTime(oldFile).Minute;
            int newMinute = File.GetLastWriteTime(newFile).Minute;
            int oldSecond = File.GetLastWriteTime(oldFile).Second;
            int newSecond = File.GetLastWriteTime(newFile).Second;
            int oldTime = oldSecond + (oldMinute * 60) + (oldHour * 60 * 60) + (oldDay * 24 * 60 * 60);
            int newTime = newSecond + (newMinute * 60) + (newHour * 60 * 60) + (newDay * 24 * 60 * 60);
            int time = oldTime - newTime;
            if (oldYear == newYear)
            {
                if (oldMonth == newMonth)
                {
                    if (time > -5 && time < 5)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private static long getFileSize(string file)
        {
            long fileSize = 0;
            FileInfo fileInfo = new FileInfo(file);
            fileSize = fileInfo.Length;
            return fileSize;
        }

        public static bool copyFile(string oldFile, string oldPath, string newPath, ref List<string> errors)
        {
            string newFile = newPath + oldFile.Substring(oldPath.Length);
            if (File.Exists(newFile))
            {
                if (!(compareFiles(oldFile, newFile) && getFileSize(oldFile) == getFileSize(newFile)))
                {
                    FileSystem.DeleteFile(newFile, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                    File.Copy(oldFile, newFile, true);
                    return true;
                }
            }
            else
            {
                File.Copy(oldFile, newFile, true);
                return true;
            }
            return false;
        }
        public static bool delFile(string newFile, string oldPath, string newPath, ref List<string> errors)
        {
            string oldFile = oldPath + newFile.Substring(newPath.Length);
            if (!File.Exists(oldFile))
            {
                FileSystem.DeleteFile(newFile, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                File.Delete(newFile);
                return true;
            }
            return false;
        }
        public static bool delDir(string newDir, string oldPath, string newPath, ref List<string> errors)
        {
            string oldDir = oldPath + newDir.Substring(newPath.Length);
            if (!Directory.Exists(oldDir))
            {
                FileSystem.DeleteDirectory(newDir, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                return true;
            }
            return false;
        }

    }
}
