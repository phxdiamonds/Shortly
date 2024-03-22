namespace Shortly_Client.Data.ViewModels
{
    public class GetUrlVM
    {
        //here we use the only properties we need to show in the view from the controller

        public int Id { get; set; }

        public string OriginalLink { get; set; }

        public string ShortLink { get; set; }

        public int NoOfClicks { get; set; }

        public string? UserId { get; set; }

        //Navigational Property
        public GetUserVM? User { get; set; }
    }
}
