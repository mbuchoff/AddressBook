using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DbSchema;

namespace AddressBook.Pages.Scaffolded
{
    public class IndexModel : PageModel
    {
        private readonly DbSchema.AddressBookContext _context;

        public IndexModel(DbSchema.AddressBookContext context)
        {
            _context = context;
        }

        public IList<Person> Person { get;set; }

        public async Task OnGetAsync()
        {
            Person = await _context.People.ToListAsync();
        }
    }
}
