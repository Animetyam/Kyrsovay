using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace kyrsah
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DateTime dt = DateTime.Now;
            if (dt.Hour >= 5 && dt.Hour < 12)
            {
                List.Text = "Доброе Утро!!!\n\nЯ умею пользоваться шифром Виженера!\nВыберите необходимую вам опцию.";
            }
            else if (dt.Hour >= 12 && dt.Hour < 18)
            {
                List.Text = "Добрый День!!!\n\nЯ умею пользоваться шифром Виженера!\nВыберите необходимую вам опцию.";
            }
            else
            {
                List.Text = "Добрый Вечер!!!\n\nЯ умею пользоваться шифром Виженера!\nВыберите необходимую вам опцию.";
            }
        }
        public static string key = "скорпион";
        public static List<char> alphabet = new List<char>() { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };
        public static string decryptor(string path)
        {
            if (path == null || path == "")
            {
                return "Все плохо, нет пути";
            }
            List<int> sdvigi = new List<int>();
            foreach (var item in MainWindow.key)
            {
                if (item != ' ')
                {
                    sdvigi.Add(alphabet.IndexOf(item));
                }
            }
            string[] file = File.ReadAllLines(path);
            int i = 0;
            bool flag;
            List<string> newFile = new List<string>();
            foreach (var item in file)
            {
                string newStroka = "";
                foreach (var item2 in item)
                {
                    flag = false;
                    if (char.IsUpper(item2))
                    {
                        flag = true;
                    }
                    if (flag)
                    {
                        if (alphabet.Contains(char.ToLower(item2)))
                        {
                            if (alphabet.IndexOf(char.ToLower(item2)) - sdvigi[i] >= 0)
                            {
                                newStroka += Char.ToUpper(alphabet[alphabet.IndexOf(char.ToLower(item2)) - sdvigi[i]]);
                            }
                            else
                            {
                                newStroka += Char.ToUpper(alphabet[-sdvigi[i] + alphabet.IndexOf(char.ToLower(item2)) + 33]);
                            }
                            i++;
                            if (i == sdvigi.Count)
                            {
                                i = 0;
                            }
                        }
                        else
                        {
                            newStroka += item2;
                        }
                    }
                    else
                    {
                        if (alphabet.Contains(item2))
                        {
                            if (alphabet.IndexOf(item2) - sdvigi[i] >= 0)
                            {
                                newStroka += alphabet[alphabet.IndexOf(item2) - sdvigi[i]];
                            }
                            else
                            {
                                newStroka += alphabet[alphabet.IndexOf(item2) + 33 - sdvigi[i]];
                            }
                            i++;
                            if (i == sdvigi.Count)
                            {
                                i = 0;
                            }
                        }
                        else
                        {
                            newStroka += item2;
                        }
                    }
                }
                newFile.Add(newStroka);

            }
            string res = "";
            foreach (var item in newFile)
            {
                res += item + "\n";
            }
            return res;
        }
        public static string incryptor(string path, string key)
        {
            if (path == null || path == "")
            {
                return "Все плохо, нет пути";
            }
            if (key == null || key == "")
            {
                key = MainWindow.key;
            }
            List<int> sdvigi = new List<int>();
            foreach (var item in key)
            {
                if (item != ' ')
                {
                    sdvigi.Add(alphabet.IndexOf(item));
                }
            }
            string[] file = File.ReadAllLines(path);
            int i = 0;
            bool flag;
            List<string> newFile = new List<string>();
            foreach (var item in file)
            {
                string newStroka = "";
                foreach (var item2 in item)
                {
                    flag = false;
                    if (char.IsUpper(item2))
                    {
                        flag = true;
                    }
                    if (flag)
                    {
                        if (alphabet.Contains(char.ToLower(item2)))
                        {
                            if (sdvigi[i] + alphabet.IndexOf(char.ToLower(item2)) <= 32)
                            {
                                newStroka += Char.ToUpper(alphabet[sdvigi[i] + alphabet.IndexOf(char.ToLower(item2))]);
                            }
                            else
                            {
                                newStroka += Char.ToUpper(alphabet[sdvigi[i] + alphabet.IndexOf(char.ToLower(item2)) - 33]);
                            }
                            i++;
                            if (i == sdvigi.Count)
                            {
                                i = 0;
                            }
                        }
                        else
                        {
                            newStroka += item2;
                        }
                    }
                    else
                    {
                        if (alphabet.Contains(item2))
                        {
                            if (sdvigi[i] + alphabet.IndexOf(item2) <= 32)
                            {
                                newStroka += alphabet[sdvigi[i] + alphabet.IndexOf(item2)];
                            }
                            else
                            {
                                newStroka += alphabet[sdvigi[i] + alphabet.IndexOf(item2) - 33];
                            }
                            i++;
                            if (i == sdvigi.Count)
                            {
                                i = 0;
                            }
                        }
                        else
                        {
                            newStroka += item2;
                        }
                    }
                }
                newFile.Add(newStroka);

            }
            string res = "";
            foreach (var item in newFile)
            {
                res += item + "\n";
            }
            return res;
        }
        public static string incryptorfortext(string s, string key)
        {
            if (key == null || key == "")
            {
                key = MainWindow.key;
            }
            List<int> sdvigi = new List<int>();
            foreach (var item in key)
            {
                if (item != ' ')
                {
                    sdvigi.Add(alphabet.IndexOf(item));
                }
            }
            int i = 0;
            bool flag;
            string newStroka = "";
            foreach (var item2 in s)
            {
                flag = false;
                if (char.IsUpper(item2))
                {
                    flag = true;
                }
                if (flag)
                {
                    if (alphabet.Contains(char.ToLower(item2)))
                    {
                        if (sdvigi[i] + alphabet.IndexOf(char.ToLower(item2)) <= 32)
                        {
                            newStroka += Char.ToUpper(alphabet[sdvigi[i] + alphabet.IndexOf(char.ToLower(item2))]);
                        }
                        else
                        {
                            newStroka += Char.ToUpper(alphabet[sdvigi[i] + alphabet.IndexOf(char.ToLower(item2)) - 33]);
                        }
                        i++;
                        if (i == sdvigi.Count)
                        {
                            i = 0;
                        }
                    }
                    else
                    {
                        newStroka += item2;
                    }
                }
                else
                {
                    if (alphabet.Contains(item2))
                    {
                        if (sdvigi[i] + alphabet.IndexOf(item2) <= 32)
                        {
                            newStroka += alphabet[sdvigi[i] + alphabet.IndexOf(item2)];
                        }
                        else
                        {
                            newStroka += alphabet[sdvigi[i] + alphabet.IndexOf(item2) - 33];
                        }
                        i++;
                        if (i == sdvigi.Count)
                        {
                            i = 0;
                        }
                    }
                    else
                    {
                        newStroka += item2;
                    }
                }

            }
            return newStroka;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List.Visibility = Visibility.Hidden;
            textforin.Visibility = Visibility.Visible;
            klava.Visibility = Visibility.Visible;
            file.Visibility = Visibility.Visible;
            vvod.Visibility = Visibility.Hidden;
            path.Visibility = Visibility.Hidden;
            begin.Visibility = Visibility.Hidden;
            begin2.Visibility = Visibility.Hidden;
            textkey.Visibility = Visibility.Hidden;
            keyf.Visibility = Visibility.Hidden;
            textforcr.Visibility = Visibility.Hidden;
            begin3.Visibility = Visibility.Hidden;
            zapis.Visibility = Visibility.Hidden;
            yes.Visibility = Visibility.Hidden;
            textforpath.Visibility = Visibility.Hidden;
            download.Visibility = Visibility.Hidden;
            exception.Visibility = Visibility.Hidden;
            keyf.Clear();
            vvod.Clear();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void begin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string s = incryptor(vvod.Text, keyf.Text);
                if (s != "Все плохо, нет пути")
                {
                    vvod.Visibility = Visibility.Hidden;
                    path.Visibility = Visibility.Hidden;
                    begin.Visibility = Visibility.Hidden;
                    keyf.Visibility = Visibility.Hidden;
                    textkey.Visibility = Visibility.Hidden;
                    List.Text = s;
                    List.Visibility = Visibility.Visible;
                    zapis.Visibility = Visibility.Visible;
                    yes.Visibility = Visibility.Visible;
                }
                else
                {
                    List.Text = s;
                    List.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {
                List.Text = "Все плохо, неверный путь";
                List.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List.Visibility = Visibility.Hidden;
            vvod.Visibility = Visibility.Visible;
            path.Visibility = Visibility.Visible;
            begin.Visibility = Visibility.Hidden;
            begin2.Visibility = Visibility.Visible;
            textforin.Visibility = Visibility.Hidden;
            klava.Visibility = Visibility.Hidden;
            file.Visibility = Visibility.Hidden;
            textkey.Visibility = Visibility.Hidden;
            keyf.Visibility = Visibility.Hidden;
            textforcr.Visibility = Visibility.Hidden;
            begin3.Visibility = Visibility.Hidden;
            zapis.Visibility = Visibility.Hidden;
            yes.Visibility = Visibility.Hidden;
            textforpath.Visibility = Visibility.Hidden;
            download.Visibility = Visibility.Hidden;
            exception.Visibility = Visibility.Hidden;
            vvod.Clear();
        }

        private void begin2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string s = decryptor(@vvod.Text);
                if (s != "Все плохо, нет пути")
                {
                    vvod.Visibility = Visibility.Hidden;
                    path.Visibility = Visibility.Hidden;
                    begin.Visibility = Visibility.Hidden;
                    begin2.Visibility = Visibility.Hidden;
                    keyf.Visibility = Visibility.Hidden;
                    textkey.Visibility = Visibility.Hidden;
                    List.Text = s;
                    List.Visibility = Visibility.Visible;
                    zapis.Visibility = Visibility.Visible;
                    yes.Visibility = Visibility.Visible;
                }
                else
                {
                    List.Text = s;
                    List.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {
                List.Text = "Все плохо, неверный путь";
                List.Visibility = Visibility.Visible;
            }
        }

        private void file_Click(object sender, RoutedEventArgs e)
        {
            klava.Visibility = Visibility.Hidden;
            file.Visibility = Visibility.Hidden;
            textforin.Visibility = Visibility.Hidden;
            vvod.Visibility = Visibility.Visible;
            path.Visibility = Visibility.Visible;
            begin.Visibility = Visibility.Visible;
            textkey.Visibility = Visibility.Visible;
            keyf.Visibility = Visibility.Visible;
            textforcr.Visibility = Visibility.Hidden;
        }

        private void klava_Click(object sender, RoutedEventArgs e)
        {
            klava.Visibility = Visibility.Hidden;
            file.Visibility = Visibility.Hidden;
            textforin.Visibility = Visibility.Hidden;
            vvod.Visibility = Visibility.Visible;
            path.Visibility = Visibility.Hidden;
            textforcr.Visibility = Visibility.Visible;
            begin3.Visibility = Visibility.Visible;
            textkey.Visibility = Visibility.Visible;
            keyf.Visibility = Visibility.Visible;
        }

        private void begin3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string s = incryptorfortext(vvod.Text, keyf.Text);
                {
                    vvod.Visibility = Visibility.Hidden;
                    path.Visibility = Visibility.Hidden;
                    begin3.Visibility = Visibility.Hidden;
                    keyf.Visibility = Visibility.Hidden;
                    textkey.Visibility = Visibility.Hidden;
                    textforcr.Visibility = Visibility.Hidden;
                    List.Text = s;
                    List.Visibility = Visibility.Visible;
                    zapis.Visibility = Visibility.Visible;
                    yes.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {
                List.Text = "Все плохо";
                List.Visibility = Visibility.Visible;
            }
        }

        private void yes_Click(object sender, RoutedEventArgs e)
        {
            vvod.Clear();
            vvod.Visibility = Visibility.Visible;
            List.Visibility = Visibility.Hidden;
            textforpath.Visibility = Visibility.Visible;
            download.Visibility = Visibility.Visible;
            yes.Visibility = Visibility.Hidden;
            zapis.Visibility = Visibility.Hidden;
            exception.Visibility = Visibility.Hidden;
        }

        private void download_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                textforpath.Visibility = Visibility.Hidden;
                download.Visibility = Visibility.Hidden;
                vvod.Visibility = Visibility.Hidden;
                exception.Visibility = Visibility.Visible;
                using (FileStream fs = new FileStream(vvod.Text, FileMode.Create))
                {
                    using (StreamWriter ww = new StreamWriter(fs))
                    {
                        ww.WriteLine(List.Text);
                    }
                }
                exception.Text = "Файл успешно создан";
            }
            catch (Exception)
            {
                exception.Visibility = Visibility.Visible;
                exception.Text = "Возникли проблемы с записью файла, проверьте путь и попробуйте еще раз";
            }
        }
    }
}
