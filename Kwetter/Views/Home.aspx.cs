using Kwetter.Data.Context;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            Start start = new Start();
            start.Initialize();
        }

        protected void btnTest2_Click(object sender, EventArgs e)
        {
            using (var context = new KwetterContext())
            {
                var gebruiker = context.gebruikers.First(a => a.naam == "Simon");
                lblNaam.Text = gebruiker.naam;
            }

        }
    }
}