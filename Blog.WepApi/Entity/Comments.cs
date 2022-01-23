using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WepApi.Entity
{
    public class Comments
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Mail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public int PostId { get; set; }
    }
}
