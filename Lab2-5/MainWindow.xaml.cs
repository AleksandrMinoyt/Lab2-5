using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab2_5
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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
           

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Текстовые файлы (*.txt)|*.txt";

            if (ofd.ShowDialog() == true)
            {
                var fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                StrokeCollection strokes = new StrokeCollection(fs);
                Canva.Strokes = strokes;              
            }

        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Текстовые файлы (*.txt)|*.txt";
       
            if (sfd.ShowDialog() == true)
            {
                var fs = new FileStream(sfd.FileName, FileMode.Create);
                Canva.Strokes.Save(fs);
                
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Canva != null) {
                if ((sender as ComboBox).SelectedIndex == 0)
                {
                    Canva.EditingMode = InkCanvasEditingMode.Ink;
                }
                else
                {
                    Canva.EditingMode = InkCanvasEditingMode.EraseByPoint;
                }
            } }
    }
}
