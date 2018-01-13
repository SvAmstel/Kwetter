using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kwetter.Data.Context;
using Kwetter.Data.Models;

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
    }
}