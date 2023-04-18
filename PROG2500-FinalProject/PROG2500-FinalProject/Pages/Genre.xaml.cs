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
    /// Interaction logic for Genre.xaml
    /// </summary>
    public partial class Genre : Page
    {
        private readonly ImdbProjectContext _context = new ImdbProjectContext();
        private CollectionViewSource GenreViewSource;
        public Genre()
        {
            InitializeComponent();
            GenreViewSource = ((CollectionViewSource)(FindResource("GenreViewSource")));
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var query =
                from g in _context.Genres
                where g.Name.Contains(txtSearch.Text)
                group g by g.Name.ToUpper().Substring(0, 1) into newGroup
                select new
                {
                    Index = newGroup.Key,
                    genreCount = newGroup.Count().ToString(),
                    Genres = newGroup.ToList(),
                };

            GenreListView.ItemsSource = query.ToList();
        }

        private void textSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnSearch.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }
    }
}
