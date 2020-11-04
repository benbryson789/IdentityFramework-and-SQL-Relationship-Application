using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab24version3.Data
{
    public class CheckedOutMovies
    {
        public int Id { get; set; }
        public IdentityUser UserID { get; set; }
        public Movies MovieID { get; set; }
        public DateTime DueDate { get; set; }
    }
}
