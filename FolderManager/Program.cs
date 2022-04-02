﻿
using System.IO;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello for File manager");
Console.Beep();

for (; ; )
{
    Console.WriteLine("what you want to manage\n" +
        "1.Folders\n" +
        "2.Files\n\n");

    int MainAction = Convert.ToInt32(Console.ReadLine());
    if (MainAction == 1)
    {
        for (; ; )
        {
            Console.WriteLine("Choose action\n" +
                "1.copy files from folder to another folder\n" +
                "2.Cut files from folder to another folder\n" +
                "3.Delete folder\n" +
                "4.Report folder\n" +
                "5.Close\n\n");
            int Action = Convert.ToInt32(Console.ReadLine());
            switch (Action)
            {
                case 1:
                    try
                    {
                        Console.WriteLine("Insert Original Folder");
                        string OrginalFolderPath = Console.ReadLine();
                        Console.WriteLine("Insert the folder that you want to copy to it");
                        string TargetFolderPath = Console.ReadLine();

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
                                Console.Beep();
                                Console.WriteLine($"Exeption: {ex.Message}\nDate of error: {DateTime.Now}\n\n");
                            }
                        }
                        Console.WriteLine($"Count of copied files: {Directory.GetFiles(TargetFolderPath).Length}\n\n");
                    }
                    catch (Exception ex)
                    {
                        Console.Beep();
                        Console.WriteLine($"Exeption: {ex.Message}\nDate of error: {DateTime.Now}\n\n");
                    }
                    break;
                case 2:
                    try
                    {
                        Console.WriteLine("Insert Original Folder");
                        string OrginalFolderPath = Console.ReadLine();
                        Console.WriteLine("Insert the folder that you want to copy to it");
                        string TargetFolderPath = Console.ReadLine();

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
                                Console.Beep();
                                Console.WriteLine($"Exeption: {ex.Message}\nDate of error: {DateTime.Now}\n\n");
                            }
                        }
                        Console.WriteLine($"Count of moved files: {Directory.GetFiles(TargetFolderPath).Length}\n\n");
                    }
                    catch (Exception ex)
                    {
                        Console.Beep();
                        Console.WriteLine($"Exeption: {ex.Message}\nDate of error: {DateTime.Now}\n\n");
                    }
                    break;
                case 3:
                    try
                    {
                        for (; ; )
                        {
                            Console.WriteLine("Insert folder path");
                            string FolderPath = Console.ReadLine();

                            if (!string.IsNullOrEmpty(FolderPath))
                            {
                                if (Directory.Exists(FolderPath))
                                {
                                    Directory.Delete(FolderPath, true);
                                    Console.Clear();
                                    Console.WriteLine($"Folder is deleted: {FolderPath}");
                                }
                                else
                                {
                                    Console.WriteLine("you inserted wrong path");
                                }

                                break;
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        Console.Beep();
                        Console.WriteLine($"Exeption: {ex.Message}\nDate of error: {DateTime.Now}\n\n");
                    }
                    break;
                case 4:
                    try
                    {
                        Console.WriteLine("Insert folder path");
                        string FolderPath = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(FolderPath))
                        {
                            if (Directory.Exists(FolderPath))
                            {
                                List<FolderReportDto> folderReportDtos = new List<FolderReportDto>();
                                foreach (string FilePath in Directory.GetFiles(FolderPath))
                                {
                                    string FileExtention=Path.GetExtension(FilePath);
                                    if (folderReportDtos.Any(x=>x.ExtentionType== FileExtention))
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
                                List<string> Lines=new List<string> ();
                                foreach (FolderReportDto folderReportDto in folderReportDtos)
                                {
                                    string line = $"Extention type: {folderReportDto.ExtentionType} - " +
                                        $"Count: {folderReportDto.ExtentionCount}";
                                    Lines.Add(line);
                                }
                                string NameOfTXT= Path.Combine(FolderPath, $"Report.txt");
                                File.WriteAllLines(NameOfTXT, Lines);
                                Console.WriteLine($"Report has been generted on path:\n" +
                                    $"{NameOfTXT}\n\n");

                                for (int i = 0; i < Lines.Count; i++)
                                {
                                    //Console.WriteLine($"{i + 1} {Lines[i]}");
                                    Console.WriteLine(@"{0} {1}", (i+1), Lines[i]);
                                }

                            }
                            else
                            {
                                Console.WriteLine("you inserted wrong path");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please insert folder path");
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.Beep();
                        Console.WriteLine($"Exeption: {ex.Message}\nDate of error: {DateTime.Now}\n\n");
                    }
                    break;
                default:
                    break;
            }
        }

    }
    else if (MainAction == 2)
    {
        for (; ; )
        {
            Console.WriteLine($"Choose action\n" +
                $"1.Copy file to folder\n" +
                $"2.Cut file to folder\n" +
                $"3.Delete file to folder\n" +
                $"4.Close cmd\n\n");

            int Action = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Insert path of the file");
            string OrigneFolderPath = Console.ReadLine();
            Console.WriteLine("Insert file name");
            string FileName = Console.ReadLine();

            string SourceFile = Path.Combine(OrigneFolderPath, FileName);



            switch (Action)
            {
                case 1:

                    try
                    {
                        Console.WriteLine("Insert target path folder");
                        string NewFolderPath = Console.ReadLine();
                        string TargetFile = Path.Combine(NewFolderPath, FileName);
                        if (!Directory.Exists(NewFolderPath))
                        {
                            Directory.CreateDirectory(NewFolderPath);
                        }

                        File.Copy(SourceFile, TargetFile, true);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Exption: {ex.Message}");
                    }


                    break;
                case 2:
                    try
                    {
                        Console.WriteLine("Insert target path folder");
                        string NewFolderPath = Console.ReadLine();
                        string TargetFile = Path.Combine(NewFolderPath, FileName);

                        if (!Directory.Exists(NewFolderPath))
                        {
                            Directory.CreateDirectory(NewFolderPath);
                        }
                        File.Move(SourceFile, TargetFile, true);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Exption: {ex.Message}");
                        throw;
                    }
                    break;
                case 3:
                    try
                    {
                        File.Delete(SourceFile);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Exption: {ex.Message}");
                        throw;
                    }
                    break;
                case 4:
                    break;
                default:
                    Console.WriteLine("you insert wrong number please try again");
                    break;
            }

            if (Action == 4)
            {
                break;
            }
        }

    }
    else
    {
        Console.WriteLine("you insert wrong number please choose again");
    }

}
public class FolderReportDto
{
    public string ExtentionType { get; set; }
    public int ExtentionCount { get; set; }
}