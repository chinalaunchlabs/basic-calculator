using System;
using Xamarin.Forms;

namespace Calculator
{
	public class CalcView : ContentPage
	{
		private class NumberButton: Button
		{
			private Label _label;
			public NumberButton(string num, Label label) {
				this._label = label;
				this.Text = num;

				this.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button));
				this.BackgroundColor = Color.FromHex("00A9BA");
				this.TextColor = Color.White;

				// event handler
				this.Clicked += (sender, e) => {
					this._label.Text += this.Text;
				};
			}
		}

		private class OperatorButton: Button
		{
			private Label _label;
			public OperatorButton(string op, Label label) {
				this._label = label;
				this.Text = op;
				this.BackgroundColor = Color.FromHex("FFB113");
				this.TextColor = Color.White;
//				this.BorderWidth = 1;
//				this.BorderRadius = 1;
				this.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button));

				// event handler
				this.Clicked += (sender, e) => {
					this._label.Text += this.Text;
				};
			}
		}

		public CalcView ()
		{

			Grid calcGrid = new Grid {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				RowDefinitions = {
					new RowDefinition { Height = new GridLength (2, GridUnitType.Star) },
					new RowDefinition { Height = new GridLength (1, GridUnitType.Star) },
					new RowDefinition { Height = new GridLength (1, GridUnitType.Star) },
					new RowDefinition { Height = new GridLength (1, GridUnitType.Star) },
					new RowDefinition { Height = new GridLength (1, GridUnitType.Star) },
					new RowDefinition { Height = new GridLength (1, GridUnitType.Star) },
				},
				ColumnDefinitions = {
					new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) },
					new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) },
					new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) },
					new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) },
				},
				BackgroundColor = Color.White,
				RowSpacing = 2,
				ColumnSpacing = 2,
			};

			Frame frame = new Frame {
				Content = calcGrid,
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(5),
				BackgroundColor = Color.White
			};

			Content = frame;
			Padding = new Thickness (5, Device.OnPlatform (20, 0, 0), 5, 5);

			Label viewLabel = new Label {
				Text = "",
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.FromRgb(0.99, 0.99, 0.99),
				TextColor = Color.Black
			};

			Button buttonAC = new Button {
				Text = "AC",
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
				BackgroundColor = Color.FromHex("BA0030"),
				TextColor = Color.White,
				FontAttributes = FontAttributes.Bold,
//				BorderRadius = 1,
//				BorderWidth = 1,
			};
			NumberButton button0 = new NumberButton ("0", viewLabel);
			NumberButton button1 = new NumberButton ("1", viewLabel);
			NumberButton button2 = new NumberButton ("2", viewLabel);
			NumberButton button3 = new NumberButton ("3", viewLabel);
			NumberButton button4 = new NumberButton ("4", viewLabel);
			NumberButton button5 = new NumberButton ("5", viewLabel);
			NumberButton button6 = new NumberButton ("6", viewLabel);
			NumberButton button7 = new NumberButton ("7", viewLabel);
			NumberButton button8 = new NumberButton ("8", viewLabel);
			NumberButton button9 = new NumberButton ("9", viewLabel);
			NumberButton buttonDot = new NumberButton (".", viewLabel);
			NumberButton buttonParen1 = new NumberButton ("(", viewLabel);
			NumberButton buttonParen2 = new NumberButton (")", viewLabel);

			OperatorButton buttonPlus = new OperatorButton ("+", viewLabel);
			OperatorButton buttonMinus = new OperatorButton ("-", viewLabel);
			OperatorButton buttonMult = new OperatorButton ("x", viewLabel);
			OperatorButton buttonDiv = new OperatorButton ("/", viewLabel);
			OperatorButton buttonEq = new OperatorButton ("=", viewLabel);

			buttonEq.Clicked += (sender, e) => {
				string expr = viewLabel.Text;
				InfixConverter converter = new InfixConverter(expr);
				PostfixCalculator calc = new PostfixCalculator(converter.postfixString);
//				viewLabel.Text = calc.answer;
				viewLabel.Text += "\n" + calc.answer;
			};

			buttonAC.Clicked += (sender, e) =>  {
				viewLabel.Text = "";
			};


			// numbers
			calcGrid.Children.Add (button9, 2, 2);
			calcGrid.Children.Add (button8, 1, 2);
			calcGrid.Children.Add (button7, 0, 2);
			calcGrid.Children.Add (button6, 2, 3);
			calcGrid.Children.Add (button5, 1, 3);
			calcGrid.Children.Add (button4, 0, 3);
			calcGrid.Children.Add (button3, 2, 4);
			calcGrid.Children.Add (button2, 1, 4);
			calcGrid.Children.Add (button1, 0, 4);
			calcGrid.Children.Add (button0, 0, 2, 5, 6);
			calcGrid.Children.Add (buttonDot, 2, 5);

			// operators 
			calcGrid.Children.Add (buttonPlus, 3, 1);
			calcGrid.Children.Add (buttonMinus, 3, 2);
			calcGrid.Children.Add (buttonMult, 3, 3);
			calcGrid.Children.Add (buttonDiv, 3, 4);
			calcGrid.Children.Add (buttonEq, 3, 5);
		
			// misc
			calcGrid.Children.Add (buttonAC, 0, 1);
			calcGrid.Children.Add (buttonParen1, 1, 1);
			calcGrid.Children.Add (buttonParen2, 2, 1);
			calcGrid.Children.Add (viewLabel, 0, 4, 0, 1);

		}
	}
}

