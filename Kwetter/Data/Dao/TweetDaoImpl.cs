using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kwetter.Data.Context;
using Kwetter.Data.Models;
using Kwetter.Data.Service;

namespace Kwetter.Data.Dao
{
    public class TweetDaoImpl : ITweetDao
    {
        public List<Tweet> GetAllTweetsByGebruiker(Gebruiker g)
        {
            List<Tweet> tweets = new List<Tweet>();
            using (var context = new KwetterContext())
            {
                var gebruikerTweets = context.tweets.SqlQuery("Select * from Tweets where Gebruiker_Id = " + g.Id);
                foreach (var t in gebruikerTweets)
                {
                    tweets.Add(t);
                }
            }
            return tweets;
        }

        public List<Tweet> GetAllTweets()
        {
            List<Tweet> tweets = new List<Tweet>();
            using (var context = new KwetterContext())
            {
                var gebruikerTweets = context.tweets.SqlQuery("Select * from Tweets");
                foreach (var t in gebruikerTweets)
                {
                    tweets.Add(t);
                }
            }
            return tweets;
        }

        public void CreateTweet(Tweet t, Gebruiker g)
        {
            using (var context = new KwetterContext())
            {
                g.tweets = GetAllTweetsByGebruiker(g);
                g.tweets.Add(t);
                context.tweets.Add(t);
                context.Entry(g).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}