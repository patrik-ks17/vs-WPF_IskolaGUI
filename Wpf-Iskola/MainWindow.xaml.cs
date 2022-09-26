using System;
using System.Collections.Generic;
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
using System.IO;

namespace Wpf_Iskola
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //10.f:
            foreach (var i in File.ReadAllLines("nevekGUI.txt"))
            {
                Tanulók.Items.Add(i);
            }
        }

        private void Törlés_Click(object sender, RoutedEventArgs e)
        {
            if (Tanulók.SelectedIndex == -1)
            {
                MessageBox.Show("Nem jelölt ki tanulót!");
            }
            else
            {
                Tanulók.Items.RemoveAt(Tanulók.SelectedIndex);
            }
        }

        private void Mentés_Click(object sender, RoutedEventArgs e)
        {
            List<string> ki = new List<string>();
            foreach (var item in Tanulók.Items)
            {
                ki.Add((string)item);
            }

            try
            {
                File.WriteAllLines("nevekNEW.txt", ki);
                MessageBox.Show("Sikeres mentés!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
