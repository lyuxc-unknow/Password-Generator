using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace PasswordGen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private static FileStream fileStream = new(Directory.GetCurrentDirectory() + "\\passwordBoox.txt", FileMode.Append);
        private static StreamWriter writer = new(fileStream);


        public static string randomStr(int val)
        {
            switch (val)
            {
                case 0: return "a";
                case 1: return "b";
                case 2: return "c";
                case 3: return "d";
                case 4: return "e";
                case 5: return "f";
                case 6: return "g";
                case 7: return "h";
                case 8: return "i";
                case 9: return "j";
                case 10: return "k";
                case 11: return "l";
                case 12: return "m";
                case 13: return "n";
                case 14: return "o";
                case 15: return "p";
                case 16: return "q";
                case 17: return "r";
                case 18: return "s";
                case 19: return "t";
                case 20: return "u";
                case 21: return "v";
                case 22: return "w";
                case 23: return "x";
                case 24: return "y";
                case 25: return "z";
                default: return "";
            }
        }

        public static string randomUpStr(int val)
        {
            switch (val)
            {
                case 0: return "A";
                case 1: return "B";
                case 2: return "C";
                case 3: return "D";
                case 4: return "E";
                case 5: return "F";
                case 6: return "g";
                case 7: return "H";
                case 8: return "I";
                case 9: return "J";
                case 10: return "K";
                case 11: return "L";
                case 12: return "M";
                case 13: return "N";
                case 14: return "O";
                case 15: return "P";
                case 16: return "Q";
                case 17: return "R";
                case 18: return "S";
                case 19: return "T";
                case 20: return "U";
                case 21: return "V";
                case 22: return "W";
                case 23: return "X";
                case 24: return "Y";
                case 25: return "Z";
                default: return "";
            }
        }

        public static string randomNum(int val)
        {
            switch (val)
            {
                case 0: return "0";
                case 1: return "1";
                case 2: return "2";
                case 3: return "3";
                case 4: return "4";
                case 5: return "5";
                case 6: return "6";
                case 7: return "7";
                case 8: return "8";
                case 9: return "9";
                default: return "";
            }
        }

        public static string randomChr(int val)
        {
            switch (val)
            {
                case 0: return "*";
                case 1: return "/";
                case 2: return "$";
                case 3: return "!";
                case 4: return ";";
                case 5: return "&";
                case 6: return "@";
                case 7: return "%";
                case 8: return "[";
                case 9: return "]";
                default: return "";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PasswordTextBox.Text = null;
            int a = 0;
            Random random = new Random();
            if (conboBoxCh.IsChecked == true) a += 1;
            if (comboBoxNum.IsChecked == true) a += 1;
            if (comboBoxStr.IsChecked == true) a += 1;
            if (comboBoxUpStr.IsChecked == true) a += 1;
            if (int.TryParse(count.Text, out int number))
            {
                for (int i = 0; i < int.Parse(count.Text); i++)
                {
                    switch (random.Next(0, 4))
                    {
                        case 0:
                            if (conboBoxCh.IsChecked == true)//字符
                            {
                                PasswordTextBox.Text += randomChr(random.Next(0, 9));
                            }
                            break;
                        case 1:
                            if (comboBoxNum.IsChecked == true)//数字
                            {
                                PasswordTextBox.Text += randomNum(random.Next(0, 9));
                            }
                            break;
                        case 2:
                            if (comboBoxStr.IsChecked == true)//字母
                            {
                                PasswordTextBox.Text += randomStr(random.Next(0, 25));
                            }
                            break;
                        case 3:
                            if (comboBoxUpStr.IsChecked == true)//大写字母
                            {
                                PasswordTextBox.Text += randomUpStr(random.Next(0, 25));
                            }
                            break;
                    }
                }
            }
            //for (int i = 0; i < a * int.Parse(count.Text); i++)
            //{
            //    if(PasswordTextBox is not null)
            //    {
            //        PasswordTextBox.Text.Insert(random.Next(0, int.Parse(count.Text)), "");
            //    }
            //}
            writer.WriteLine("[" + DateTime.Now.ToString("F") + "]    " + PasswordTextBox.Text);

        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (!int.TryParse(count.Text, out int number))
            {
                tips.Content = "数量输入有误,请修改";
                return;
            }
            else
            {
                tips.Content = " ";
                return;
            }
        }

        private void Window_Close(object sender, System.ComponentModel.CancelEventArgs e)
        {
            writer.Close();
            fileStream.Close();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            writer.AutoFlush = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Process.Start("notepad.exe",Directory.GetCurrentDirectory() + "\\passwordBoox.txt");
        }
    }
}
