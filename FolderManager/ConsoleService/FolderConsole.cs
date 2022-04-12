using IOService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderManager.ConsoleService
{
    public static class FolderConsole
    {
        public static void CopyFolderConsole()
        {
            string OriginalFolderPath, TargetFolderPath;
            FolderForm(out OriginalFolderPath, out TargetFolderPath);

            string ExpetionMassage;
            bool result = FolderService.CopyToFolder(OriginalFolderPath, TargetFolderPath, out ExpetionMassage);
            if (result)
            {
                Console.WriteLine("Succefully copied..");
            }
            else
            {
                Console.Error.WriteLine($"something is wrong {ExpetionMassage}");
            }
        }
        public static void CutFromFolderConsole()
        {
            string OriginalFolderPath, TargetFolderPath;
            FolderForm(out OriginalFolderPath, out TargetFolderPath);

            string ExpetionMassage;
            bool result = FolderService.CutFromFolder(OriginalFolderPath, TargetFolderPath, out ExpetionMassage);
            if (string.IsNullOrEmpty(ExpetionMassage))
            {
                Console.WriteLine("Cutted succesfully");
                Console.WriteLine($"{nameof(CutFromFolderConsole)} fuction succesfully work");
            }
            else
            {
                Console.WriteLine($"{nameof(ExpetionMassage)} {ExpetionMassage}");
            }
        }
        public static void DeleteFolderConsole()
        {
            Console.WriteLine("Insert folder path");
            string OriginalFolderPath = Console.ReadLine();

            string ExectionMassage;
           bool result = FolderService.DeleteFolder(OriginalFolderPath, out ExectionMassage);
            if (result)
            {
                Console.WriteLine("Deleted succesfully");
            }
            else
            {
                Console.WriteLine($"{nameof(ExectionMassage)}: {ExectionMassage}");
            }
        }
        public static void FolderStaticsConsole()
        {
            Console.WriteLine("Insert folder path");
            string FolderPath = Console.ReadLine();
            string Massage;
            List<string> statics=FolderService.FolderStatics(FolderPath, out Massage);
            if (string.IsNullOrEmpty(Massage))
            for (int i = 0; i < statics.Count; i++)
            {
                //Console.WriteLine($"{i + 1} {Lines[i]}");
                Console.WriteLine(@"{0} {1}", (i + 1), statics[i]);
            }
            else
            {
                Console.WriteLine(Massage);
            }
        }
        private static void FolderForm(out string OriginalFolderPath, out string TargetFolderPath)
        {
            Console.WriteLine("Insert Original Folder");
            OriginalFolderPath = Console.ReadLine();
            Console.WriteLine("Insert the folder that you want to copy to it");
            TargetFolderPath = Console.ReadLine();
        }
    }
}
