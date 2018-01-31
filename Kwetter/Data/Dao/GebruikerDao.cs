using Kwetter.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kwetter.Data.Dao
{
    public interface IGebruikerDao
    {
        List<Gebruiker> GetAllGebruikers();
        Gebruiker GetGebruikerByNaam(string naam);
        Gebruiker GetGebruikerById(int id);
        List<Gebruiker> GetFollowers(Gebruiker g);
        List<Gebruiker> GetFollowing(Gebruiker g);
        void CreateUser(Gebruiker g);
    }
}