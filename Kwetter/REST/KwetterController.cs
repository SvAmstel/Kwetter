﻿using Kwetter.Data.Models;
using Kwetter.Data.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Kwetter.REST
{
    public class KwetterController : ApiController
    {
        KwetterService ks = new KwetterService();

        public List<Gebruiker> GetAllUsers()
        {
            return ks.GetAllGebruikers();
        }

        // GET api/kwetter/getuser
        [HttpGet]
        [Route("api/kwetter/getuser/{naam}")]
        public Gebruiker GetUser(string naam)
        {
            return ks.GetGebruikerByNaam(naam);
        }

        // GET api/kwetter/getusertweets
        [HttpGet]
        [Route("api/kwetter/getusertweets/{naam}")]
        public List<Tweet> GetTweetsByUser(string naam)
        {
            Gebruiker g = ks.GetGebruikerByNaam(naam);
            return ks.GetTweetsByGebruiker(g);
        }
    }
}