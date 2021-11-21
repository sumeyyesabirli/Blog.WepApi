﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WepApi.Entity
{
    public class Post 
    {
	
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ContentText { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
		public string ImageUrl { get; set; }
        public DateTime Date { get; set; }

    }
}
