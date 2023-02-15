using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KHSchool.Data;
using KHSchool.Models;

namespace KHSchool.Pages.Registrations
{
    public class DeleteModel : PageModel
    {
        private readonly KHSchool.Data.KHSchoolContext _context;

        public DeleteModel(KHSchool.Data.KHSchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Registration Registration { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Registration == null)
            {
                return NotFound();
            }

            var registration = await _context.Registration.FirstOrDefaultAsync(m => m.ID == id);

            if (registration == null)
            {
                return NotFound();
            }
            else 
            {
                Registration = registration;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Registration == null)
            {
                return NotFound();
            }
            var registration = await _context.Registration.FindAsync(id);

            if (registration != null)
            {
                Registration = registration;
                _context.Registration.Remove(Registration);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
