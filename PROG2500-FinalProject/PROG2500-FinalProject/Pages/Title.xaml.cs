using IMDB_Project.Data;
using Microsoft.EntityFrameworkCore;
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

namespace PROG2500_FinalProject.Pages
{
    /// <summary>
    /// Interaction logic for Title.xaml
    /// </summary>
    public partial class Title : Page
    {
        private readonly ImdbProjectContext _context = new ImdbProjectContext();
        private CollectionViewSource titleViewSource;
        public Title()
        {
            InitializeComponent();
            titleViewSource = (CollectionViewSource)FindResource(nameof(titleViewSource));
            //_context.Titles.Load();

            //titleViewSource.Source = _context.Titles.Local.ToObservableCollection();
        }

        private void btnSearchTitle_Click(object sender, RoutedEventArgs e)
        {
            _context.Titles.Load();
            var query = _context.Titles.Where(t => t.PrimaryTitle.Contains(searchTitle.Text)).ToList();
            titleViewSource.Source = query;

        }
    }
}
