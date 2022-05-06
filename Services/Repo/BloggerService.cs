using it.Services.Base;
using it.Model;
using Microsoft.EntityFrameworkCore;
using it.data;

namespace it.Services.Repo
{
    public class BloggerService : Repository<Blogger>
    {
        public BloggerService(ApplicationDbContext context) : base(context)
        {

        }
        
    }
}
