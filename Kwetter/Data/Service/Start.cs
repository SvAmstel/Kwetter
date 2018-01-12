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
                context.Database.ExecuteSqlCommand("DELETE FROM [Tweets]");
                context.Database.ExecuteSqlCommand("DELETE FROM [Gebruikers]");
               
                Gebruiker u1 = new Gebruiker() { naam = "Simon", bio = "testBioSimon", tweets = new List<Tweet>() };
                Gebruiker u2 = new Gebruiker() { naam = "Frank", bio = "testBioFrank", tweets = new List<Tweet>() };
                Gebruiker u3 = new Gebruiker() { naam = "Klaas", bio = "testBioKlaas", tweets = new List<Tweet>() };
                
                //context.SaveChanges();

                Tweet t1 = new Tweet() { content = "Dit is een tweet van Simon", postedFrom = "PC" };
                List<Tweet> tweets = new List<Tweet>();
                tweets.Add(t1);
                u1.tweets.AddRange(tweets);

                context.gebruikers.Add(u1);
                context.gebruikers.Add(u2);
                context.gebruikers.Add(u3);
                context.tweets.Add(t1);
                context.SaveChanges();


            }
        }
    }
}