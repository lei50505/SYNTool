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
        public static string GetDriverByPath(string path)
        {
            return path.Substring(0, 1);
        }
        public static string GetLastDirByDirPath(string dirPath)
        {
            string[] dirs = null;
            dirs = dirPath.Split('\\');
            return dirs[dirs.Length - 1];
        }
        private static void GetSubFilePaths(string rootDirPath, ref List<string> subFilePaths)
        {
            string[] fs = Directory.GetFiles(rootDirPath);
            foreach (string f in fs)
            {
                subFilePaths.Add(f);
            }
            string[] ds = Directory.GetDirectories(rootDirPath);
            foreach (string d in ds)
            {
                GetSubFilePaths(d, ref subFilePaths);
            }
        }
        public static List<string> GetSubFilePaths(List<string> rootDirPaths)
        {
            List<string> subFilePaths = new List<string>();
            foreach (string rootDirPath in rootDirPaths)
            {
                GetSubFilePaths(rootDirPath, ref subFilePaths);
            }
            return subFilePaths;
        }
        public static List<string> GetSubFilePaths(string rootDirPath)
        {
            List<string> subFilePaths = new List<string>();
            GetSubFilePaths(rootDirPath, ref subFilePaths);
            return subFilePaths;
        }
        private static void GetDirPaths(string dirPath, ref List<string> dirPaths)
        {
            string[] ds = Directory.GetDirectories(dirPath);
            foreach (string d in ds)
            {
                GetDirPaths(d, ref dirPaths);
                dirPaths.Add(d);
            }
        }
        public static List<string> GetSubDirPaths(List<string> rootDirPaths)
        {
            List<string> subDirPaths = new List<string>();
            foreach (string rootDirPath in rootDirPaths)
            {
                GetDirPaths(rootDirPath, ref subDirPaths);
            }
            return subDirPaths;
        }
        public static List<string> GetSubDirPaths(string rootDirPath)
        {
            List<string> subDirPaths = new List<string>();
            GetDirPaths(rootDirPath, ref subDirPaths);
            return subDirPaths;
        }
        public static bool CopyDir(string oldDirPath, string oldRootPath, string newRootPath)
        {
            string newDirPath = newRootPath + oldDirPath.Substring(oldRootPath.Length);
            if (!Directory.Exists(newDirPath))
            {
                Directory.CreateDirectory(newDirPath);
                return true;
            }
            return false;
        }
        private static bool FilesLastWriteTimeEqual(string oldFile, string newFile)
        {
            long oldSeconds = File.GetLastWriteTime(oldFile).Ticks/10000000L;
            long newSeconds = File.GetLastWriteTime(newFile).Ticks/10000000L;
            if (oldSeconds - newSeconds > 5L || oldSeconds - newSeconds < -5L )
            {
                return false;
            }
            return true;
        }
        private static long GetFileBytes(string file)
        {
            long fileSize = 0;
            FileInfo fileInfo = new FileInfo(file);
            fileSize = fileInfo.Length;
            return fileSize;
        }

        public static bool CopyFile(string oldFilePath, string oldRootDirPath, string newRootDirPath)
        {
            string newFilePath = newRootDirPath + oldFilePath.Substring(oldRootDirPath.Length);
            if (File.Exists(newFilePath))
            {
                if (!(FilesLastWriteTimeEqual(oldFilePath, newFilePath) && GetFileBytes(oldFilePath) == GetFileBytes(newFilePath)))
                {
                    FileSystem.DeleteFile(newFilePath, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                    File.Copy(oldFilePath, newFilePath, true);
                    return true;
                }
            }
            else
            {
                File.Copy(oldFilePath, newFilePath, true);
                return true;
            }
            return false;
        }
        public static bool DelFile(string newFilePath, string oldRootDirPath, string newRootDirPath)
        {
            string oldFilePath = oldRootDirPath + newFilePath.Substring(newRootDirPath.Length);
            if (!File.Exists(oldFilePath))
            {
                FileSystem.DeleteFile(newFilePath, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                return true;
            }
            return false;
        }
        public static bool DelDir(string newDirPath, string oldRootDirPath, string newRootDirPath)
        {
            string oldDirPath = oldRootDirPath + newDirPath.Substring(newRootDirPath.Length);
            if (!Directory.Exists(oldDirPath))
            {
                FileSystem.DeleteDirectory(newDirPath, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                return true;
            }
            return false;
        }

    }
}
