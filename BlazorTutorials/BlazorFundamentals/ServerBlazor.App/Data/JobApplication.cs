using System;
using System.ComponentModel.DataAnnotations;

namespace ServerBlazor.Data
{
    public class JobApplication
    {
        [Required]
        public string Fullname { get; set; }

        [StringLength(500, ErrorMessage = "You cannot put so many words here")]
        public string Description { get; set; }

        [Required]
        [Range(10000, 150000, ErrorMessage = "Salary cannot be less than 10000 or bigger than 150000")]
        public int SalaryExpectation { get; set; }

        [Required]
        public bool DoesOpenSource { get; set; }

        [Required]
        public DateTime Availability { get; set; }
    }
}