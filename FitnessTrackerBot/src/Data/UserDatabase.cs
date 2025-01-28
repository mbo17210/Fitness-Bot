namespace FitnessTrackerBot.Data.Schedule;


internal class UserDatabase : IUserDatabase
{
    private Dictionary<string, User> _users = [];

    public User GetUser(string username)
    {
        return _users[username]; 
    }

    public void AddUser(User user)
    {
        if(!_users.TryAdd(user.Id, user))
        {
            throw new ArgumentException($"User already exists in database.");
        }
    }
}