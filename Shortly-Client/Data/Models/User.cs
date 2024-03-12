﻿namespace Shortly_Client.Data.Models
{
    public class User
    {
        //if you want to set up urls when ever you create the user, youc can define in this constructor
        public User()
        {
            //here you can define each user has some urls
            //so with this when ever you are going to initialize the object of type user, you also initialize the urls
            Urls = new List<Url>();
        }
        public int Id { get; set; }
        public string Email { get; set; }


        //for each user we are creating a list of links

        public List<Url> Urls { get; set; }
    }
}
