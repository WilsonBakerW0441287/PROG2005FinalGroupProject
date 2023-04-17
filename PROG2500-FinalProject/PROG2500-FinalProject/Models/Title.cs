using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB_Project.Models
{
    public partial class Title
    {
        public string FormatedTitleCall
        {
            get
            {
                string adultRating = "";
                if (IsAdult == true)
                {
                    adultRating = "Hide Your Kids!";
                } else
                {
                    adultRating = "For Everyone!";
                }
                return string.Format("Title: {0}\nRating: {1}\nYear Of Release: {2}\nRun Time: {3} Minutes",
                    OriginalTitle,adultRating,StartYear,RuntimeMinutes);
            }
        }
    }
}
