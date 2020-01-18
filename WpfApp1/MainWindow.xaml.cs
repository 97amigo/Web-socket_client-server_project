using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            runServer();
            runClient(myTextBox.GetLineText(myTextBox.LineCount - 1));
            myTextBox.AppendText(Environment.NewLine);
            myTextBox.CaretIndex = myTextBox.Text.Length;
            myTextBox1.CaretIndex = myTextBox1.Text.Length;
            myTextBox.Focus();
        }

        private void myTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                runServer();
                runClient(myTextBox.GetLineText(myTextBox.LineCount - 1));
                myTextBox.AppendText(Environment.NewLine);
                myTextBox.CaretIndex = myTextBox.Text.Length;
                myTextBox1.CaretIndex = myTextBox1.Text.Length;
            }
        }

        private void runServer()
        {
            Process p = new Process();
            p.StartInfo.FileName = Directory.GetCurrentDirectory() + @"\server.exe";
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.Start();            
        }

        private void runClient(String number)
        {
            Process p = new Process();
            p.StartInfo.FileName = Directory.GetCurrentDirectory() + @"\client.exe";
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.Arguments = number;
            p.Start();
            this.myTextBox1.Text += (p.StandardOutput.ReadToEnd());        
        }
    }
}
