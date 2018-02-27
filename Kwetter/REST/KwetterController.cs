using Kwetter.Data.Models;
using Kwetter.Data.Service;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Kwetter.REST
{
    //[EnableCors(origins: "*", headers: "*", methods: "GET, POST, PUT, DELETE")]
    public class KwetterController : ApiController
    {
        KwetterService ks = new KwetterService();
        
        // GET api/kwetter/getusers
        [HttpGet]
        [Route("api/kwetter/getusers")]
        public List<Gebruiker> GetAllUsers()
        {
            return ks.GetAllGebruikers();
        }

        // GET api/kwetter/getuser
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
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

        // POST api/kwetter/adduser
        [HttpPost]
        [Route("api/kwetter/adduser/{naam}")]
        public void PostAddUser([FromBody]string naam)
        {
            Gebruiker g = new Gebruiker();
            g.naam = naam;
            ks.CreateUser(g);
        }
    }
}
