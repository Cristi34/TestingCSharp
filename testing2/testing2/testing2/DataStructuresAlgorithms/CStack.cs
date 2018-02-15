using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace testing2.DataStructuresAlgorithms
{
	public class CStack
	{
		private int p_index;
		private ArrayList list;
		public CStack()
		{
			list = new ArrayList();
			p_index = -1;
		}

		public int Count
		{
			get
			{
				return list.Count;
			}
		}
		public void Push(object item)
		{
			list.Add(item);
			p_index++;
		}
		public object Pop()
		{
			object obj = list[p_index];
			list.RemoveAt(p_index);
			p_index--;
			return obj;
		}
		public void Clear()
		{
			list.Clear();
			p_index = -1;
		}
		public object Peek()
		{
			return list[p_index];
		}

		public static void TestPalindrome(string word)
		{
			CStack alist = new CStack();
			string ch;

			bool isPalindrome = true;
			for (int x = 0; x < word.Length; x++)
				alist.Push(word.Substring(x, 1));
			int pos = 0;
			while (alist.Count > 0)
			{
				ch = alist.Pop().ToString();
				if (ch != word.Substring(pos, 1))
				{
					isPalindrome = false;
					break;
				}
				pos++;
			}
			if (isPalindrome)
				Console.WriteLine(word + " is a palindrome.");
			else
				Console.WriteLine(word + " is not a palindrome.");
			Console.Read();
		}

		public static bool BalancedParanthesesOneStack(string expression)
		{			
			Stack<char> stack = new Stack<char>();
			Dictionary<char, char> parantheses = new Dictionary<char, char>();
			parantheses.Add('}', '{');
			parantheses.Add(']', '[');
			parantheses.Add(')', '(');
			//parantheses.Add('{', '}');
			//parantheses.Add('[', ']');
			//parantheses.Add('(', ')');

			foreach (var item in expression)
			{
				if(item == '{' || item == '[' || item == '(')
				{
					stack.Push(item);
				}
				else
				{
					parantheses.TryGetValue(item, out char correctValue);
					var stackValue = stack.Pop();
					
					if(correctValue != stackValue)
					{
						return false;
					}
				}
			}

			return true;
		}
		public static bool BalancedParanthesesTwoStacks(string expression)
		{
			bool isCorrect = true;
			uint nr = 0; 
			if(expression.Length % 2 != 0)
			{
				return false;
			}

			Stack<char> stackLeft = new Stack<char>();
			Stack<char> stackRight = new Stack<char>();
			
			for(int i=0, length = expression.Length; i<= length / 2 - 1; i++)
			{
				stackLeft.Push(expression[i]);
			}
			for (int length = expression.Length, i = length - 1; i > length / 2 - 1; i--)
			{
				stackRight.Push(expression[i]);
			}

			Dictionary<char, char> parantheses = new Dictionary<char, char>();
			parantheses.Add('{', '}');
			parantheses.Add('[', ']');
			parantheses.Add('(', ')');

			while(stackLeft.Count > 0)
			{
				nr++;
				var left = stackLeft.Pop();
				var right = stackRight.Pop();
				Console.WriteLine("left: " + left + "  right: " + right);
				if (parantheses.TryGetValue(left, out char outValue))
				{
					if(outValue != right)
					{
						isCorrect = false;
						break;
					}
				}
			}
			Console.WriteLine("nr of iterations = " + nr);
			return isCorrect;
		}

		public static void StackTest()
		{
			string[] names = new string[] { "Raymond", "David", "Mike" };
			Stack nameStack = new Stack(names);
			// Executing the Pop method will remove “Mike” from the stack first

		}

		public static int Calculate(string expression)
		{
			Stack nums = new Stack();
			Stack ops = new Stack();
			string operators = "/*+-";
			//expression = expression.Reverse().ToString();

			var elements = expression.Split(' ');
			Array.Reverse(elements);

			foreach (var item in elements)
			{
				if (operators.Contains(item))
				{
					ops.Push(item);
				}
				else
				{
					nums.Push(item);
				}
			}

			var result = int.Parse(nums.Pop().ToString());
			while (nums.Count != 0)
			{
				int x;
				string op;

				x = int.Parse(nums.Pop().ToString());

				op = ops.Pop().ToString();
				switch (op)
				{
					case "/":
						result = result / x;
						break;
					case "*":
						result = result * x;
						break;
					case "+":
						result = result + x;
						break;
					case "-":
						result = result - x;
						break;
				}
			}

			return result;
		}

		// only works with '+' lol
		public static void TestCalculateExpressionFromBook()
		{
			Stack nums = new Stack();
			Stack ops = new Stack();
			string expression = "5 + 10 + 15 + 20";
			Calculate(nums, ops, expression);
			Console.WriteLine(nums.Pop());
			Console.Read();
		}
		static bool IsNumeric(string input)
		{
			bool flag = true;
			string pattern = (@"^\d+$");
			Regex validate = new Regex(pattern);
			if (!validate.IsMatch(input))
			{
				flag = false;
			}
			return flag;
		}

		static void Calculate(Stack N, Stack O, string exp)
		{
			string ch, token = "";
			for (int p = 0; p < exp.Length; p++)
			{
				ch = exp.Substring(p, 1);
				if (IsNumeric(ch))
					token += ch;
				if (ch == " " || p == (exp.Length - 1))
				{
					if (IsNumeric(token))
					{
						N.Push(token);
						token = "";
					}
				}
				else if (ch == "+" || ch == "-" || ch == "*" ||
				ch == "/")
					O.Push(ch);
				if (N.Count == 2)
					Compute(N, O);
			}
		}

		static void Compute(Stack N, Stack O)
		{
			int oper1, oper2;
			string oper;
			oper1 = Convert.ToInt32(N.Pop());
			oper2 = Convert.ToInt32(N.Pop());
			oper = Convert.ToString(O.Pop());
			switch (oper)
			{
				case "+":
					N.Push(oper1 + oper2);
					break;
				case "-":
					N.Push(oper1 - oper2);
					break;
				case "*":
					N.Push(oper1 * oper2);
					break;
				case "/":
					N.Push(oper1 / oper2);
					break;
			}
		}
		public static void MultipleBaseTest()
		{
			int num, baseNum;
			Console.Write("Enter a decimal number: ");
			num = Convert.ToInt32(Console.ReadLine());
			Console.Write("Enter a base: ");
			baseNum = Convert.ToInt32(Console.ReadLine());
			Console.Write(num + " converts to ");
			MulBase(num, baseNum);
			Console.WriteLine(" Base " + baseNum);
			Console.Read();
		}
		static void MulBase(int n, int b)
		{
			Stack Digits = new Stack();
			do
			{
				Digits.Push(n % b);
				n /= b;
			} while (n != 0);
			while (Digits.Count > 0)
				Console.Write(Digits.Pop());
		}
	}
}
