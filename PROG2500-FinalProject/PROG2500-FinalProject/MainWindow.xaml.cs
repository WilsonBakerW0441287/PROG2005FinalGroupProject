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
        public Pages.Person personPage { get; set; }
        public Pages.Job jobPage { get; set; }
        public Pages.Title titlePage { get; set; }
        public Pages.Genre genrePage { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            homePage = new Home();
            personPage = new Person();
            jobPage = new Job();
            titlePage = new Title();
            genrePage = new Genre();
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

        private void PersonButton_Click(object sender, RoutedEventArgs e)
        {
            mainframe.NavigationService.Navigate(personPage);
        }

        private void JobButton_Click(object sender, RoutedEventArgs e)
        {
            mainframe.NavigationService.Navigate(jobPage);
        }

        private void TitleButton_Click(object sender, RoutedEventArgs e)
        {
            mainframe.NavigationService.Navigate(titlePage);
        }

        private void GenreButton_Click(object sender, RoutedEventArgs e)
        {
            mainframe.NavigationService.Navigate(genrePage);
        }
    }
}
