using Kwetter.Data.Models;
using Kwetter.Data.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Kwetter.REST
{
    //[EnableCors(origins: "*", headers: "*", methods: "GET, POST, PUT, DELETE")]
    public class KwetterController : ApiController
    {
        KwetterService ks = new KwetterService();
        
        [HttpGet]
        [Route("api/kwetter/users")]
        public List<Gebruiker> GetAllUsers()
        {
            return ks.GetAllGebruikers();
        }

        [HttpGet]
        [Route("api/kwetter/{naam}/tweets")]
        public List<Tweet> GetTweetsByUser(string naam)
        {
            Gebruiker g = ks.GetGebruikerByNaam(naam);
            return ks.GetTweetsByGebruiker(g);
        }

        [HttpPost]
        [Route("api/kwetter/users/add")]
        public void PostAddUser([FromBody] string naam)
        {
            Gebruiker geb = new Gebruiker() { naam = naam, bio = "", tweets = new List<Tweet>(), followers = new List<Gebruiker>() };
            Debug.WriteLine(geb.naam);
            ks.CreateUser(geb);
        }
    }
}
