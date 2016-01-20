using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Calculator
{
	public class InfixConverter
	{
		public string postfixString { get; set; }
		private string infixString;

		public InfixConverter (string expr)
		{
			infixString = expr;
			convert ();
		}

		public void convert() {

			Stack<char> stack = new Stack<char> ();

			for (int i = 0; i < infixString.Length; i++) {
				string tmp = "";
				char c = infixString [i];

				while ("0123456789".IndexOf (c) >= 0) {
					tmp += c;
					c = infixString [++i];
				}

				if (tmp != "") {
					postfixString += tmp + " ";
					i--;
				} else if ("+-/x".IndexOf(c) >= 0) {
					// stack is empty, push operator
					if (stack.Count == 0) {
						Debug.WriteLine ("Pushing to empty stack");
						stack.Push (c);
					} else {
						// if top of stack has higher precedence
						char topStack = stack.Peek();
						Debug.WriteLine ("Top of stack: " + topStack);
						while (hasPrecedence(topStack, c) && stack.Count > 0) {
							Debug.WriteLine ("Popping from stack because " + topStack + " has precedence over " + c);
							char popped = stack.Pop ();
							postfixString += popped + " ";
							if (stack.Count > 0)
								topStack = stack.Peek ();
	
							Debug.WriteLine ("Post-fix string: " + postfixString);
						}

						stack.Push (c);

					}
				}
			}

			foreach (char c in stack) {
				postfixString += c + " ";
			}

		}

		private bool hasPrecedence(char a, char b) {
			switch (a) {
			case 'x':
			case '/':
				return true;
			case '-':
			case '+':
				if (b == 'x' || b == '/')
					return false;
				else
					return true;
			default:
				return true;
			}
		}
	}
}

