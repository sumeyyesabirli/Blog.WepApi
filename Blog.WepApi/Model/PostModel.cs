using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WepApi.Model
{
    public class PostModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ContentText { get; set; }
        public string Category { get; set; } //Category tablosundan Name kolonuna denk gelecek
        public string Author { get; set; } //yazıyı yazan kişi
        public string Img { get; set; }
        public string Date { get; set; } //Post tablosuundan gelen DateTime tipindeki veriyi manipüle edicez
    }
}
/*
    Entity -> Db'deki tabloalrın tam olarak karşılıklaır
    Model -> Dbden alınan sadece belirli field(kolon)ların manipüle edilmesi diyebiliriz
 */