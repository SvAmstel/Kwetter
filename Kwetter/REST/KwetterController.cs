using Kwetter.Data.Models;
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

        public List<Gebruiker> Get()
        {
            return ks.GetAllGebruikers();
        }

        public Gebruiker Get([FromUri]string naam)
        {
            return ks.GetGebruikerByNaam(naam);
        }
    }
}
