using Microsoft.EntityFrameworkCore;
using RazorScriptureJournal.Data;

namespace RazorScriptureJournal.Models
{
public class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RazorScriptureJournalContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorScriptureJournalContext>>()))
        {
            // Look for any Entries.
            if (context.Entry.Any())
            {
                return;   // DB has been seeded
            }

            context.Entry.AddRange(
                new Entry
                {
                    Reference = "1 Nephi 3:7",
                    Date = DateTime.Parse("2023-10-23"),
                    Notes = "Test I will go and Do seed data",

                },

                new Entry
                {
                    Reference = "1 Nephi 14:1-2",
                    Date = DateTime.Parse("2023-10-1"),
                    Notes = "Gentiles shall know the Lamb of God seed data",
                },

                new Entry
                {
                    Reference = "Alma 18:1",
                    Date = DateTime.Parse("2023-10-24"),
                    Notes = "Stand forth and testify seed data",
                },

                new Entry
                {
                    Reference = "3 Nephi 8:21",
                    Date = DateTime.Parse("2023-9-30"),
                    Notes = "And there was darkness upon the face of the land seed data",
                }
            );
            context.SaveChanges();
                    }
                }
            }
        }
    

