//#define CONSOLE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToDOTNET
{
	internal class Program
	{
		static void Main(string[] args)
		{
#if CONSOLE
            Console.WriteLine("Hello World!");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            //Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Hello .NET\t");
            Console.WriteLine();
            Console.Title = "Introduction to .NET";
            Console.Beep(37, 2000);
            Console.CursorLeft = 25;
            Console.CursorTop = 5;
            Console.WriteLine("SetConsolCursorPosition");
            Console.SetCursorPosition(22, 8);
            Console.WriteLine("Another position");
            Console.ResetColor();
            Console.Clear(); 
#endif

			Console.Write("Введите ваше имя:");
			string firstName = Console.ReadLine();

			Console.Write("Введите вашу фамилию: ");
			string lastName = Console.ReadLine();

			Console.Write("Введите ваш возраст: ");
			int age = Convert.ToInt32(Console.ReadLine());

			Console.WriteLine(lastName + " " + firstName + " " + age);
			Console.WriteLine(String.Format("{0} {1} {2}", lastName, firstName, age));
			Console.WriteLine($"{lastName} {firstName} {age}");


		}
	}
}
