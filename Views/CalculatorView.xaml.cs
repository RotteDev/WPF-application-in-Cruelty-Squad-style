using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace A_corporate_bureaucratic_application_for_optimizing_managers_and_their_professional_activities.Views
{
    public partial class CalculatorView : UserControl
    {
        private string _currentInput = "0";
        private double _accumulator = 0;
        private string _pendingOperator = "";
        private bool _freshInput = true;

        public CalculatorView()
        {
            InitializeComponent();
            BuildCalculatorButtons();
        }

        private void BuildCalculatorButtons()
        {
            string[,] buttons =
            {
        { "7", "8", "9", "/" },
        { "4", "5", "6", "*" },
        { "1", "2", "3", "-" },
        { "0", ".", "=", "+" },
        { "C", "", "", "" }
    };

            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    string label = buttons[row, col];
                    if (string.IsNullOrEmpty(label)) continue;

                    var btn = new Button
                    {
                        Content = label,
                        Style = (Style)FindResource("CalcButtonStyle"),
                        Tag = label
                    };

                    if (label == "C")
                        btn.Foreground = Brushes.Red;

                    btn.Click += (s, e) =>
                    {
                        SoundManager.Play("CalculatorSound.mp3");
                        OnCalcButtonClick(label);
                    };

                    Grid.SetRow(btn, row);
                    Grid.SetColumn(btn, col);

                    CalcGrid.Children.Add(btn);
                }
            }
        }

        private void OnCalcButtonClick(string label)
        {
            switch (label)
            {
                case "C":
                    _currentInput = "0";
                    _accumulator = 0;
                    _pendingOperator = "";
                    _freshInput = true;
                    break;

                case "+":
                case "-":
                case "*":
                case "/":
                    if (double.TryParse(_currentInput, NumberStyles.Any, CultureInfo.InvariantCulture, out double acc))
                        _accumulator = acc;
                    _pendingOperator = label;
                    _freshInput = true;
                    break;

                case "=":
                    if (!string.IsNullOrEmpty(_pendingOperator))
                    {
                        if (double.TryParse(_currentInput, NumberStyles.Any, CultureInfo.InvariantCulture, out double second))
                        {
                            double result = 0;
                            switch (_pendingOperator)
                            {
                                case "+": result = _accumulator + second; break;
                                case "-": result = _accumulator - second; break;
                                case "*": result = _accumulator * second; break;
                                case "/":
                                    if (second == 0) { _currentInput = "ERROR"; _freshInput = true; DisplayText.Text = _currentInput; return; }
                                    result = _accumulator / second;
                                    break;
                            }
                            _currentInput = result.ToString(CultureInfo.InvariantCulture);
                        }
                        _pendingOperator = "";
                        _freshInput = true;
                    }
                    break;

                case ".":
                    if (!_currentInput.Contains("."))
                        _currentInput += ".";
                    _freshInput = false;
                    break;

                default:
                    if (_freshInput)
                    {
                        _currentInput = label;
                        _freshInput = false;
                    }
                    else
                    {
                        if (_currentInput == "0") _currentInput = label;
                        else _currentInput += label;
                    }
                    break;
            }

            DisplayText.Text = _currentInput;
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            SoundManager.Play("CalculatorSound.mp3");
            if (!double.TryParse(AgeInput.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double age) ||
                !double.TryParse(SalaryInput.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double salaryPerYear) ||
                !double.TryParse(CaloriesInput.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double caloriesPerDay))
            {
                ResultText.Text = "INVALID INPUT.";
                ResultText.Foreground = Brushes.Red;
                return;
            }

            if (age <= 0 || salaryPerYear < 0 || caloriesPerDay <= 0)
            {
                ResultText.Text = "INVALID VALUES.";
                ResultText.Foreground = Brushes.Red;
                return;
            }

            double yearsLeft = Math.Max(0, 100 - age);
            double totalEarned = salaryPerYear * yearsLeft;
            double totalCalories = caloriesPerDay * 365 * yearsLeft;
            double totalCost = totalCalories * 0.005;
            double profitability = totalEarned - totalCost;

            string verdict;
            Brush color;

            if (profitability > 1_000_000)
            {
                verdict = "HIGHLY PROFITABLE ASSET.";
                color = Brushes.Green;
            }
            else if (profitability > 0)
            {
                verdict = "MARGINALLY LIQUID.";
                color = Brushes.Black;
            }
            else
            {
                verdict = "UNPROFITABLE. CONSIDER LIQUIDATION.";
                color = Brushes.Red;
            }

            ResultText.Foreground = color;
            ResultText.Text = $"PROFITABILITY: {profitability:F0} CREDITS.\n{verdict}";
        }

        public void OnClosed()
        {
        }
    }
}