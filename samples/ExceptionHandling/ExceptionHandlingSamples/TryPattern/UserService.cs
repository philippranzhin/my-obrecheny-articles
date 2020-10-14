using ExceptionHandlingSamples.Model;

namespace ExceptionHandlingSamples.TryPattern {
    public class UserService {
        public bool TryGetUser(string id, out User user) {
            if (UserStorage.DefaultUser.Id == id) {
                user = UserStorage.DefaultUser;
                return true;
            }

            user = default!;

            return false;
        }
    }
}