using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOService
{
    public static class FileService
    {
        public static bool CopyFile(string NewFolderPath,string OrigneFolderPath,string FileName,out string ExeptionMessage)
        {
            ExeptionMessage = string.Empty;
            try
            {
                string SourceFile, TargetFile;
                PathCombining(NewFolderPath, OrigneFolderPath, FileName, out SourceFile, out TargetFile);
                if (!Directory.Exists(NewFolderPath))
                {
                    Directory.CreateDirectory(NewFolderPath);
                }
                else
                {
                    ExeptionMessage = "Folder is not exist!";
                }
                File.Copy(SourceFile, TargetFile, true);
                return true;
            }
            catch (Exception ex)
            {
               ExeptionMessage= $"Exption: {ex.Message}";
                return false;
            }
        }

        private static void PathCombining(string NewFolderPath, string OrigneFolderPath, string FileName, out string SourceFile, out string TargetFile)
        {
            SourceFile = Path.Combine(OrigneFolderPath, FileName);
            TargetFile = Path.Combine(NewFolderPath, FileName);
        }

        public static bool CutFile(string NewFolderPath, string OrigneFolderPath, string FileName, out string ExeptionMessage)
        {
            ExeptionMessage = string.Empty;
            try
            {
                string SourceFile, TargetFile;
                PathCombining(NewFolderPath, OrigneFolderPath, FileName, out SourceFile, out TargetFile);

                if (!Directory.Exists(NewFolderPath))
                {
                    Directory.CreateDirectory(NewFolderPath);
                }
                else
                {
                    ExeptionMessage = "File has been Moved successfully";
                }
                File.Move(SourceFile, TargetFile, true);
                return true;
            }
            catch (Exception ex)
            {
               ExeptionMessage= $"Exption: {ex.Message}";
                return false;
            }
        }
        public static bool DeleteFile(string OrigneFolderPath, string FileName, out string ExeptionMessage)
        {
            ExeptionMessage = string.Empty;
            try
            {
                string SourceFile = Path.Combine(OrigneFolderPath, FileName);
                File.Delete(SourceFile);
                return true;
            }
            catch (Exception ex)
            {
                ExeptionMessage=$"Exption: {ex.Message}";
                return false;
            }
        }
    }
}
