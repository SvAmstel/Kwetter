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

        public KwetterService()
        {
            gebruikerDao = new GebruikerDaoImpl();
        }

        public List<Gebruiker> GetAllGebruikers()
        {
            List<Gebruiker> gebruikers = new List<Gebruiker>();
            gebruikers = gebruikerDao.GetAllGebruikers();
            return gebruikers;
        }
    }
}