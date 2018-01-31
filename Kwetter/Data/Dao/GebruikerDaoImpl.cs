using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kwetter.Data.Context;
using Kwetter.Data.Models;
using Kwetter.Data.Service;

namespace Kwetter.Data.Dao
{
    public class GebruikerDaoImpl : IGebruikerDao
    {
       // private KwetterService ks = new KwetterService();
        public List<Gebruiker> GetAllGebruikers()
        {
            List<Gebruiker> gebruikers = new List<Gebruiker>();
            using (var context = new KwetterContext())
            {
                gebruikers = (List<Gebruiker>)context.gebruikers.ToList();
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

        public Gebruiker GetGebruikerById(int id)
        {
            Gebruiker gebruiker = new Gebruiker();
            using (var context = new KwetterContext())
            {
                gebruiker = (Gebruiker)context.gebruikers.Where(g => g.Id.Equals(id)).FirstOrDefault(); ;
            }
            return gebruiker;
        }

        public List<Gebruiker> GetFollowers(Gebruiker g)
        {
            List<Gebruiker> gebruikers = new List<Gebruiker>();

            using (var context = new KwetterContext())
            {
                var followers = context.Database.SqlQuery<int>("Select FollowerId from Followers Where GebruikerId = " + g.Id);
                foreach (var f in followers)
                {
                    gebruikers.Add(GetGebruikerById(Convert.ToInt32(f)));
                }
            }
            return gebruikers;
        }

        public List<Gebruiker> GetFollowing(Gebruiker g)
        {
            List<Gebruiker> gebruikers = new List<Gebruiker>();

            using (var context = new KwetterContext())
            {
                var following = context.Database.SqlQuery<int>("Select GebruikerId from Followers Where FollowerId = " + g.Id);
                foreach (var f in following)
                {
                    gebruikers.Add(GetGebruikerById(Convert.ToInt32(f)));
                }
            }
            return gebruikers;
        }

        public void CreateUser(Gebruiker g)
        {
            using (var context = new KwetterContext())
            {
                context.gebruikers.Add(g);
            }
        }
    }
}