using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper1.Services;
using Dapper1.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dapper1.Pages
{
    public class CreateModel : PageModel
    {
        private readonly Iwin _iwin;
        public CreateModel(Iwin iwin)
        {
            _iwin = iwin;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
      
        public async Task<IActionResult> OnPostCreate(CreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _iwin.Add(model);
                
                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}
