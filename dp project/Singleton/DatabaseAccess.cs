using System;
using System.Data.SqlClient;


namespace dp_project
{
    class DatabaseAccess
    {
        private static DatabaseAccess instance = null;
        private SqlConnection connection;

        private DatabaseAccess()
        {
            // Establish database connection
            connection = new SqlConnection(@"Data Source=DESKTOP-63B15F9\MSSQLSERVER01;Initial Catalog=TaskSceduler;Integrated Security=True");
            connection.Open();
        }

       public static DatabaseAccess getInstance()
        {
            if (instance == null)
            {
                instance = new DatabaseAccess();
            }
            return instance;
        }

        internal object GetAllUsers()
        {
            throw new NotImplementedException();
        }

        

        internal void CreateTask(Task task)
        {
            throw new NotImplementedException();
        }

        internal void UpdateUserStatus(int uSER_ID, string v)
        {
            throw new NotImplementedException();
        }

        // Methods for CRUD operations on Users and Tasks
        public void CreateUser(Users user)
        {
            string maxQuery = "SELECT ISNULL(MAX(USER_ID), 0) FROM Users";
            int maxUserId;

            using (SqlCommand maxCommand = new SqlCommand(maxQuery, connection))
            {
                maxUserId = (int)maxCommand.ExecuteScalar();
            }

            user.USER_ID = maxUserId + 1;

            string query = "INSERT INTO Users (USER_ID, USER_NAME, USER_PASSWORD, USER_STATUS, USER_ROLE) " +
                           "VALUES (@UserID, @Username, @Password, @Status, @Role)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserID", user.USER_ID);
                command.Parameters.AddWithValue("@Username", user.USER_NAME);
                command.Parameters.AddWithValue("@Password", user.USER_PASSWORD);
                command.Parameters.AddWithValue("@Status", user.USER_STATUS);
                command.Parameters.AddWithValue("@Role", user.USER_ROLE);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    // Handle potential database errors gracefully
                    Console.WriteLine("Error creating user: {0}", ex.Message);
                    // Consider logging the error for troubleshooting
                }
            }
        }

        public Users GetUserById(int userId)
        {
            Users user = null;

            string query = "SELECT * FROM Users WHERE USER_ID = @UserId";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserId", userId);

                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Map database columns to User object properties
                            user = new Users
                            {
                                USER_ID = reader.GetInt32(0),
                                USER_NAME = reader.GetString(1),
                                USER_PASSWORD = reader.GetString(2), // Consider secure password retrieval if needed
                                USER_ROLE = reader.GetString(4),
                                USER_STATUS = reader.GetString(3)
                            };
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error retrieving user: {0}", ex.Message);
                }
            }

            return user;
        }

        public Users GetUserByUsernameAndPassword(string username, string password)
        {
            Users user = null;

            string query = "SELECT * FROM Users WHERE USER_NAME = @name;";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@name", username);

                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // User with the given username exists, now check the password
                            string storedPasswordHash = reader.GetString(2); // Assuming password hash is stored in the database

                            if (VerifyPassword(password, storedPasswordHash))
                            {
                                // Password is correct, create the user object
                                user = new Users
                                {
                                    USER_ID = reader.GetInt32(0),
                                    USER_NAME = reader.GetString(1),
                                    USER_PASSWORD = storedPasswordHash,
                                    USER_ROLE = reader.GetString(4),
                                    USER_STATUS = reader.GetString(3)
                                };
                            }
                            else
                            {
                                // Incorrect password
                                Console.WriteLine("Incorrect password for user: {0}", username);
                            }
                        }
                        else
                        {
                            // User not found
                            Console.WriteLine("User not found: {0}", username);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error retrieving user: {0}", ex.Message);
                }
            }

            return user;
        }

        // Method to verify the password using a secure hash comparison (e.g., BCrypt)
        private bool VerifyPassword(string enteredPassword, string storedPasswordHash)
        {
            // Implement your secure password verification logic here
            // For example, you can use a library like BCrypt to securely compare the passwords
            // Example: return BCrypt.Net.BCrypt.Verify(enteredPassword, storedPasswordHash);

            // For demonstration purposes, a simple string comparison is shown (not secure for production)
            return enteredPassword == storedPasswordHash;
        }
    }
}
