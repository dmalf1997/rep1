using System;
using System.Collections.Generic;

namespace Template_Method
{
	public abstract class Progression
	{
		public int First { get; set; }
		public int Last { get; set; }
		public int H { get; set; }
		public List<int> progList;

		public Progression(int first, int last, int h)
		{
			First = first;
			Last = last;
			H = h;
			progList = new List<int>();
		}

		public void TemplateMethod()
		{
			InitializeProgression(First, Last, H);
			Progress();
			Print(progList);
		}
		
		private void Print(List<int> progList)
		{
			Console.WriteLine("Последовательность:");
			foreach (var item in progList)
			{
				Console.Write(" " + item);
			}
			Console.WriteLine();
		}
		private void InitializeProgression(int a, int b, int h)
		{
			First = a;
			Last = b;
			H = h;
		}
		
		public abstract void Progress();
		
	}
	
	class ArithmeticProgression : Progression
	{
		public ArithmeticProgression(int f, int l, int h) : base(f, l, h) { }
		public override void Progress()
		{
			int fF = First;
			do
			{
				progList.Add(fF);
				fF = fF + H;
			}
			while (fF < Last);
		}
	}

	
	
	class Program
	{
		public static void Main(string[] args)
		{
			int f, l ,h;
			
			Console.WriteLine("Введите начальную границу диапазона:");
			if(!int.TryParse(Console.ReadLine(), out f))
			{
				Console.WriteLine("Ошибка ввода целого числа");
				return;
			}
			Console.WriteLine("Введите конечную границу диапазона:");
			if(!int.TryParse(Console.ReadLine(), out l))
			{
				Console.WriteLine("Ошибка ввода целого числа");
				return;
			}
			Console.WriteLine("Введите шаг прогрессии:");
			if(!int.TryParse(Console.ReadLine(), out h))
			{
				Console.WriteLine("Ошибка ввода целого числа");
				return;
			}
			
			Progression val = new ArithmeticProgression(f,l,h);	
			val.TemplateMethod();
			Console.ReadKey(true);
		}
	}
}