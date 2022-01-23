using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Blog.WepApi.Context;
using Blog.WepApi.Entity;

namespace Blog.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly BlogDbContext _context;

        public CommentsController(BlogDbContext context)
        {
            _context = context;
        }


        // GET: api/Comments/5
        [HttpGet("{postId}")]
        public async Task<ActionResult<List<Comments>>> GetComments(int postId)
        {
            var comments = await _context.Comments.Where(x=> x.PostId == postId).OrderByDescending(x=> x.Date).ToListAsync();

            if (comments == null)
            {
                return NotFound();
            }

            return comments;
        }

        // POST: api/Comments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostComments(Comments comments)
        {
            _context.Comments.Add(comments);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
