﻿using Kwetter.Data.Dao;
using Kwetter.Data.Models;
using Kwetter.Data.Service;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Kwetter.REST
{
    //[EnableCors(origins: "*", headers: "*", methods: "GET, POST, PUT, DELETE, OPTIONS")]
    public class KwetterController : ApiController
    {
        KwetterService gebruikerDao = new KwetterService(new GebruikerDaoImpl());
        KwetterService tweetDao = new KwetterService(new TweetDaoImpl());

        [HttpGet]
        [Route("api/kwetter/users")]
        public List<Gebruiker> GetAllUsers()
        {
            return gebruikerDao.GetAllGebruikers();
        }

        [HttpGet]
        [Authorize]
        [Route("api/kwetter/{naam}/tweets")]
        public List<Tweet> GetTweetsByUser(string naam)
        {
            Gebruiker g = gebruikerDao.GetGebruikerByNaam(naam);
            return tweetDao.GetTweetsByGebruiker(g);
        }

        [HttpPost]
        [Route("api/kwetter/users/add")]
        public void PostAddUser(HttpRequestMessage request)
        {
            var message = request.Content.ReadAsStringAsync().Result;
            Gebruiker geb = new Gebruiker() { naam = message, bio = "", tweets = new List<Tweet>(), followers = new List<Gebruiker>() };
            gebruikerDao.CreateUser(geb);
        }

        [HttpPost]
        [Authorize]
        [Route("api/kwetter/tweets/add")]
        public void PostAddTweet(HttpRequestMessage request)
        {
            var message = request.Content.ReadAsStringAsync().Result;
            JObject jTweet = JObject.Parse(message);
            int id = Convert.ToInt32(jTweet["Gebruiker_Id"].ToString());
            Gebruiker geb = gebruikerDao.GetGebruikerById(id);
            Tweet tweet = new Tweet();

            tweet.Gebruiker_Id = id;
            tweet.content = jTweet["content"].ToString();
            tweet.postDate = DateTime.Parse((jTweet["postDate"].ToString()));
            tweet.postedFrom = jTweet["postedFrom"].ToString();
            tweetDao.CreateTweet(tweet, geb);
        }

        [HttpPost]
        [Authorize]
        [Route("api/kwetter/tweets/delete")]
        public void PostDeleteTweet(HttpRequestMessage request)
        {
            var message = request.Content.ReadAsStringAsync().Result;
            //JObject jTweet = JObject.Parse(message);
            //int id = Convert.ToInt32(jTweet["id"].ToString());
            tweetDao.DeleteTweet(Convert.ToInt32(message));

            // Gebruiker geb = new Gebruiker() { naam = message, bio = "", tweets = new List<Tweet>(), followers = new List<Gebruiker>() };
            //gebruikerDao.CreateUser(geb);
        }

        [HttpPost]
        [Authorize]
        [Route("api/kwetter/tweets/edit")]
        public void PostEditTweet(HttpRequestMessage request)
        {
            var message = request.Content.ReadAsStringAsync().Result;
            JObject jTweet = JObject.Parse(message);
            Tweet t = new Tweet();
            t.content = jTweet["content"].ToString();
            t.Id = Convert.ToInt32( jTweet["Id"].ToString());
            tweetDao.EditTweet(t);
        }
    }
}
