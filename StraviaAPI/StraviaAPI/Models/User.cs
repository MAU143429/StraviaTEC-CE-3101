namespace StraviaAPI.Models
{
    public class User
    {
        public String Name { get; set; }
        public String Lastname { get; set; }
        public String Nationality { get; set; }
        public String Birthdate { get; set; }
        public String Category { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String Image { get; set; }

        public User()
        {
        }

        public User(string name, string last_name, string nationality, string birthdate, string category, string username, string password, string image)
        {
            this.Name = name;
            this.Lastname = last_name;
            this.Nationality = nationality;
            this.Birthdate = birthdate;
            this.Category = category;
            this.Username = username;
            this.Password = password;
            this.Image = image;
        }
    }
}
