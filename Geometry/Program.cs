using System;

namespace ScalableGeometryShapes
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Введите размер N (целое число >=1, рекомендуется нечетное для ромба): ");
			if (!int.TryParse(Console.ReadLine(), out int N) || N < 1)
			{
				N = 5; // Значение по умолчанию, если ввод неверный
				Console.WriteLine($"Неверный ввод, используется N = {N}");
			}

			// Фигура 1: Квадрат N x N из звёздочек
			Console.WriteLine("\n1)");
			for (int i = 0; i < N; i++)
			{
				for (int j = 0; j < N; j++)
				{
					Console.Write("* ");
				}
				Console.WriteLine();
			}
			Console.WriteLine();

			// Фигура 2: Правый треугольник (увеличивающийся слева)
			Console.WriteLine("2)");
			for (int i = 1; i <= N; i++)
			{
				for (int j = 0; j < i; j++)
				{
					Console.Write("* ");
				}
				Console.WriteLine();
			}
			Console.WriteLine();

			// Фигура 3: Левый треугольник (уменьшающийся слева)
			Console.WriteLine("3)");
			for (int i = N; i > 0; i--)
			{
				for (int j = 0; j < i; j++)
				{
					Console.Write("* ");
				}
				Console.WriteLine();
			}
			Console.WriteLine();

			// Фигура 4: Правый треугольник с отступами (сдвиг вправо)
			Console.WriteLine("4)");
			for (int i = 0; i < N; i++)
			{
				// Отступы
				for (int j = 0; j < i; j++)
				{
					Console.Write("  ");
				}
				// Звёздочки (уменьшающиеся)
				for (int k = N - i; k > 0; k--)
				{
					Console.Write("* ");
				}
				Console.WriteLine();
			}
			Console.WriteLine();

			// Фигура 5: Левый треугольник с отступами (сдвиг влево, но с отступами справа? По примеру - отступы слева, звёзды слева)
			// По примеру: отступы увеличиваются слева, звёзды растут слева
			Console.WriteLine("5)");
			for (int i = 0; i < N; i++)
			{
				// Отступы слева (уменьшающиеся)
				for (int j = N - 1 - i; j > 0; j--)
				{
					Console.Write("  ");
				}
				// Звёздочки (увеличивающиеся)
				for (int k = 0; k <= i; k++)
				{
					Console.Write("* ");
				}
				Console.WriteLine();
			}
			Console.WriteLine();

			// Фигура 6: Ромб (алмаз) с косыми линиями, высота 2N
			Console.WriteLine("6)");
			// Верхняя половина (включая середину)
			for (int i = 0; i < N; i++)
			{
				// Отступы слева
				for (int j = N - i - 1; j > 0; j--)
				{
					Console.Write(" ");
				}
				Console.Write("/");
				// Внутренние пробелы
				for (int j = 0; j < 2 * i; j++)
				{
					Console.Write(" ");
				}
				Console.Write("\\");
				Console.WriteLine();
			}
			// Нижняя половина
			for (int i = N - 1; i > 0; i--)
			{
				// Отступы слева
				for (int j = N - i; j > 0; j--)
				{
					Console.Write(" ");
				}
				Console.Write("\\");
				// Внутренние пробелы
				for (int j = 0; j < 2 * (i - 1); j++)
				{
					Console.Write(" ");
				}
				Console.Write("/");
				Console.WriteLine();
			}
			Console.WriteLine();

			// Фигура 7: Шахматный паттерн N x N с + и -
			Console.WriteLine("7)");
			for (int i = 0; i < N; i++)
			{
				for (int j = 0; j < N; j++)
				{
					if ((i + j) % 2 == 0)
						Console.Write("+ ");
					else
						Console.Write("- ");
				}
				Console.WriteLine();
			}
		}
	}
}
