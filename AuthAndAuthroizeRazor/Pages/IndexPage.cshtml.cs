using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AuthAndAuthroizeRazor.Pages
{
    [Authorize]
    public class IndexPage : PageModel
    {
        private readonly ILogger<IndexPage> _logger;

        public IndexPage(ILogger<IndexPage> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}