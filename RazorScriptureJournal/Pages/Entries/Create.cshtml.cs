using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorScriptureJournal.Data;
using RazorScriptureJournal.Models;

namespace RazorScriptureJournal.Pages.Entries
{
    public class CreateModel : PageModel
    {
        private readonly RazorScriptureJournal.Data.RazorScriptureJournalContext _context;

        public CreateModel(RazorScriptureJournal.Data.RazorScriptureJournalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Entry Entry { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Entry == null || Entry == null)
            {
                return Page();
            }

            _context.Entry.Add(Entry);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
