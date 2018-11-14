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

namespace StyleTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
            if (currentTheme == null)
            {
                currentTheme = LoadResource("Color1.xaml");
            }
            Application.Current.Resources.BeginInit();
            Application.Current.Resources.MergedDictionaries.Add(LoadResource("Dictionary3.xaml"));
            Application.Current.Resources.MergedDictionaries.Add(currentTheme);
            Application.Current.Resources.EndInit();
        }
        ResourceDictionary currentTheme = null;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources.BeginInit();
            Application.Current.Resources.MergedDictionaries.Remove(currentTheme);
            currentTheme = LoadResource("Color1.xaml");
            Application.Current.Resources.MergedDictionaries.Add(currentTheme);
            Application.Current.Resources.EndInit();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources.BeginInit();
            Application.Current.Resources.MergedDictionaries.Remove(currentTheme);
            currentTheme = LoadResource("Color2.xaml");
            Application.Current.Resources.MergedDictionaries.Add(currentTheme);
            Application.Current.Resources.EndInit();
        }

        private ResourceDictionary LoadResource(string path)
        {
            Uri uri = new Uri(@"/" + path,UriKind.Relative);

            return Application.LoadComponent(uri) as ResourceDictionary;
        }
    }
}
