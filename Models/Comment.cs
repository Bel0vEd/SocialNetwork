using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int ProfileLink { get; set; }
        public string Sender { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
        public DateTime Data { get; set; }
    }
}
