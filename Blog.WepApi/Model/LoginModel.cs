using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WepApi.Model
{
    public class LoginModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public bool IsLogin { get; set; }
    }
}
