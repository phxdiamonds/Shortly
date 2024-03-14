using System.ComponentModel.DataAnnotations;

namespace Shortly_Client.Data.ViewModels
{
    public class PostUrlVM
    {
        [Required(ErrorMessage = "Url is required")]
        [RegularExpression(@"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$", ErrorMessage = "The Value is not a valid Url")]
        public string Url { get; set; }
    }
}
