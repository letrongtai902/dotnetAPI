using System.ComponentModel.DataAnnotations;

namespace dotnetAPI.Model.Models
{
    public class Customer
    {
        [Key]
        public long ID { get; set; }

        [MaxLength(50)]
        public string FullName { get; set; }

        [MaxLength(30)]
        public string Email { get; set; }

        [MaxLength(15)]
        public string PhoneNumber { get; set; }

    }
}
