using System.ComponentModel.DataAnnotations;

namespace EHI.Entities.CustomEntities.Contact
{
    public class AddContact
    {
        [Required(ErrorMessage = "First name is required")]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [MaxLength(320)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Invalid phone number or length should be 10 only")]
        public string Phone { get; set; }
      
    }
}
