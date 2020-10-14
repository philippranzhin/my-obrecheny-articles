using ExceptionHandlingSamples.Model;

namespace ExceptionHandlingSamples.SomeOrDefault {
    public class UserService {
        public User? GetUserOrDefault(string id) {
            if (UserStorage.DefaultUser.Id == id) {
                return UserStorage.DefaultUser;
            }
            
            return null;
        }
    }
}