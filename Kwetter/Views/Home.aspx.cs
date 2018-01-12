using Kwetter.Data.Context;
using Kwetter.Data.Dao;
using Kwetter.Data.Models;
using Kwetter.Data.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kwetter.Views
{
    public partial class Home : System.Web.UI.Page
    {
        private KwetterService ks;

        protected void Page_Load(object sender, EventArgs e)
        {
            Start start = new Start();
            start.Initialize();
           
        }

        protected void btnTest2_Click(object sender, EventArgs e)
        {
            ks = new KwetterService();
            List<Gebruiker> gebruikers = ks.GetAllGebruikers();
        }
    }
}