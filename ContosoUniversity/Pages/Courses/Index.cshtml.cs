using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;

namespace ContosoUniversity.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public IndexModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        //public IList<Course> Course { get;set; } = default!;
        /* UPDATE */
        public IList<Course> Courses { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.Courses != null)
            {
                //Course = await _context.Courses
                //.Include(c => c.Department).ToListAsync();

                Courses = await _context.Courses
                .Include(c => c.Department)
                .AsNoTracking()
                .ToListAsync();
            }
        }
    }
}

/*
 * The preceding code changes the Course property to Courses and adds AsNoTracking. 
 * AsNoTracking improves performance because the entities returned are not tracked. 
 * The entities don't need to be tracked because they're not updated in the current context.
 */
