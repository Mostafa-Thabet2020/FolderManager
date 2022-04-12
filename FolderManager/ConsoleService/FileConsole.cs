using IOService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderManager.ConsoleService
{
    public static class FileConsole
    {
        public static void CopyFileConsole()
        {
            string NewFolderPath, OrigneFolderPath, FileName, ExeptionMassage;
            FileForm(out NewFolderPath, out OrigneFolderPath, out FileName);

            FileService.CopyFile(NewFolderPath, OrigneFolderPath, FileName, out ExeptionMassage);
            if (string.IsNullOrEmpty(ExeptionMassage))
            {
                Console.WriteLine("File has been copied successfully");
            }
            else
            {
                Console.Error.WriteLine(ExeptionMassage);
            }
        }

        private static void FileForm(out string NewFolderPath, out string OrigneFolderPath, out string FileName, bool IsNewFolder = true)
        {
            if (IsNewFolder)
            {
                Console.WriteLine("Insert target path folder");
                NewFolderPath = Console.ReadLine();
            }
            else
            {
                NewFolderPath = string.Empty;
            }
            Console.WriteLine("Insert path of the file");
            OrigneFolderPath = Console.ReadLine();
            Console.WriteLine("Insert file name");
            FileName = Console.ReadLine();
        }

        public static void CutFileConsole()
        {
            string NewFolderPath, OrigneFolderPath, FileName, ExeptionMassage;
            FileForm(out NewFolderPath, out OrigneFolderPath, out FileName);
            FileService.CutFile(NewFolderPath, OrigneFolderPath, FileName, out ExeptionMassage);
            if (string.IsNullOrEmpty(ExeptionMassage))
            {
                Console.WriteLine("File has been cutied successfully");
            }
            else
            {
                Console.Error.WriteLine(ExeptionMassage);
            }
        }
        public static void DeleteFileConsole()
        {
            string NewFolderPath, OrigneFolderPath, FileName, ExeptionMassage;
            FileForm(out NewFolderPath, out OrigneFolderPath, out FileName,false);
            string ExeptionMessage;
            FileService.DeleteFile(OrigneFolderPath, FileName, out ExeptionMessage);
            if (string.IsNullOrEmpty(ExeptionMessage))
            {
                Console.WriteLine("File has been deleted successfully");
            }
            else
            {
                Console.Error.WriteLine(ExeptionMessage);
            }
        }
    }
}
