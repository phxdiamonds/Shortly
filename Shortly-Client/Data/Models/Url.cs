namespace Shortly_Client.Data.Models
{
    public class Url
    {
        //Storing data to the database

        public int Id { get; set; }

        public string OriginalLink { get; set; }

        public string ShortLink { get; set; }

        public int NoOfClicks { get; set; }

        public int? UserId { get; set; }


        public DateTime DateCreated { get; set; }


        public DateTime? DateUpdated { get; set; }
    }
}
