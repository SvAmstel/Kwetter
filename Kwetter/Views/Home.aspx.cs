﻿using Kwetter.Data.Context;
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
            Gebruiker gebruiker = ks.GetGebruikerByNaam("Simon");
            List<Tweet> tweets = ks.GetTweetsByGebruiker(gebruiker);
            List<Gebruiker> followers = ks.GetFollowers(gebruiker);
            List<Gebruiker> following = ks.GetFollowing(gebruiker);
            ks.CreateTweet(new Tweet() { content = "Dit is de tweede tweet van Simon", postedFrom = "Android", postDate = DateTime.Now }, gebruiker);
        }
    }
}