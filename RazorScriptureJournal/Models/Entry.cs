using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RazorScriptureJournal.Models
{
    public class Entry
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Reference { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public string Notes { get; set; }
    }
}
