using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Blog.WepApi.Context;
using Blog.WepApi.Entity;
using Blog.WepApi.Model;

namespace Blog.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly BlogDbContext _context;

        public PostsController(BlogDbContext context)
        {
            _context = context;
        }

        // GET: api/Posts
        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _context.Post.ToListAsync();
            var returnData = await MapPostModel(posts.OrderByDescending(x=> x.Id).ToList());
            return Ok(returnData);
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPosts(int id)
        {
            var posts = await _context.Post.FindAsync(id);

            if (posts == null)
            {
                return NotFound();
            }

            return posts;
        }

        // PUT: api/Posts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosts(int id, Post posts)
        {
            if (id != posts.Id)
            {
                return BadRequest();
            }

            _context.Entry(posts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Posts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Post>> PostPosts(Post posts)
        {
            _context.Post.Add(posts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPosts", new { id = posts.Id }, posts);
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePosts(int id)
        {
            var posts = await _context.Post.FindAsync(id);
            if (posts == null)
            {
                return NotFound();
            }

            _context.Post.Remove(posts);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PostsExists(int id)
        {
            return _context.Post.Any(e => e.Id == id);
        }

        [HttpGet("get-last-tree-posts")]
        //Ana sayfa için son 3 post
        public async Task<IActionResult> GetLastTreePosts()
        {
            var posts = await _context.Post.ToListAsync();
            posts = posts.OrderByDescending(x => x.Id).Take(3).ToList();
            var returnData = await MapPostModel(posts);
            return Ok(returnData);
        }



        //Maplama işlemi
        private async Task<List<PostModel>> MapPostModel(List<Post> posts)
        {
            List<PostModel> returnData = new List<PostModel>();

            foreach (var item in posts)
            {
                var category = await _context.Category.Where(x => x.Id == item.CategoryId).FirstOrDefaultAsync();
                var user = await _context.User.Where(x => x.Id == item.UserId).FirstOrDefaultAsync();
                returnData.Add(new PostModel
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    ContentText = item.ContentText,
                    Category = category.Name,
                    Author = user.Username,
                    Date = item.Date.ToString("dd.MM.yyyy"),
                    Img = item.ImageUrl
                });
            }
            return returnData;
        }
    }
}
/*
   public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ContentText { get; set; }
        public string Category { get; set; } //Category tablosundan Name kolonuna denk gelecek
        public string Author { get; set; } //yazıyı yazan kişi
        public string Img { get; set; }
        public string Date { get; set; } //Post tablosuundan gelen DateTime tipindeki veriyi manipüle edicez
 */