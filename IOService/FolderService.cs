using IOService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
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
                        string PathOfTextFile = Path.Combine(FolderPath, $"Report.txt");
                        File.WriteAllLines(PathOfTextFile, Lines);
                        return Lines;
                    }
                    else
                    {
                        ExeptionMassage = "you inserted wrong path";
                        return null;
                    }
                }
                else
                {
                    ExeptionMassage = "Please insert folder path";
                    return null;
                }

            }
            catch (Exception ex)
            {
                ExeptionMassage = $"Exeption: {ex.Message}\nDate of error: {DateTime.Now}\n\n";
                return null;
            }
        }
        public static string FilterFolder(string FolderPath, DateTime AccessDate, out string ExeptionMassage)
        {
            ExeptionMassage = string.Empty;
            try
            {
                FolderFilterDto FilterBeforeAccessDateDto = new FolderFilterDto();
                //FilterBeforeAccessDateDto.FilesCount = 0;
                //FilterBeforeAccessDateDto.TotalSize  = 0;
                FolderFilterDto FilterAfterAccessDateDto = new FolderFilterDto();

                foreach (string FilePath in Directory.GetFiles(FolderPath, "*.*", SearchOption.TopDirectoryOnly))
                {
                    // File.GetLastAccessTime(FilePath);
                    FileInfo info = new FileInfo(FilePath);



                    if (AccessDate > info.LastAccessTime)
                    {
                        FilterBeforeAccessDateDto.FilesCount += 1;
                        FilterBeforeAccessDateDto.TotalSize += info.Length;
                    }
                    else
                    {
                        FilterAfterAccessDateDto.FilesCount += 1;
                        FilterAfterAccessDateDto.TotalSize += info.Length;
                    }
                }
                string FilterReport = $@"Last access filter
______________
Before access date
______________
File count{FilterBeforeAccessDateDto.FilesCount}
Total size {Math.Round(FilterBeforeAccessDateDto.TotalSize / 1073741824, 4)} Giga
_______________________________________________
After access date
_____________
File count{FilterAfterAccessDateDto.FilesCount}
Total size {Math.Round(FilterAfterAccessDateDto.TotalSize / 1073741824, 4)} Giga
";
                return FilterReport;
            }
            catch (Exception ex)
            {
                ExeptionMassage = ex.Message;
                return string.Empty;
            }
        }
    }
}
