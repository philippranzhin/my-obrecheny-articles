using ExceptionHandlingSamples.Model;

namespace ExceptionHandlingSamples.Classic {
    public class UserService {
        /// <exception cref="UserNotFoundException">Throws, if user with given ID doesn't exists</exception>
        public User GetUser(string id) {
            if (UserStorage.DefaultUser.Id == id) return UserStorage.DefaultUser;

            throw new UserNotFoundException();
        }
    }
}