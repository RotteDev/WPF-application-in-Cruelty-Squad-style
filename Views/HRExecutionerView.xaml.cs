using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace A_corporate_bureaucratic_application_for_optimizing_managers_and_their_professional_activities.Views
{
    public partial class HRExecutionerView : UserControl
    {
        private class Employee
        {
            public string Name;
            public string FleshType;
            public double Loyalty;
            public double Effectiveness;
            public TimeSpan UpdateInterval;
            public DateTime LastUpdate;
            public TextBlock NameText;
            public TextBlock FleshText;
            public TextBlock LoyaltyText;
            public TextBlock EffectivenessText;
            public Border Root;
        }

        private const int MaxEmployees = 25;

        private readonly List<Employee> _employees = new List<Employee>();
        private readonly Random _random = new Random();

        private DispatcherTimer _mainTimer;
        private DispatcherTimer _cpuTimer;
        private DispatcherTimer _spawnTimer;

        private PerformanceCounter _cpuCounter;
        private PerformanceCounter _ramPercentCounter;
        private PerformanceCounter _ramAvailableCounter;

        private readonly string[] _prefixes = { "SUBJECT", "UNIT", "ASSET", "WORKER" };
        private readonly string[] _fleshTypes = { "POWER IN MISERY", "FLESH AUTOMATON", "DIVINE LIGHT" };

        private static readonly Brush RedBrush = new SolidColorBrush(Color.FromRgb(255, 0, 0));
        private static readonly Brush BlackBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        private static readonly Brush GreenBrush = new SolidColorBrush(Color.FromRgb(50, 205, 50));

        private bool _searchMode = false;

        private MainScreen GetMainScreen()
        {
            return Window.GetWindow(this) as MainScreen;
        }


        public HRExecutionerView()
        {
            InitializeComponent();

            _mainTimer = new DispatcherTimer();
            _mainTimer.Interval = TimeSpan.FromMilliseconds(800);
            _mainTimer.Tick += MainTimer_Tick;
            _mainTimer.Start();

            _cpuTimer = new DispatcherTimer();
            _cpuTimer.Interval = TimeSpan.FromSeconds(2);
            _cpuTimer.Tick += CpuTimer_Tick;
            _cpuTimer.Start();

            try
            {
                _cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                _cpuCounter.NextValue();

                _ramPercentCounter = new PerformanceCounter("Memory", "% Committed Bytes In Use");
                _ramPercentCounter.NextValue();

                _ramAvailableCounter = new PerformanceCounter("Memory", "Available MBytes");
                _ramAvailableCounter.NextValue();
            }
            catch
            {
                _cpuCounter = null;
            }

            _spawnTimer = new DispatcherTimer();
            _spawnTimer.Interval = TimeSpan.FromSeconds(3);
            _spawnTimer.Tick += SpawnTimer_Tick;
            _spawnTimer.Start();
        }

        private void SpawnTimer_Tick(object sender, EventArgs e)
        {
            if (_searchMode) return;

            if (_employees.Count >= MaxEmployees)
            {
                _spawnTimer.Stop();
                return;
            }

            AddEmployee();
        }

        private string GenerateId()
        {
            string prefix = _prefixes[_random.Next(_prefixes.Length)];
            char letter = (char)('A' + _random.Next(26));
            int d1 = _random.Next(100000000, 999999999);
            int d2 = _random.Next(10000000, 99999999);
            string state = _random.Next(2) == 0 ? "STABLE" : "UNSTABLE";

            return $"{prefix}-{letter}-{d1}-{d2}-{state}";
        }

        private string GenerateNameFromId(string id)
        {
            var parts = id.Split('-');
            if (parts.Length >= 2) return $"{parts[0]}-{parts[1]}";
            return id;
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
{
    SoundManager.Play("HRClearSound.mp3");

    _searchMode = false;

    EmployeesPanel.Children.Clear();
    _employees.Clear();

    _spawnTimer.Stop();
    _spawnTimer.Start();

    AddEmployee();
}
        private void AddEmployee(string customId = null)
        {
            string id = customId ?? GenerateId();
            string name = GenerateNameFromId(id);

            bool isPlayer = (id == SettingsStorage.PlayerID);

            var employee = new Employee
            {
                Name = name,
                FleshType = isPlayer ? "DIVINE LIGHT" : _fleshTypes[_random.Next(_fleshTypes.Length)],
                Loyalty = isPlayer ? 50.0 + (_random.NextDouble() - 0.5) * 5 : _random.NextDouble() * 100,
                Effectiveness = isPlayer ? 50.0 + (_random.NextDouble() - 0.5) * 5 : _random.NextDouble() * 100,
                UpdateInterval = TimeSpan.FromSeconds(_random.NextDouble() * 3 + 0.5),
                LastUpdate = DateTime.Now
            };

            var root = new Border
            {
                Background = Brushes.White,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(1),
                Margin = new Thickness(0, 1, 0, 1),
                Padding = new Thickness(4, 2, 4, 2),
                Tag = id
            };

            var grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(90) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(100) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(80) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(90) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            var nameText = MakeText(name, 11);
            Grid.SetColumn(nameText, 0);
            grid.Children.Add(nameText);

            var fleshText = MakeText(employee.FleshType, 9);
            Grid.SetColumn(fleshText, 1);
            grid.Children.Add(fleshText);

            var loyaltyText = MakeText("", 11);
            Grid.SetColumn(loyaltyText, 2);
            grid.Children.Add(loyaltyText);

            var effectivenessText = MakeText("", 11);
            Grid.SetColumn(effectivenessText, 3);
            grid.Children.Add(effectivenessText);

            var liquidateButton = new Button
            {
                Content = "[LIQUIDATE]",
                FontFamily = (FontFamily)FindResource("MingLiUFont"),
                FontSize = 10,
                Foreground = Brushes.Red,
                Background = Brushes.Transparent,
                BorderBrush = Brushes.Red,
                BorderThickness = new Thickness(1),
                Padding = new Thickness(4, 2, 4, 2),
                Cursor = Cursors.None,
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 0, 2, 0)
            };
            liquidateButton.Click += (s, e) => LiquidateEmployee(employee, id);
            Grid.SetColumn(liquidateButton, 4);
            grid.Children.Add(liquidateButton);

            root.Child = grid;

            employee.NameText = nameText;
            employee.FleshText = fleshText;
            employee.LoyaltyText = loyaltyText;
            employee.EffectivenessText = effectivenessText;
            employee.Root = root;

            _employees.Add(employee);
            EmployeesPanel.Children.Add(root);

            UpdateEmployeeDisplay(employee);
        }


        private TextBlock MakeText(string text, double size)
        {
            return new TextBlock
            {
                Text = text,
                FontFamily = (FontFamily)FindResource("MingLiUFont"),
                FontSize = size,
                Foreground = BlackBrush,
                VerticalAlignment = VerticalAlignment.Center,
                TextWrapping = TextWrapping.Wrap
            };
        }

        private void UpdateEmployeeDisplay(Employee e)
        {
            e.LoyaltyText.Text = $"{e.Loyalty:F1}";
            e.EffectivenessText.Text = $"{e.Effectiveness:F1}";

            e.LoyaltyText.Foreground = GetValueBrush(e.Loyalty);
            e.EffectivenessText.Foreground = GetValueBrush(e.Effectiveness);
        }

        private Brush GetValueBrush(double value)
        {
            if (value < 34) return RedBrush;
            if (value < 67) return BlackBrush;
            return GreenBrush;
        }
        private void LiquidateEmployee(Employee e, string id)
        {
            SoundManager.Play("HRKillasset.mp3");

            if (id == SettingsStorage.PlayerID)
            {
                SettingsStorage.SelfKilled = true;
                SettingsStorage.CurrentUI = 1;
                SettingsStorage.MentalTestLastPassed = false;
                Environment.Exit(1);
                return;
            }

            _employees.Remove(e);
            EmployeesPanel.Children.Remove(e.Root);

            if (!_searchMode)
                AddEmployee();
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;

            foreach (var emp in _employees)
            {
                if (now - emp.LastUpdate >= emp.UpdateInterval)
                {
                    emp.Loyalty += (_random.NextDouble() - 0.5) * 3.0;
                    emp.Effectiveness += (_random.NextDouble() - 0.5) * 3.0;

                    emp.Loyalty = Math.Max(0, Math.Min(100, emp.Loyalty));
                    emp.Effectiveness = Math.Max(0, Math.Min(100, emp.Effectiveness));

                    emp.UpdateInterval = TimeSpan.FromSeconds(_random.NextDouble() * 3 + 0.5);
                    emp.LastUpdate = now;

                    UpdateEmployeeDisplay(emp);
                }
            }
        }

        private void CpuTimer_Tick(object sender, EventArgs e)
        {
            float cpu = 0, ramPercent = 0, ramAvailable = 0;

            try
            {
                if (_cpuCounter != null) cpu = _cpuCounter.NextValue();
                if (_ramPercentCounter != null) ramPercent = _ramPercentCounter.NextValue();
                if (_ramAvailableCounter != null) ramAvailable = _ramAvailableCounter.NextValue();
            }
            catch { }

            CpuLoadText.Text = $"CPU: {cpu:F0}%  RAM: {ramPercent:F0}% ({ramAvailable:F0}MB)";
        }
        private void SearchIdBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            bool valid = Regex.IsMatch(e.Text, @"^[A-Za-z\-0-9]+$");

            if (!valid)
            {
                e.Handled = true;
                return;
            }
            string file = _random.Next(2) == 0 ? "HRTypeSound1.mp3" : "HRTypeSound2.mp3";
            double volume = 0.4 + _random.NextDouble() * 0.4;
            SoundManager.PlayWithVolume(file, volume);
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            SoundManager.Play("HRSearchSound.mp3");

            if (SettingsStorage.CurrentUI != 3)
            {
                GetMainScreen()?.ShowNotice("ACCESS DENIED: DIVINE LIGHT REQUIRED.");
                return;
            }

            if (!SettingsStorage.MentalTestLastPassed)
            {
                GetMainScreen()?.ShowNotice("ACCESS DENIED: MENTAL WEAR SCREENING NOT PASSED.");
                return;
            }

            string input = SearchIdBox.Text.Trim().ToUpper();

            string pattern = @"^(SUBJECT|UNIT|ASSET|WORKER)-[A-Z]-\d{9}-\d{8}-(STABLE|UNSTABLE)$";

            if (!Regex.IsMatch(input, pattern))
            {
                GetMainScreen()?.ShowNotice("INVALID ID SYNTAX.");
                return;
            }

            _searchMode = true;

            EmployeesPanel.Children.Clear();
            _employees.Clear();

            AddEmployee(input);

            SearchIdBox.Text = "";
        }

        private void ClearSearchButton_Click(object sender, RoutedEventArgs e)
        {
            SoundManager.Play("HRClearSound.mp3");
            SearchIdBox.Text = "";
        }

        public void OnClosed()
        {
            _mainTimer.Stop();
            _cpuTimer.Stop();
            _spawnTimer.Stop();

            _cpuCounter?.Dispose();
            _ramPercentCounter?.Dispose();
            _ramAvailableCounter?.Dispose();
        }
    }
}