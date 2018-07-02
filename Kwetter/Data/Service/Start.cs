using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kwetter.Data.Models;
using Kwetter.Data.Context;
using Kwetter.REST;
using System.Diagnostics.Tracing;
using System.Net.Sockets;
using System.Net;
using System.Net.Http;

namespace Kwetter.Data.Service
{
    public class Start
    {
        public void Initialize()
        {
          

            using (var context = new KwetterContext())
            {

                //context.Database.Delete();
                //Check of er iets in de database staat.Zo niet, maak nieuwe gebruikers en tweets aan
                if (!context.gebruikers.Any())
                {

                    //Gebruikers aanmaken
                    Gebruiker u1 = new Gebruiker() { naam = "Simon", bio = "testBioSimon", tweets = new List<Tweet>(), followers = new List<Gebruiker>(), following = new List<Gebruiker>() };
                    Gebruiker u2 = new Gebruiker() { naam = "Frank", bio = "testBioFrank", tweets = new List<Tweet>(), followers = new List<Gebruiker>(), following = new List<Gebruiker>() };
                    Gebruiker u3 = new Gebruiker() { naam = "Klaas", bio = "testBioKlaas", tweets = new List<Tweet>(), followers = new List<Gebruiker>(), following = new List<Gebruiker>() };

                    //Tweets aanmaken en aan een gebruiker toevoegen
                    Tweet t1 = new Tweet() { content = "Dit is de eerste tweet van Simon", postedFrom = "PC", postDate = DateTime.Now };
                    Tweet t2 = new Tweet() { content = "Dit is de eerste tweet van Frank", postedFrom = "Android", postDate = DateTime.Now };
                    Tweet t3 = new Tweet() { content = "Dit is de eerste tweet van Klaas", postedFrom = "Iphone", postDate = DateTime.Now };
                    List<Tweet> tweets = new List<Tweet>();
                    tweets.Add(t1);
                    u1.tweets.AddRange(tweets);

                    tweets = new List<Tweet>();
                    tweets.Add(t2);
                    u2.tweets.AddRange(tweets);

                    tweets = new List<Tweet>();
                    tweets.Add(t3);
                    u3.tweets.AddRange(tweets);

                    //Followers aan gebruikers toevoegen
                    List<Gebruiker> followers = new List<Gebruiker>();
                    followers.Add(u2);
                    followers.Add(u3);
                    u1.followers.AddRange(followers);


                    //Alle data aan de context toevoegen en wegschrijven
                    context.gebruikers.Add(u1);
                    context.gebruikers.Add(u2);
                    context.gebruikers.Add(u3);
                    context.tweets.Add(t1);
                    context.tweets.Add(t2);
                    context.tweets.Add(t3);
                    context.SaveChanges();
                }
            }
        }
    }
}