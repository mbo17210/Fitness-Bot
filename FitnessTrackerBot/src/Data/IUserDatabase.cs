namespace FitnessTrackerBot.Data.Schedule;


internal interface IUserDatabase
{
    public User GetUser(string username);

    public void AddUser(User user);
}