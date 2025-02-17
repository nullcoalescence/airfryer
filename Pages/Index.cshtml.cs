using airfryer.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace airfryer.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly AirfryerContext _dbContext;
    
        public IndexModel(ILogger<IndexModel> logger, AirfryerContext airfryerContext)
        {
            _logger = logger;
            _dbContext = airfryerContext;
        }

        public void OnGet()
        { 

        }
    }
}