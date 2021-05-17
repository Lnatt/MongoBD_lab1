using System;
using System.Linq;

namespace MongoBD_lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataManager = new DataManager("mongodb://localhost:27017", "seminar");
            
            while (true)
            {
                string s;
                while ((s = Console.ReadLine()) != null)
                {
                    string[] words = s.Split(' ');
                    
                    if(words.Length > 1)
                    {
                        if (words[0] == "manufacture")
                        {
                            var typedManufacture = dataManager.GetCarsByNameTyped(words[1]);
                            int count_manufacture = 0;
                            foreach (var user in typedManufacture)
                            {
                                count_manufacture++;
                            }
                            Console.WriteLine(words[1]);
                            Console.WriteLine(count_manufacture);
                        }
                        if (words[0] == "later_then")
                        {
                            var typedYear = dataManager.GetCarsByYearTyped(Int32.Parse(words[1]));
                            foreach (var user in typedYear)
                            {
                                Console.Write(user.Manufacture);
                                Console.Write(" - ");
                                Console.Write(user.Color);
                                Console.Write(" - ");
                                Console.WriteLine(user.Year);
                            }
                        }
                        if (words[0] == "options")
                        {
                            var typedId = dataManager.GetCarsByOptionsTyped(words[1]);                                
                            //604d01cfb33b7b4edc767653
                            foreach (var user in typedId)
                            {
                                Console.WriteLine(user.Color);
                            }
                        }
                    }
                    if (words[0] == "help")
                    {
                        Console.WriteLine("manufacture CAR - количество автомобилей производителя CAR");
                        Console.WriteLine("later_then 1234 - посмотреть все автомобили, выпущенные раньше 1234 года");
                        Console.WriteLine("options ID - список опций автомобиля с таким ID");
                        Console.WriteLine("help - помощь с командами");
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
