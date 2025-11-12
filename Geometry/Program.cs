using System;
using System.Runtime.InteropServices;

namespace NumericTypesInfo
{
	class Program
	{
		static void Main(string[] args)
		{
			// Список всех числовых типов C# с их обёртками
			var numericTypes = new (Type type, string wrapperName)[] {
				(typeof(sbyte), "SByte"),
				(typeof(byte), "Byte"),
				(typeof(short), "Int16"),
				(typeof(ushort), "UInt16"),
				(typeof(int), "Int32"),
				(typeof(uint), "UInt32"),
				(typeof(long), "Int64"),
				(typeof(ulong), "UInt64"),
				(typeof(float), "Single"),
				(typeof(double), "Double"),
				(typeof(decimal), "Decimal")
			};

			Console.WriteLine("Информация о числовых типах C#:");
			Console.WriteLine("---------------------------------------------------");

			foreach (var (type, wrapperName) in numericTypes)
			{
				// Используем Marshal.SizeOf как безопасный аналог sizeof()
				// Примечание: оператор sizeof() требует unsafe-контекста, но Marshal.SizeOf работает без него
				int size = Marshal.SizeOf(type);

				// Альтернатива с оператором sizeof(): закомментирована, чтобы код компилировался без unsafe
				// Если хотите использовать sizeof(), раскомментируйте и включите unsafe в проекте
				// int size =UnsafeSizeOf(type); // требуется <AllowUnsafeBlocks>true</AllowUnsafeBlocks> в .csproj

				// Получаем Мин/Макс через классы-обёртки из System (например, System.Int32)
				object minValue = GetMinValue(wrapperName);
				object maxValue = GetMaxValue(wrapperName);

				Console.WriteLine($"Тип: {type.Name}");
				Console.WriteLine($"  Размер (bytes): {size} байт");
				Console.WriteLine($"  Мин. значение: {minValue}");
				Console.WriteLine($"  Макс. значение: {maxValue}");
				Console.WriteLine("---------------------------------------------------");
			}
		}

		// Метод для получения минимального значения через классы-обёртки
		static object GetMinValue(string wrapperName)
		{
			switch (wrapperName)
			{
				case "SByte": return SByte.MinValue;
				case "Byte": return Byte.MinValue;
				case "Int16": return Int16.MinValue;
				case "UInt16": return UInt16.MinValue;
				case "Int32": return Int32.MinValue;
				case "UInt32": return UInt32.MinValue;
				case "Int64": return Int64.MinValue;
				case "UInt64": return UInt64.MinValue;
				case "Single": return Single.MinValue;
				case "Double": return Double.MinValue;
				case "Decimal": return Decimal.MinValue;
				default: return null;
			}
		}

		// Метод для получения максимального значения через классы-обёртки
		static object GetMaxValue(string wrapperName)
		{
			switch (wrapperName)
			{
				case "SByte": return SByte.MaxValue;
				case "Byte": return Byte.MaxValue;
				case "Int16": return Int16.MaxValue;
				case "UInt16": return UInt16.MaxValue;
				case "Int32": return Int32.MaxValue;
				case "UInt32": return UInt32.MaxValue;
				case "Int64": return Int64.MaxValue;
				case "UInt64": return UInt64.MaxValue;
				case "Single": return Single.MaxValue;
				case "Double": return Double.MaxValue;
				case "Decimal": return Decimal.MaxValue;
				default: return null;
			}
		}

		// Заглушка для sizeof() с использованием unsafe (закомментирована для безопасной компиляции)
		// Если хотите использовать оператор sizeof(), раскомментируйте, добавьте unsafe в сигнатуру метода
		// и включите <AllowUnsafeBlocks>true</AllowUnsafeBlocks> в .csproj файле проекта
		/*
        unsafe static int UnsafeSizeOf(Type type)
        {
            if (type == typeof(sbyte)) return sizeof(sbyte);
            if (type == typeof(byte)) return sizeof(byte);
            if (type == typeof(short)) return sizeof(short);
            if (type == typeof(ushort)) return sizeof(ushort);
            if (type == typeof(int)) return sizeof(int);
            if (type == typeof(uint)) return sizeof(uint);
            if (type == typeof(long)) return sizeof(long);
            if (type == typeof(ulong)) return sizeof(ulong);
            if (type == typeof(float)) return sizeof(float);
            if (type == typeof(double)) return sizeof(double);
            if (type == typeof(decimal)) return sizeof(decimal);
            return 0;
        }
        */
	}
}
