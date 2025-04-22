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
    [Authorize(Policy ="AdminOnly")]
    public class SettingsPage : PageModel
    {
        private readonly ILogger<SettingsPage> _logger;

        public SettingsPage(ILogger<SettingsPage> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}