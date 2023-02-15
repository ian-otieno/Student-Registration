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
    public class IndexModel : PageModel
    {
        private readonly KHSchool.Data.KHSchoolContext _context;

        public IndexModel(KHSchool.Data.KHSchoolContext context)
        {
            _context = context;
        }

        public IList<Registration> Registration { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Registration != null)
            {
                Registration = await _context.Registration.ToListAsync();
            }
        }
    }
}
