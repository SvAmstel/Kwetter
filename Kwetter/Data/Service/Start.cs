using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kwetter.Data.Models;
using Kwetter.Data.Context;

namespace Kwetter.Data.Service
{
    public class Start
    {
        public void Initialize() 
        {
            using (var context = new KwetterContext())
            {
                Gebruiker u1 = new Gebruiker() { naam = "Simon", bio = "testBioSimon" };
                Gebruiker u2 = new Gebruiker() { naam = "Frank", bio = "testBioFrank" };
                Gebruiker u3 = new Gebruiker() { naam = "Klaas", bio = "testBioKlaas" };
                context.gebruikers.Add(u1);
                context.gebruikers.Add(u2);
                context.gebruikers.Add(u3);
                context.SaveChanges();
            }
        }
    }
}