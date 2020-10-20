using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x415

namespace Sasinator
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        bool tryb = false;

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            double sasiny = 0;
            if (String.IsNullOrEmpty(Liczba.Text))
            {
                Sasin.PlaceholderText = "Wpisz poprawną liczbę";
            }
            else if (tryb == false)
            {
                int test;
                if (!int.TryParse(Liczba.Text, out test))
                {
                    Sasin.PlaceholderText = "Wpisz poprawną liczbę";
                }
                else
                {
                    sasiny = Int64.Parse(Liczba.Text);
                    czysto();
                    Progress.Visibility = Visibility.Visible;
                    for (int i = 1; i <= 100; i++)
                    {
                        Progress.Value = Progress.Value + 1;
                        await Task.Delay(5);
                    }
                    sasiny = sasiny / 70000000;
                    sasiny = Math.Round(sasiny, 13);
                    Progress.Value = 100;
                    Sasin.Text = sasiny.ToString("F13");
                    await Task.Delay(250);
                    Progress.Visibility = Visibility.Collapsed;
                    Progress.Value = 0;
                }
            }
            else if (tryb == true)
            {
                double test;
                if (!double.TryParse(Liczba.Text, out test))
                {
                    Sasin.PlaceholderText = "Wpisz poprawną liczbę";
                }
                else
                {
                    sasiny = Double.Parse(Liczba.Text);
                    czysto();
                    Progress.Visibility = Visibility.Visible;
                    for (int i = 1; i <= 100; i++)
                    {
                        Progress.Value = Progress.Value + 1;
                        await Task.Delay(5);
                    }
                    sasiny = sasiny * 70000000;
                    sasiny = Math.Round(sasiny, 0);
                    Progress.Value = 100;
                    Sasin.Text = sasiny.ToString();
                    await Task.Delay(250);
                    Progress.Visibility = Visibility.Collapsed;
                    Progress.Value = 0;
                }
            }
        }

        private void Zmiana_Click(object sender, RoutedEventArgs e)
        {
            tryb = !tryb;
            if(tryb == false)
            {
                znak.Text = "=";
                jednostka.Text = "sasina";
            }
            else
            {
                znak.Text = "sasinów = ";
                jednostka.Text = "";
            }

            czysto();
        }

        void czysto()
        {
            Sasin.Text = "";
            Sasin.PlaceholderText = "";
        }

        private void Liczba_GotFocus(object sender, RoutedEventArgs e)
        {
            Liczba.Text = "";
        }
    }
}
