using KronoWeaveAPI.Models;



namespace KronoWeaveAPI.Repository
{
    public class UserRepository
    {
        KronoWeaveContext KronoWeaveContext = new KronoWeaveContext();



        public User GetUserName(string EmailAddress)
        {
            User user = new User();


            user = KronoWeaveContext.User.Where(x => x.UserEmailAddress == EmailAddress).Select(x => x).FirstOrDefault();

            return user!;
        }

        public License GetLicenseType(int UserID)
        {
            License license = new License();

            license = KronoWeaveContext.License.Where(x => x.UserId == UserID).Select(x => x).FirstOrDefault();

            return license!;
        }

        public int GetUserID(string EmailAddress)
        {
            int UserID = KronoWeaveContext.User.Where(x => x.UserEmailAddress == EmailAddress).Select(x => x.Id).FirstOrDefault();

            return UserID;
        }


        public List<UserList> GetUsers()
        {
            List<User> user = new List<User>();

            List < License> license = new List<License>();

            List<UserList> list = new List<UserList>();

            user = KronoWeaveContext.User.Select(x => x).ToList<User>();

            license = KronoWeaveContext.License.Select(x => x).ToList<License>();


            var joinedList = license
            .Join(user,
                license => license.UserId,
                user => user.Id,
                (license, user) => new
                {
                    LicenseType = license.License1,
                    UserId = user.Id,
                    UserName = user.UserName,
                    UserEmailAddress = user.UserEmailAddress,
                    IsActive = user.IsActive
                })
            .ToList();


            foreach (var item in joinedList)
            {
                list.Add(new UserList { Id = item.UserId, License1 = item.LicenseType, IsActive = item.IsActive, UserEmailAddress = item.UserEmailAddress, UserName = item.UserName });
            }


            return list!;
        }

    }
}
