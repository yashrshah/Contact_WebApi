using System.ComponentModel.DataAnnotations;

namespace EHI.Entities.CustomEntities.Contact
{
    public class UpdateContact
    {
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Invalid phone number or length should be 10 only")]
        public string Phone { get; set; }
        public bool Active { get; set; }
    }
}
