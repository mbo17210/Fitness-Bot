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

    public void SaveUsers()
    {
        string projectDir = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName;
        string userSaveFile = "UserInfo/Users";
        foreach(KeyValuePair<string, User> user in _users)
        {
            string filepath = Path.Combine(projectDir, userSaveFile, user.Key);
            
        }
    }
}