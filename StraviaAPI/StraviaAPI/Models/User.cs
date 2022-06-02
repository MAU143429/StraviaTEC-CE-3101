namespace StraviaAPI.Models
{
    public class User
    {
        public String name { get; set; }
        public String last_name { get; set; }
        public String nationality { get; set; }
        public String birthdate { get; set; }
        public String category { get; set; }
        public String username { get; set; }
        public String password { get; set; }
        public String image { get; set; }

        public User()
        {
        }

        public User(string name, string last_name, string nationality, string birthdate, string category, string username, string password, string image)
        {
            this.name = name;
            this.last_name = last_name;
            this.nationality = nationality;
            this.birthdate = birthdate;
            this.category = category;
            this.username = username;
            this.password = password;
            this.image = image;
        }
    }
}
