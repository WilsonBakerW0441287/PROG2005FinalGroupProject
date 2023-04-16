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
        
        public Genre()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            //var query =
            //    from a in _context.Artists
            //    where a.Name.Contains(txtSearch.Text)
            //    group a by a.Name.ToUpper().Substring(0, 1) into newGroup
            //    select new
            //    {
            //        Index = newGroup.Key,
            //        artistCount = newGroup.Count().ToString(),
            //        Artists = newGroup.ToList()
            //    };
            //catalogListView.ItemsSource = query.ToList();
        }
    }
}
