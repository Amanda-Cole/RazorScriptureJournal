﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorScriptureJournal.Data;
using RazorScriptureJournal.Models;

namespace RazorScriptureJournal.Pages.Entries
{
    public class EditModel : PageModel
    {
        private readonly RazorScriptureJournal.Data.RazorScriptureJournalContext _context;

        public EditModel(RazorScriptureJournal.Data.RazorScriptureJournalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Entry Entry { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Entry == null)
            {
                return NotFound();
            }

            var entry =  await _context.Entry.FirstOrDefaultAsync(m => m.Id == id);
            if (entry == null)
            {
                return NotFound();
            }
            Entry = entry;
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

            _context.Attach(Entry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntryExists(Entry.Id))
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

        private bool EntryExists(int id)
        {
          return (_context.Entry?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
