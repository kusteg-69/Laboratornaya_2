using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            //задание 3
            Console.Write("Задание номер 3: ");
            Console.Write("Напишите путь папки, для отображения в нём существующих файлов: ");
            string dirName = Console.ReadLine();
            Console.Write("Теперь введите название или расширение файла:");
            string fileName = Console.ReadLine();
            if (Directory.Exists(dirName))
            {
                Console.WriteLine("Подкатологи");
                string[] directory = Directory.GetDirectories(dirName);
                foreach (string dirs in directory)
                {
                    Console.WriteLine(dirs);
                }

                Console.WriteLine("Файлы:");
                string[] files = Directory.GetFiles(dirName);
                foreach (string f in files)
                {
                    if (fileName == Path.GetExtension(f))
                    {
                        Console.WriteLine(f);

                    }
                   




                }
                
            }
    
          

            
            


            //задание 2
            Console.Write("Задание номер 2: ");
                Console.WriteLine("Выберите файл, который хотите прочитать");
                string path = Console.ReadLine();
                using (FileStream fstream = File.OpenRead(path))
                {
                    byte[] buffer = new byte[fstream.Length];
                    await fstream.ReadAsync(buffer, 0, buffer.Length);
                    Encoding Codirovka;
                    while (true)
                    {
                        Console.WriteLine("Выберите кодировку для прочтения файла(если хотите выйти, нажмите число 4):\n1.UTF-8\n2.Win1251\n3.DOC 866");
                        int a = int.Parse(Console.ReadLine());
                        switch (a)
                        {
                            case 1:
                                {

                                    Codirovka = Encoding.GetEncoding("UTF-8");
                                    string text = Codirovka.GetString(buffer);
                                    Console.WriteLine($"Текст из файла:{text}");
                                }
                                break;

                            case 2:
                                {

                                    Codirovka = Encoding.GetEncoding("windows-1251");
                                    string text = Codirovka.GetString(buffer);
                                    Console.WriteLine($"Текст из файла:{text}");
                                }
                                break;

                            case 3:
                                {
                                    Codirovka = Encoding.GetEncoding(866);
                                    string text = Codirovka.GetString(buffer);
                                    Console.WriteLine($"Текст из файла:{text}");
                                }
                                break;
                     
                            case 4:
                                {
                                    return;
                                }
                                break;


                        }
                    }

                }

           
           



        }
    }
}
