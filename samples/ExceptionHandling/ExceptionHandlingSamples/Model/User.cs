namespace ExceptionHandlingSamples.Model {
    public class User {
        public User(string id, string name, string surname) {
            Id = id;
            Name = name;
            Surname = surname;
        }

        public string Id { get; }
        
        public string Name { get; }
        
        public string Surname { get; }
    }
}