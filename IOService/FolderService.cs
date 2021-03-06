using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOService
{
    public static class FolderService
    {
        public static bool CopyToFolder(string OrginalFolderPath, string TargetFolderPath, out string ExceptionMassage)
        {
            ExceptionMassage = string.Empty;
            try
            {
                if (!Directory.Exists(TargetFolderPath))
                {
                    Directory.CreateDirectory(TargetFolderPath);
                }
                foreach (string filePath in Directory.GetFiles(OrginalFolderPath))
                {
                    try
                    {
                        string destFileName = Path.Combine(TargetFolderPath, Path.GetFileName(filePath));
                        File.Copy(filePath, destFileName);
                    }
                    catch (Exception ex)
                    {
                        ExceptionMassage = ex.Message;
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                ExceptionMassage = ex.Message;
                return false;
            }
        }
        public static bool CutFromFolder(string OrginalFolderPath, string TargetFolderPath, out string ExceptionMassage)
        {
            ExceptionMassage = string.Empty;
            try
            {
                if (!Directory.Exists(TargetFolderPath))
                {
                    Directory.CreateDirectory(TargetFolderPath);
                }
                foreach (string filePath in Directory.GetFiles(OrginalFolderPath))
                {
                    try
                    {
                        string destFileName = Path.Combine(TargetFolderPath, Path.GetFileName(filePath));
                        File.Move(filePath, destFileName);

                    }
                    catch (Exception ex)
                    {
                        ExceptionMassage = ex.Message;
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                ExceptionMassage = ex.Message;
                return false;
            }
        }

        public static bool DeleteFolder(string FolderPath, out string ExeptionMassage)
        {
            ExeptionMassage = string.Empty;
            try
            {
               

                if (!string.IsNullOrEmpty(FolderPath))
                {
                    if (Directory.Exists(FolderPath))
                    {
                        Directory.Delete(FolderPath, true);
                        return true;
                    }
                    else
                    {
                        ExeptionMassage = "Folder path is wrong";
                        return false;
                    }
                }
                else
                {
                    ExeptionMassage = "Folder path is null";
                    return false;
                }
            }
            catch (Exception ex)
            {
                ExeptionMassage = ex.Message;
                return false;
            }
        }
    }
}
