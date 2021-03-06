﻿using Kwetter.Data.Context;
using Kwetter.Data.Dao;
using Kwetter.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace Kwetter.Data.Service
{
    public class KwetterService
    {
        private IGebruikerDao gebruikerDao;
        private ITweetDao tweetDao;

        public KwetterService() { }

        public KwetterService(IGebruikerDao gebruikerDao)
        {
            this.gebruikerDao = gebruikerDao;
           
        }
        public KwetterService(ITweetDao tweetDao)
        {
            this.tweetDao = tweetDao;
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

        public Gebruiker GetGebruikerById(int id)
        {
            Gebruiker gebruiker = gebruikerDao.GetGebruikerById(id);
            return gebruiker;
        }

        public List<Tweet> GetTweetsByGebruiker(Gebruiker g)
        {
            List<Tweet> tweets = new List<Tweet>();
            tweets = tweetDao.GetAllTweetsByGebruiker(g);
            return tweets;
        }

        public List<Gebruiker> GetFollowers(Gebruiker g)
        {
            List<Gebruiker> followers = new List<Gebruiker>();
            followers = gebruikerDao.GetFollowers(g);
            return followers;
        }

        public List<Gebruiker> GetFollowing(Gebruiker g)
        {
            List<Gebruiker> following = new List<Gebruiker>();
            following = gebruikerDao.GetFollowing(g);
            return following;
        }

        public void CreateTweet(Tweet t, Gebruiker g)
        {
            tweetDao.CreateTweet(t, g);
        }

        public void CreateUser(Gebruiker g)
        {
            gebruikerDao.CreateUser(g);
        }

        public void DeleteTweet(int id)
        {
            tweetDao.DeleteTweet(id);
        }

        public void EditTweet(Tweet t)
        {
            tweetDao.EditTweet(t);
        }
    }
}