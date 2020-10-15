namespace Maybe {
    public abstract class Maybe<T> {
        internal Maybe() {}

        public static Maybe<T> TryCreateSuccess(T value) {
            if (value != null) {
                return new Success<T>(value);
            }
            
            return new Failure<T>();
        }
        
        public static Failure<T> CreateFailure() {
            return new Failure<T>();
        }
    }
    
    public class Success<T> : Maybe<T> {
        internal Success(T value) {
            Value = value;
        }

        public T Value { get; }
    }
    
    public class Failure<T> : Maybe<T> {
        internal Failure() {}
    }
}