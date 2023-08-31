namespace KronoWeaveAPI.Models
{
    public class UserList
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserEmailAddress { get; set; }
        public bool? IsActive { get; set; }

        public string License1 { get; set; }
        public int? UserId { get; set; }
    }
}
