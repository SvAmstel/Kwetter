using Kwetter.Data.Dao;
using Kwetter.Data.Models;
using Kwetter.Data.Service;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace Kwetter.REST
{
    //[EnableCors(origins: "*", headers: "*", methods: "GET, POST, PUT, DELETE")]
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
    }
}
