using System;
using Xamarin.Forms;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {

        public float FirstOperand { get; set; }
        public float SecondOperand { get; set; }
        public string Operator { get; set; }
        public float Result { get; set; }
        

        public MainPage()
        {
            InitializeComponent();
        }

       

        private void OnClick(object sender, EventArgs e)
        {
            var text = (sender as Button).Text;
            switch (text)
            {
                case "0":
                    Entry.Text += "0";
                    break;
                case "1":
                    Entry.Text += "1";
                    break;
                case "2":
                    Entry.Text += "2";
                    break;
                case "3":
                    Entry.Text += "3";
                    break;
                case "4":
                    Entry.Text += "4";
                    break;
                case "5":
                    Entry.Text += "5";
                    break;
                case "6":
                    Entry.Text += "6";
                    break;
                case "7":
                    Entry.Text += "7";
                    break;
                case "8":
                    Entry.Text += "8";
                    break;
                case "9":
                    Entry.Text += "9";
                    break;
                case ".":
                    Entry.Text += ".";
                    break;
                default:
                    HandleOperation(text);
                    break;
            }
            
        }

        public void HandleOperation(string text)
        {
            switch (text)
            {
                case "C":
                    Entry.Text = string.Empty;
                    break;
                case "DEL":
                    if (Entry.Text.Length != 0)
                        Entry.Text = Entry.Text.Remove(Entry.Text.Length - 1);
                    break;
                case "%":
                    GeFirstOperandAndOperator("%");
                    break;
                case "/":
                    GeFirstOperandAndOperator("/");
                    break;
                case "x":
                    GeFirstOperandAndOperator("X");
                    break;
                case "-":
                    GeFirstOperandAndOperator("-");
                    break;
                case "+":
                    GeFirstOperandAndOperator("+");
                    break;
                case "=":
                    SecondOperand = float.Parse(Entry.Text);
                    Entry.Text = Calculate().ToString();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


        private void GeFirstOperandAndOperator(string text)
        {
            Operator = text;
            if (!float.IsNaN(FirstOperand)) FirstOperand = float.Parse(Entry.Text);
            Entry.Text = string.Empty;
        }


        private float Calculate()
        {
            switch (Operator)
            {
                case "%":
                    Result = FirstOperand % SecondOperand;
                    break;
                case "/":
                    Result = FirstOperand / SecondOperand;
                    break;
                case "X":
                    Result = FirstOperand * SecondOperand;
                    break;
                case "-":
                    Result = FirstOperand - SecondOperand;
                    break;
                case "+":
                    Result = FirstOperand + SecondOperand;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return Result;
        }
    }
}
