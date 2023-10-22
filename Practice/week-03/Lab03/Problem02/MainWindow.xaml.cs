using System;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace Problem02 {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		#region Data Members
		private double firstNumber;
		private double secondNumber;
		private double result;

		private enum Operation {
			NO_OPERATION,
			ADDITION,
			SUBSTRACTION,
			MULTIPLICATION,
			DIVIDISION
		}

		private Operation operation;
		#endregion

		#region Constructor
		public MainWindow() {
			InitializeComponent();
			operation = Operation.NO_OPERATION;
		} 
		#endregion

		private void BtnOff_Click(object sender, RoutedEventArgs e) {
			Environment.Exit(0);
		}

		/// <summary>
		/// Event handler for digit click
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Digit_Click(object sender, RoutedEventArgs e) {
			string digit = ((Button)sender).Content.ToString();

			if(TxtInput.Text == "0") {
				TxtInput.Text = digit;
			}
			else {
				if(digit == "," && !TxtInput.Text.Contains(",")) {
					return;
				}

				TxtInput.Text = $"{TxtInput.Text}{digit}";
			}
		}

		private void Operation_Click(object sender, RoutedEventArgs e) {
			if (!double.TryParse(TxtInput.Text, out firstNumber)) {
				MessageBox.Show("Wrong input");
				TxtInput.Text = "0";
				return;
			}

			string operationSign = ((Button)sender).Content.ToString()!;
			operation = operationSign switch {
				"+" => operation = Operation.ADDITION,
				"-" => operation = Operation.SUBSTRACTION,
				"*" => operation = Operation.MULTIPLICATION,
				"/" => operation = Operation.DIVIDISION,
				_ => operation = Operation.NO_OPERATION
			};

			TxtInput.Text = "0";
		}

		private void Compte_Click(object sender, RoutedEventArgs e) {
			if(!double.TryParse(TxtInput.Text, out secondNumber)) {
				MessageBox.Show("Wrong input");
				TxtInput.Text = "0";
				return;
			}

			result = operation switch {
				Operation.ADDITION => result = firstNumber + secondNumber,
				Operation.SUBSTRACTION => result = firstNumber - secondNumber,
				Operation.MULTIPLICATION => result = firstNumber * secondNumber,
				Operation.DIVIDISION => result = firstNumber / secondNumber,
				Operation.NO_OPERATION => 0
			};

			operation = Operation.NO_OPERATION;
			TxtInput.Text = result.ToString();
		}
	}
}
