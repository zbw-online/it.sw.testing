
namespace BrownfieldRefactoring
{
    public class DatabaseAccess
    {
        public DatabaseAccess()
        {
        }

        public virtual bool SaveUser(string name, string email)
        {
            Console.WriteLine($"DatabaseAccess: Saving user {name}, {email}");
            return true;
        }
    }
}