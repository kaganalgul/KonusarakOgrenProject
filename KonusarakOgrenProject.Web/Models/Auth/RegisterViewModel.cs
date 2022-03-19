using System.ComponentModel.DataAnnotations;

namespace KonusarakOgrenProject.Web.Models.Auth
{
    public class RegisterViewModel
    {
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [RegularExpression(@"^[a-zA-Z]\w{8,14}$", ErrorMessage = "Your password should be at least 8 characters")]
        public string Password { get; set; }
    }
}
