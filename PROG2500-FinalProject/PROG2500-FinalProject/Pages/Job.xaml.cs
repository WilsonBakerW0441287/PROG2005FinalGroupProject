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
    /// Interaction logic for Job.xaml
    /// </summary>
    public partial class Job : Page
    {
        private readonly ImdbProjectContext _context = new ImdbProjectContext();
        private CollectionViewSource jobViewSource;

        public Job()
        {
            InitializeComponent();
            jobViewSource = (CollectionViewSource)FindResource(nameof(jobViewSource));
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            _context.Names.Load();
            _context.Titles.Load();
            _context.Principals.Load();

            jobViewSource.Source = _context.Names.Local.ToObservableCollection();

            //if statement that checks if the search box is empty
            //if statement that checks if the name is in the DB BEFORE trying to populate list

            if (txtSearch.Text == "")
            {
                MessageBox.Show("Please enter a name to search for.");
            }
            else
            {
                if (txtSearch.Text == _context.Names.Local.ToObservableCollection().ToString())
                {
                    MessageBox.Show("Name not found.");
                }
                else
                {

                    var query = from p in _context.Principals
                                join t in _context.Titles on p.TitleId equals t.TitleId
                                join n in _context.Names on p.NameId equals n.NameId
                                where n.PrimaryName.Contains(txtSearch.Text)
                                group new { n, p, t } by new { p.JobCategory } into g
                                orderby g.Key.JobCategory
                                select new
                                {
                                    JobCategory = g.Key.JobCategory,
                                    Items = from item in g
                                            orderby item.t.StartYear descending
                                            select new
                                            {
                                                item.n.PrimaryName,
                                                item.t.PrimaryTitle,
                                                item.t.StartYear
                                            }
                                };

                    jobListView.ItemsSource = query.ToList();
                }
            }
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
