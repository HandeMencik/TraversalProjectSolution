using Microsoft.AspNetCore.Http;

namespace TraversalReservationProject.Areas.Member.Models
{
    public class UserEditViewModel
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string imageurl { get; set; }
        public IFormFile Image { get; set; }
    }
}
