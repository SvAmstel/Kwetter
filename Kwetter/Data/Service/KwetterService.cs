using Kwetter.Data.Context;
using Kwetter.Data.Dao;
using Kwetter.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kwetter.Data.Service
{
    public class KwetterService
    {
        IGebruikerDao gebruikerDao;
        ITweetDao tweetDao;

        public KwetterService()
        {
            gebruikerDao = new GebruikerDaoImpl();
            tweetDao = new TweetDaoImpl();
        }

        public List<Gebruiker> GetAllGebruikers()
        {
            List<Gebruiker> gebruikers = new List<Gebruiker>();
            gebruikers = gebruikerDao.GetAllGebruikers();
            return gebruikers;
        }

        public Gebruiker GetGebruikerByNaam(string naam)
        {
            Gebruiker gebruiker = gebruikerDao.GetGebruikerByNaam(naam);
            return gebruiker;
        }

        public List<Tweet> GetTweetsByGebruiker(Gebruiker g)
        {
            List<Tweet> tweets = new List<Tweet>();
            tweets = tweetDao.GetAllTweetsByGebruiker(g);
            return tweets;
        }
    }
}