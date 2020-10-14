using System.Collections.Generic;
using ExceptionHandlingSamples.Model;

namespace ExceptionHandlingSamples {
    public static class UserStorage {
        public static User DefaultUser { get; } = new User("0", "John", "Doe");
    }
}