using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorScriptureJournal.Data;
using RazorScriptureJournal.Models;

namespace RazorScriptureJournal.Pages.Entries
{
    public class IndexModel : PageModel
    {
        private readonly RazorScriptureJournal.Data.RazorScriptureJournalContext _context;

        public IndexModel(RazorScriptureJournal.Data.RazorScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<Entry> Entry { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SearchStringNotes { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {

            ViewData["DateSortParam"] = String.IsNullOrEmpty(sortOrder) ? "date_desc" : "";
            ViewData["ReferenceSortParam"] = sortOrder == "reference" ? "reference_desc" : "reference";

            var entries = from x in _context.Entry
                          select x;


            switch (sortOrder)
            {
                case "date_desc":
                    entries = entries.OrderByDescending(e => e.Date);
                    break;
                case "reference":
                    entries = entries.OrderBy(e => e.Reference);
                    break;
                case "reference_desc":
                    entries = entries.OrderByDescending(e => e.Reference);
                    break;
                default:
                    entries = entries.OrderBy(e => e.Date);
                    break;
            }

            if (!string.IsNullOrEmpty(SearchString))
            {
                entries = entries.Where(s => s.Reference.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(SearchStringNotes))
            {
                entries = entries.Where(n => n.Notes.Contains(SearchStringNotes));
            }

            Entry = await entries.ToListAsync();
        }
    }
}
