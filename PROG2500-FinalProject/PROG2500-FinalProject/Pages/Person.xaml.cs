using IMDB_Project.Data;
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
using Microsoft.EntityFrameworkCore;

namespace PROG2500_FinalProject.Pages
{
    /// <summary>
    /// Interaction logic for Person.xaml
    /// </summary>
    public partial class Person : Page
    {
        private readonly ImdbProjectContext _context = new ImdbProjectContext();
        private CollectionViewSource personViewSource;

        public Person()
        {
            InitializeComponent();
            personViewSource = (CollectionViewSource)FindResource(nameof(personViewSource));
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            _context.Names.Load();
            _context.Titles.Load();

            personViewSource.Source = _context.Names.Local.ToObservableCollection();

            var query = from n in _context.Names
                        join p in _context.Principals on n.NameId equals p.NameId
                        join t in _context.Titles on p.TitleId equals t.TitleId
                        where n.PrimaryName.Contains(txtSearch.Text)
                        group t by n.PrimaryName into g
                        select new
                        {
                            PrimaryName = g.Key,
                            ShortTitles = g.Where(t => t.TitleType == "short").Select(t => new
                            {
                                t.PrimaryTitle,
                                t.StartYear,
                                t.RuntimeMinutes,
                                t.Rating.AverageRating,
                                t.Rating.NumVotes
                            }),
                            MovieTitles = g.Where(t => t.TitleType == "movie").Select(t => new
                            {
                                t.PrimaryTitle,
                                t.StartYear,
                                t.RuntimeMinutes,
                                t.Rating.AverageRating,
                                t.Rating.NumVotes
                            })
                        };

            personListView.ItemsSource = query.ToList();
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
