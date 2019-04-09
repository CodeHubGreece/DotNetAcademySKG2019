using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class FeaturedMovieViewModel
    {
        public Movie Movie { get; set; }

        public IList<Customer> Customers {get;set;}

    }
}