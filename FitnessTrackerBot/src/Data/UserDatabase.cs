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
        string username = user.Id;
        if(!_users.TryAdd(username, user))
        {
            throw new ArgumentException($"Username {username} already exists in database.");
        }
    }
}