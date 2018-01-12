using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kwetter.Data.Context;
using Kwetter.Data.Models;

namespace Kwetter.Data.Dao
{
    public class GebruikerDaoImpl : IGebruikerDao
    {
        public List<Gebruiker> GetAllGebruikers()
        {
            List<Gebruiker> gebruikers = new List<Gebruiker>();
            using (var context = new KwetterContext())
            {
                var users = context.gebruikers;
                foreach (Gebruiker g in users)
                {
                    gebruikers.Add(g);
                }
            }
            return gebruikers;
        }

        public Gebruiker GetGebruikerByNaam(string naam)
        {
            Gebruiker gebruiker = new Gebruiker();
            using (var context = new KwetterContext())
            {
                gebruiker = (Gebruiker)context.gebruikers.Where(g => g.naam.Equals(naam)).FirstOrDefault(); ;
            }
            return gebruiker;
        }
    }
}