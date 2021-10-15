using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_1
{
    class Class1
    {
        public static bool IsCorrect1(string str)
        {
            if (str.StartsWith("COUNT <<") || str.StartsWith("SIZE <<") || str.StartsWith("PATH <<"))
                return true;
            return false;
        }

        public static bool IsCorrect2(string str)
        {
            if (str.EndsWith(">>"))
                return true;
            return false;
        }

        public static char Select(string command)
        {
            char com;
            if (command.StartsWith("COUNT <<")) com = '1';
            else if (command.StartsWith("SIZE <<")) com = '2';
            else com = '3';
            return com;
        }

        public static void Count(string com, string dirName)
        {
            com = com.Remove(0, 8); com = com.Remove(com.Length - 2, 2);
            
            if(com == "")
            {
                string[] files = Directory.GetFiles(dirName);
                int count = 0;
                foreach (string s in files)
                    count++;

                Console.WriteLine();
                Console.WriteLine("Количество отсканированных файлов: " + count);
                Console.WriteLine();
                Console.WriteLine("Чтобы продолжить вводить команды нажмите любую клавишу;");
                Console.WriteLine("Чтобы выйти нажмите - 0;");
            }
            else
            {
                string[] files = Directory.GetFiles(dirName, "*." + com);
                int count = 0;
                foreach (string s in files)
                    count++;

                Console.WriteLine();
                Console.WriteLine("Количество отсканированных файлов с заданным расширением: " + count);
                Console.WriteLine();
                Console.WriteLine("Чтобы продолжить вводить команды нажмите любую клавишу;");
                Console.WriteLine("Чтобы выйти нажмите - 0;");
            }            
        }

        public static void Size(string com, string dirName)
        {
            com = com.Remove(0, 7); com = com.Remove(com.Length - 2, 2);

            if (com == "")
            {
                DirectoryInfo di = new DirectoryInfo(dirName);
                FileInfo[] fiArr = di.GetFiles();
                long maxsize = 0;
                foreach (FileInfo f in fiArr)
                    maxsize += f.Length;

                Console.WriteLine();
                Console.WriteLine("Общий размер файлов: " + maxsize + " байтов.");
                Console.WriteLine();
                Console.WriteLine("Чтобы продолжить вводить команды нажмите любую клавишу;");
                Console.WriteLine("Чтобы выйти нажмите - 0;");
            }
            else
            {
                DirectoryInfo di = new DirectoryInfo(dirName);
                FileInfo[] fiArr = di.GetFiles("*." + com);
                long maxsize = 0;
                foreach (FileInfo f in fiArr)
                    maxsize += f.Length;

                Console.WriteLine();
                Console.WriteLine("Общий размер файлов с заданным расширением: " + maxsize + " байтов.");
                Console.WriteLine();
                Console.WriteLine("Чтобы продолжить вводить команды нажмите любую клавишу;");
                Console.WriteLine("Чтобы выйти нажмите - 0;");
            }            
        }

        public static void Path(string com, string dirName)
        {
            com = com.Remove(0, 7); com = com.Remove(com.Length - 2, 2);

            if (com == "")
            {
                Console.WriteLine();
                Console.WriteLine("Список всех файлов с полным путем:");
                string[] files = Directory.GetFiles(dirName);
                foreach (string s in files)
                    Console.WriteLine(s);
                Console.WriteLine();
                Console.WriteLine("Чтобы продолжить вводить команды нажмите любую клавишу;");
                Console.WriteLine("Чтобы выйти нажмите - 0;");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Список всех файлов с полным путем:");
                string[] files = Directory.GetFiles(dirName, "*." + com);
                foreach (string s in files)
                    Console.WriteLine(s);
                Console.WriteLine();
                Console.WriteLine("Чтобы продолжить вводить команды нажмите любую клавишу;");
                Console.WriteLine("Чтобы выйти нажмите - 0;");
            }                                
        }
    }
}
