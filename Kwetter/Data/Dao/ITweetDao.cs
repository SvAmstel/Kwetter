using Kwetter.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kwetter.Data.Dao
{
    public interface ITweetDao
    {
        List<Tweet> GetAllTweetsByGebruiker(Gebruiker g);
        List<Tweet> GetAllTweets();
        void CreateTweet(Tweet t, Gebruiker g);
    }
}