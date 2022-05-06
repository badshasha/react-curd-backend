using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using it.Services.Repo;
using it.Model.ViewModel;
using it.Model;

namespace it.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloggerController : ControllerBase
    {
        private readonly BloggerService bloggerServices;
        public BloggerController(BloggerService service)
        {
            this.bloggerServices = service;
        }

        [HttpGet("getAll")]        
        public IActionResult GetAllBloggers() {
            return Ok(this.bloggerServices.FindAll());
        }

        [HttpGet("getFromid/{id}")]        
        public IActionResult GetBloggerFromId(int id) {
            return Ok(this.bloggerServices.Find(id));
        }

        [HttpDelete("DeleteBlogger/{id}")]
        public IActionResult DeleteBloggerFromId(int id)
        {
            bool success_message =this.bloggerServices.Delete(id);
            if (success_message) return Ok("blogger delete success");
            return BadRequest("blogger delete un successfull");
        }

        //[HttpPut("updateBlogger/{id}")]        
        //public IActionResult UpdateBloggerFromId(int id, [FromBody] BloggerViewModel updateInfo) {
        //    var blogger = this.bloggerServices.UpdateBlogger(id, updateInfo);
        //    if (blogger == null) return BadRequest("blogger cannot update");
        //    return Ok(blogger);
        //}

        [HttpPost("[action]")]
        public IActionResult CreateBlogger([FromBody]BloggerViewModel newModel) {
            Blogger newBlogger = new Blogger
            {
                Name = newModel.name,
            };
            this.bloggerServices.Add(newBlogger);
            return Ok(newBlogger);
            
        }
    }
}
