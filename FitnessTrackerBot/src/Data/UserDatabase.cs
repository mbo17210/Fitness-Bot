using System.Text.Json;

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
        string projectDir = Environment.CurrentDirectory;
        string userSaveFile = "UserInfo/Users";
        foreach(KeyValuePair<string, User> user in _users)
        {
            string filepath = Path.Combine(projectDir, userSaveFile, user.Key + ".json");
            File.WriteAllText(filepath, JsonSerializer.Serialize(user.Value));
        }
    }

    public void LoadUsers()
    {
        string projectDir = Environment.CurrentDirectory;
        string userSaveFile = "UserInfo/Users";
        string folderpath = Path.Combine(projectDir, userSaveFile);
        Console.WriteLine(folderpath);
        foreach (string file in Directory.EnumerateFiles(folderpath, "*.json"))
        {
            string userJson = File.ReadAllText(file);
            User? user = JsonSerializer.Deserialize<User>(userJson);
            if (user == null)
            {
                Console.WriteLine($"Error deserializing user at path {file}.");
                continue;
            }
            _users.Add(user.Id, user);
        }
    }
}