using ExceptionHandlingSamples.Model;
using Maybe;

namespace ExceptionHandlingSamples.Maybe {
    public class UserService {
        public Maybe<User> GetUser(string id) {
            if (UserStorage.DefaultUser.Id == id) {
                return Maybe<User>.TryCreateSuccess(UserStorage.DefaultUser);
            }
            
            return Maybe<User>.CreateFailure();
        }
    }
}