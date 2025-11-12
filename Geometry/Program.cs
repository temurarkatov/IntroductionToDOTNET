using System;
using System.Collections.Generic;
using System.IO;

namespace FileIOExample
{
	public class Group
	{
		private List<Fraction> fractions;

		public Group()
		{
			fractions = new List<Fraction>();
		}

		public void AddFraction(Fraction f)
		{
			fractions.Add(f);
		}

		public List<Fraction> GetFractions()
		{
			return new List<Fraction>(fractions);
		}

		// Доработанный ToString() — возвращает список в формате [3/4, -1/2]
		public override string ToString()
		{
			if (fractions.Count == 0) return "[]"; // Пустая группа
			string result = "[";
			for (int i = 0; i < fractions.Count; i++)
			{
				result += fractions[i].ToString();
				if (i < fractions.Count - 1) result += ", ";
			}
			result += "]";
			return result;
		}

		// Запись группы в файл с использованием System.IO.StreamWriter
		public void SaveToFile(string filePath)
		{
			try
			{
				using (StreamWriter writer = new StreamWriter(filePath))
				{
					foreach (var f in fractions)
					{
						writer.WriteLine(f.ToString()); // Использует ToString() дроби
					}
				}
				Console.WriteLine($"Группа сохранена в файл: {filePath}");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Ошибка при сохранении файла: {ex.Message}");
			}
		}

		// Загрузка группы из файла с использованием System.IO.StreamReader
		public void LoadFromFile(string filePath)
		{
			fractions.Clear();
			try
			{
				using (StreamReader reader = new StreamReader(filePath))
				{
					string? line;
					while ((line = reader.ReadLine()) != null)
					{
						if (!string.IsNullOrWhiteSpace(line))
						{
							fractions.Add(new Fraction(line)); // Парсит ToString() обратно в Fraction
						}
					}
				}
				Console.WriteLine($"Группа загружена из файла: {filePath}");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Ошибка при загрузке файла: {ex.Message}");
			}
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Group group = new Group();
			group.AddFraction(new Fraction(3, 4));
			group.AddFraction(new Fraction(-1, 2));
			group.AddFraction(new Fraction(5));

			Console.WriteLine("Исходная группа: " + group.ToString()); // Вызывает доработанный ToString()

			string filePath = "group.txt";
			group.SaveToFile(filePath);

			Group loadedGroup = new Group();
			loadedGroup.LoadFromFile(filePath);

			Console.WriteLine("Загруженная группа: " + loadedGroup.ToString());

			Console.WriteLine("Нажмите любую клавишу для выхода...");
			Console.ReadKey();
		}
	}
}
