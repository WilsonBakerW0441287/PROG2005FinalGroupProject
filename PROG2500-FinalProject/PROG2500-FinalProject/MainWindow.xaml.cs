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
using PROG2500_FinalProject.Pages;

namespace PROG2500_FinalProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Pages.Home homePage { get; set; }
        public Pages.Genres genrePage { get; set; }
        public Pages.Jobs jobsPage { get; set; }
        public Pages.Person peoplePage { get; set; }
        public Pages.Title titlePage { get; set; }
        

        public MainWindow()
        {
            InitializeComponent();
            homePage = new Home();
            mainframe.NavigationService.Navigate(homePage);
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            mainframe.NavigationService.Navigate(homePage);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainframe.NavigationService.Navigate(homePage);
        }
        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            mainframe.NavigationService.Navigate(homePage);
        }
        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            mainframe.NavigationService.Navigate(homePage);
        }
        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            mainframe.NavigationService.Navigate(homePage);
        }
        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            mainframe.NavigationService.Navigate(homePage);
        }
    }
}
