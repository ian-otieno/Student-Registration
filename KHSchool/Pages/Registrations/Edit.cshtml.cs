using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KHSchool.Data;
using KHSchool.Models;

namespace KHSchool.Pages.Registrations
{
    public class EditModel : PageModel
    {
        private readonly KHSchool.Data.KHSchoolContext _context;

        public EditModel(KHSchool.Data.KHSchoolContext context)
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

            var registration =  await _context.Registration.FirstOrDefaultAsync(m => m.ID == id);
            if (registration == null)
            {
                return NotFound();
            }
            Registration = registration;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Registration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistrationExists(Registration.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RegistrationExists(int id)
        {
          return (_context.Registration?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
