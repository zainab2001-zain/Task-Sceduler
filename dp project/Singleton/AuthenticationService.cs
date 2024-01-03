using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dp_project
{
    class AuthenticationService
    {
        private static AuthenticationService instance;
        private List<(string Username, string Password)> credentials = new List<(string, string)>()
        {
            ("admin", "1234"),
            ("user1", "password1"),
            ("user2", "password2") // Add more credentials as needed
        };
        private AuthenticationService() { }
        public static AuthenticationService getInstance()
        {
            
                if (instance == null)
                {
                    instance = new AuthenticationService();
                }
                return instance;
            
        }
        // Authentication logic
        public bool Authenticate(string username, string password)
        {
            return credentials.Any(cred => cred.Username == username && cred.Password == password);
        }
        // or false based on authentication result
    }
    }

