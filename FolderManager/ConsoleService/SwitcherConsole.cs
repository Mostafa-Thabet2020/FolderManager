using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderManager.ConsoleService
{
    public static class SwitcherConsole
    {
        public static void FileManager()
        {
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
                      "5.Filter folder\n" +
                      "6.Close\n\n");
                        int Action = Convert.ToInt32(Console.ReadLine());
                        switch (Action)
                        {
                            case 1:
                                FolderConsole.CopyFolderConsole();
                                break;
                            case 2:
                                FolderConsole.CutFromFolderConsole();
                                break;
                            case 3:
                                FolderConsole.DeleteFolderConsole();
                                break;
                            case 4:
                                FolderConsole.FolderStaticsConsole();
                                break;
                            case 5:
                                FolderConsole.FilterConsole();
                                break;
                            default:
                                break;
                        }
                        if (Action==6)
                        {
                            break;
                        }
                    }
                }
                else
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
                                FileConsole.CopyFileConsole();
                                break;
                            case 2:
                                FileConsole.CutFileConsole();
                                break;
                            case 3:
                                FileConsole.DeleteFileConsole();
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

            }
        }
    }
}
