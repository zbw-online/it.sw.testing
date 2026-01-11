using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrownfieldRefactoring
{
    class UserManager
    {
        private Logger logger = new Logger();
        private DatabaseAccess dbAccess = new DatabaseAccess();

        public void AddUser(string name, string email)
        {
            // Logik zum Hinzufügen eines Benutzers
            logger.Log($"Adding user {name}");
            if (dbAccess.SaveUser(name, email))
            {
                logger.Log("SaveUser succeeded!");
            }
            else
            {
                logger.Log("SaveUser failed!");
            }
        }
    }
}
