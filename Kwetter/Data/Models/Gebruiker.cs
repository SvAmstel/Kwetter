using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kwetter.Data.Models
{
    public class Gebruiker
    {
        public int Id { get; set; }
        public string naam { get; set; }
        public string bio { get; set; }

        public List<Tweet> tweets { get; set; }
        public List<Gebruiker> followers { get; set; }
        public List<Gebruiker> following { get; set; }
    }
}