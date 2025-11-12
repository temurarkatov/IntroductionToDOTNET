using System;

namespace FileIOExample
{
	public class Fraction : IComparable<Fraction>, IEquatable<Fraction>
	{
		public long Numerator { get; private set; }
		public long Denominator { get; private set; }

		public Fraction(long numerator, long denominator)
		{
			if (denominator == 0) throw new DivideByZeroException("Знаменатель не может быть нулем.");
			Numerator = numerator;
			Denominator = denominator;
			Simplify();
		}

		public Fraction(long wholeNumber) : this(wholeNumber, 1) { }

		public Fraction(string fractionString)
		{
			var parts = fractionString.Split('/');
			if (parts.Length != 2 ||
				!long.TryParse(parts[0], out long num) ||
				!long.TryParse(parts[1], out long den))
				throw new FormatException("Неверный формат дроби.");
			Numerator = num;
			Denominator = den;
			Simplify();
		}

		private void Simplify()
		{
			long gcd = GCD(Math.Abs(Numerator), Math.Abs(Denominator));
			Numerator /= gcd;
			Denominator /= gcd;
			if (Denominator < 0)
			{
				Numerator = -Numerator;
				Denominator = -Denominator;
			}
		}

		private static long GCD(long a, long b)
		{
			while (b != 0)
			{
				long temp = b;
				b = a % b;
				a = temp;
			}
			return a;
		}

		public override string ToString()
		{
			return $"{Numerator}/{Denominator}";
		}

		public double ToDouble() => (double)Numerator / Denominator;

		public int CompareTo(Fraction? other)
		{
			if (other == null) return 1;
			return (Numerator * other.Denominator).CompareTo(other.Numerator * Denominator);
		}

		public bool Equals(Fraction? other)
		{
			if (other == null) return false;
			return Numerator == other.Numerator && Denominator == other.Denominator;
		}

		public override bool Equals(object? obj) => obj is Fraction f && Equals(f);
		public override int GetHashCode() => HashCode.Combine(Numerator, Denominator);

		public static Fraction operator +(Fraction a, Fraction b) =>
			new Fraction(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator);

		public static Fraction operator -(Fraction a, Fraction b) =>
			new Fraction(a.Numerator * b.Denominator - b.Numerator * a.Denominator, a.Denominator * b.Denominator);

		public static Fraction operator *(Fraction a, Fraction b) =>
			new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator);

		public static Fraction operator /(Fraction a, Fraction b)
		{
			if (b.Numerator == 0) throw new DivideByZeroException("Деление на ноль.");
			return new Fraction(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
		}

		public static Fraction operator -(Fraction f) => new Fraction(-f.Numerator, f.Denominator);

		public static bool operator ==(Fraction a, Fraction b) => a.Equals(b);
		public static bool operator !=(Fraction a, Fraction b) => !a.Equals(b);
		public static bool operator <(Fraction a, Fraction b) => a.CompareTo(b) < 0;
		public static bool operator >(Fraction a, Fraction b) => a.CompareTo(b) > 0;
		public static bool operator <=(Fraction a, Fraction b) => a.CompareTo(b) <= 0;
		public static bool operator >=(Fraction a, Fraction b) => a.CompareTo(b) >= 0;
	}
}
