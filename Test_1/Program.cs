using System;
using System.IO;
using System.Threading.Tasks;

namespace Test_1
{
    class Program
    {
        static void Main(string[] args)
        {
            char go = '1';
            do
            {
                Console.WriteLine();
                Console.WriteLine("Укажите путь к папке с файлами:");
                string dirName = Console.ReadLine();

                if (Directory.Exists(dirName))
                {
                    char go2 = '1';
                    do
                    {
                        Console.WriteLine();
                        Console.WriteLine("Введите команду:");
                        string command = Console.ReadLine();

                        if (Class1.IsCorrect1(command) == true && Class1.IsCorrect2(command) == true)
                        {
                            char com = Class1.Select(command);
                            switch (com)
                            {
                                case '1':                                    
                                    Task task1 = Task.Run(() => Class1.Count(command, dirName));
                                    break;
                                case '2':
                                    Task task2 = Task.Run(() => Class1.Size(command, dirName));
                                    break;
                                case '3':
                                    Task task3 = Task.Run(() => Class1.Path(command, dirName));
                                    break;
                                default:
                                    break;
                            }
                        }
                        else { Console.WriteLine("Вы ввели некорректную команду!");
                            Console.WriteLine();
                            Console.WriteLine("Чтобы продолжить вводить команды нажмите любую клавишу;");
                            Console.WriteLine("Чтобы выйти нажмите - 0;");
                        }                        

                        string temp = Console.ReadLine();
                        if (temp.Length > 1) temp = temp.Remove(1, temp.Length - 1);
                        if (temp.Length == 0) temp = "1";
                        go2 = Convert.ToChar(temp);
                    } while (go2 != '0');                    
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Вы указали не существующую директорию!");                    
                }
                Console.WriteLine();
                Console.WriteLine("Чтобы указать новый путь к папке с файлами нажмите любую клавишу;");
                Console.WriteLine("Чтобы выйти нажмите - 0;");

                string temp2 = Console.ReadLine();
                if (temp2.Length > 1) temp2 = temp2.Remove(1, temp2.Length - 1);
                if (temp2.Length == 0) temp2 = "1";
                go = Convert.ToChar(temp2);
            } while (go != '0');            
        }
    }
}
