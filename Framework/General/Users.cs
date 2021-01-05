namespace TestFramework.Pages.Authorythation
{
    public class Users
    {
        public static User UserAli = new User("alikaalinkaali3@gmail.com", "111111", "Ali");
    }

    public class User
    {
        public string Email;
        public string Password;
        public string Name;

        public User(string Email, string Password, string Name)
        {
            this.Email = Email;
            this.Password = Password;
            this.Name = Name;
        }
    }
}
