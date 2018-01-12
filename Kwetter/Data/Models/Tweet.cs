using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kwetter.Data.Models
{
    public class Tweet
    {
        public int Id { get; set; }
        public string content { get; set; }
        public string postedFrom { get; set; }
        //public DateTime postDate { get; set; }
    }
}