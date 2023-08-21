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

    }
}
