using System;
using System.Windows;

namespace MoneyApp
{
    /// <summary>
    /// класс для работы с графическим интерфейсом
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// получение данных объекта А
        /// </summary>
        /// <returns>объект А</returns>
        private Money GetMoneyA()
        {
            try
            {
                uint rubles = uint.Parse(txtRublesA.Text);
                byte kopeks = byte.Parse(txtKopeksA.Text);
                return new Money(rubles, kopeks);
            }
            catch (Exception ex)
            {
                ShowStatus($"Ошибка в A: {ex.Message}");
                return new Money(0, 0);
            }
        }

        /// <summary>
        /// получение данных объекта В
        /// </summary>
        /// <returns>объект В</returns>
        private Money GetMoneyB()
        {
            try
            {
                uint rubles = uint.Parse(txtRublesB.Text);
                byte kopeks = byte.Parse(txtKopeksB.Text);
                return new Money(rubles, kopeks);
            }
            catch (Exception ex)
            {
                ShowStatus($"Ошибка в B: {ex.Message}");
                return new Money(0, 0);
            }
        }

        /// <summary>
        /// получение рублей для вычитания
        /// </summary>
        /// <returns></returns>
        private uint GetRublesToSubtract()
        {
            try
            {
                return uint.Parse(txtSubtractRubles.Text);
            }
            catch (Exception ex)
            {
                ShowStatus($"Ошибка в рублях для вычитания: {ex.Message}");
                return 0;
            }
        }

        /// <summary>
        /// вывод результата
        /// </summary>
        /// <param name="operation">строка</param>
        /// <param name="result">объект Money</param>
        private void ShowResult(string operation, Money result)
        {
            txtResults.Text = $"{operation}: {result}";
            ShowStatus($"Операция '{operation}' успешно выполнена");
        }

        /// <summary>
        /// вывод сообщения
        /// </summary>
        /// <param name="message">строка</param>
        private void ShowStatus(string message)
        {
            txtStatus.Text = message;
        }

        /// <summary>
        /// вычитание объектов
        /// </summary>
        private void BtnSubtract_Click(object sender, RoutedEventArgs e)
        {
            Money a = GetMoneyA();
            Money b = GetMoneyB();
            Money result = a - b;
            ShowResult("A - B", result);
        }

        /// <summary>
        /// увеличение объекта А на копейку
        /// </summary>
        private void BtnIncrementA_Click(object sender, RoutedEventArgs e)
        {
            Money a = GetMoneyA();
            a++;
            ShowResult("A++", a);
            UpdateMoneyA(a);
        }

        /// <summary>
        /// уменьшение объекта А на копейку
        /// </summary>
        private void BtnDecrementA_Click(object sender, RoutedEventArgs e)
        {
            Money a = GetMoneyA();
            a--;
            ShowResult("A--", a);
            UpdateMoneyA(a);
        }

        /// <summary>
        /// увеличение объекта В на копейку
        /// </summary>
        private void BtnIncrementB_Click(object sender, RoutedEventArgs e)
        {
            Money b = GetMoneyB();
            b++;
            ShowResult("B++", b);
            UpdateMoneyB(b);
        }

        /// <summary>
        /// уменьшение объекта В на копейку
        /// </summary>
        private void BtnDecrementB_Click(object sender, RoutedEventArgs e)
        {
            Money b = GetMoneyB();
            b--;
            ShowResult("B--", b);
            UpdateMoneyB(b);
        }

        /// <summary>
        /// вычитание объекта из введеного числа
        /// </summary>
        private void BtnSubtractRublesFromA_Click(object sender, RoutedEventArgs e)
        {
            Money a = GetMoneyA();
            uint rubles = GetRublesToSubtract();
            Money result = a - rubles;
            ShowResult($"A - {rubles} рублей", result);
        }

        /// <summary>
        /// вычитание введеного числа из объекта
        /// </summary>
        private void BtnSubtractAFromRubles_Click(object sender, RoutedEventArgs e)
        {
            Money a = GetMoneyA();
            uint rubles = GetRublesToSubtract();
            Money result = rubles - a;
            ShowResult($"{rubles} рублей - A", result);
        }

        /// <summary>
        /// изменение выода рублей и копеек объекта А
        /// </summary>
        /// <param name="money">объект Money</param>
        private void UpdateMoneyA(Money money)
        {
            txtRublesA.Text = money.Rubles.ToString();
            txtKopeksA.Text = money.Kopeks.ToString();
        }

        /// <summary>
        /// изменение выода рублей и копеек объекта В
        /// </summary>
        /// <param name="money">объект Money</param>
        private void UpdateMoneyB(Money money)
        {
            txtRublesB.Text = money.Rubles.ToString();
            txtKopeksB.Text = money.Kopeks.ToString();
        }
    }
}