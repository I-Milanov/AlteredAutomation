using Bogus;

namespace Infrastructure
{
    public static class UserFactory
    {
        public static User RegisteredUser()
        {
            return new User
            {
                Email = Environment.GetEnvironmentVariable("altered_username"),
                Password = Environment.GetEnvironmentVariable("altered_password"),
                Name = "IMilanov",
            };
        }

        public static User FakePassword()
        {
            var fakeUser = new Faker<User>()
                    .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.Name))
                    .RuleFor(u => u.Password, (f, u) => u.Password = f.Internet.Password());

           return fakeUser;
        }
    }
}
