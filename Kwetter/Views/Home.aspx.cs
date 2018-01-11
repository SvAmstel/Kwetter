using Kwetter.Data.Context;
using Kwetter.Data.Models;
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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnTest_Click(object sender, EventArgs e)
        {
            using (var context = new KwetterContext())
            {
                Gebruiker u1 = new Gebruiker() { naam = "Simon" };
                Gebruiker u2 = new Gebruiker() { naam = "Frank" };
                context.gebruikers.Add(u1);
                context.gebruikers.Add(u2);
                context.SaveChanges();
            }
        }

        protected void btnTest2_Click(object sender, EventArgs e)
        {
            using (var context = new KwetterContext())
            {
                var gebruiker = context.gebruikers.First(a => a.naam == "Simon");
                var connectionString = context.Database.Connection.ConnectionString;
                lblNaam.Text = gebruiker.naam;
            }

        }
    }
}