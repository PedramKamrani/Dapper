using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper1.Services;
using Dapper1.ViewModel;

namespace Dapper1.Pages
{
    public class IndexModel : PageModel
    {
        public List<WinViewModel> products { get; set; }
        private readonly Iwin _win;

        public IndexModel(Iwin win)
        {
            _win = win;
        }

        public async Task<IActionResult> OnGet()
        {
            products =await _win.GetAll();
            return Page();
        }
    }
}
