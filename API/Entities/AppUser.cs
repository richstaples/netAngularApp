namespace API.Entities
{
    /// <summary>
    /// Class for a user of the application
    /// </summary>
    public class AppUser
    {
        /// <summary>
        /// Id of the User
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Username of the User
        /// </summary>
        public string Username { get; set; }
        
        /// <summary>
        /// User First Name
        /// </summary>
        public string Firstname { get; set; }
    }
}