using System.ComponentModel.DataAnnotations;

namespace InterviewFAQ.Model
{
    public class QNA
    {
        public int id {  get; set; }
        
        [Required]
        public string? question { get; set; }

        public string? answer { get; set; }

        public string? company { get; set; }
    }
}
