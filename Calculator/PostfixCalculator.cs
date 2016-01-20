using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Calculator
{
	public class PostfixCalculator
	{
		public string answer { get; set; }
		
		public PostfixCalculator (string expr)
		{
			string[] exprSplit = expr.Split (default(string[]), StringSplitOptions.RemoveEmptyEntries);
			answer = "under construction";

			Debug.WriteLine ("split expression: " + exprSplit);

			Stack<float> stack = new Stack<float> ();

			for (int i = 0; i < exprSplit.Length; i++) {
				string val = exprSplit [i];
				if (val == "+" || val == "-" || val == "/" || val == "x") {
					float a = stack.Pop ();
					float b = stack.Pop ();
					switch (val) {
					case "+":
						stack.Push ((float) a + b);
						break;
					case "-":
						stack.Push ((float) b - a);
						break;
					case "/":
						if (a == 0.0) {
							answer = "NaN";
							return;
						}
						stack.Push ((float) b / a);
						break;
					case "x":
						stack.Push ((float) a * b);
						break;
					}
				} else {
					stack.Push (float.Parse (val));
				}

			}

			answer = stack.Pop ().ToString ();

		}
	}
}

