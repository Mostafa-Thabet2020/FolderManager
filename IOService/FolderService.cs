using IOService.Dto;
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
        public static List<string> FolderStatics(string FolderPath, out string ExeptionMassage)
        {
            ExeptionMassage = string.Empty;
            try
            {
                
                if (!string.IsNullOrWhiteSpace(FolderPath))
                {
                    if (Directory.Exists(FolderPath))
                    {
                        List<FolderReportDto> folderReportDtos = new List<FolderReportDto>();
                        foreach (string FilePath in Directory.GetFiles(FolderPath))
                        {
                            string FileExtention = Path.GetExtension(FilePath);
                            if (folderReportDtos.Any(x => x.ExtentionType == FileExtention))
                            {
                                folderReportDtos.Where(x => x.ExtentionType == FileExtention).FirstOrDefault()
                                    .ExtentionCount += 1;
                            }
                            else
                            {
                                FolderReportDto folderReportDto = new FolderReportDto();
                                folderReportDto.ExtentionType = FileExtention;
                                folderReportDto.ExtentionCount = 1;
                                folderReportDtos.Add(folderReportDto);
                            }
                        }
                        List<string> Lines = new List<string>();
                        foreach (FolderReportDto folderReportDto in folderReportDtos)
                        {
                            string line = $"Extention type: {folderReportDto.ExtentionType} - " +
                                $"Count: {folderReportDto.ExtentionCount}";
                            Lines.Add(line);
                        }
                        string NameOfTXT = Path.Combine(FolderPath, $"Report.txt");
                        File.WriteAllLines(NameOfTXT, Lines);
                        return Lines;
                    }
                    else
                    {
                       ExeptionMassage= "you inserted wrong path";
                        return null;
                    }
                }
                else
                {
                    ExeptionMassage="Please insert folder path";
                    return null;
                }

            }
            catch (Exception ex)
            {
                ExeptionMassage=$"Exeption: {ex.Message}\nDate of error: {DateTime.Now}\n\n";
                return null;
            }
        }
    }
}
