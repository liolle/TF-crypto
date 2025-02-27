using cryper.models;

namespace cryper.database;

public interface IDatabaseContext
{
    void AddMessage(string content, string username, string password);
    int? GetUserId(string username, string password);
    string? GetUserKey(string username, string password);
    User? GetUser(string username, string password);
    Message? GetMessageById(int messageId);
    List<Message> GetAllMessage();
}

public class DatabaseContext : IDatabaseContext
{
    private static List<User> Users { get; } = [];

    private static List<Message> Messages { get; } = [];

    static DatabaseContext()
    {
        // Need to be in the DB
        Users = [
            new("16_bytes_key_456","John","asEFt91_73",1),
            new("16_bytes_key_789","Victor","plIJy19_37",2),
            new("16_bytes_key_123","Ben","wsCF31_97",3),
        ];
    }

    public void AddMessage(string content, string username, string password)
    {
        User? user = Users.Find(user => user.Username == username && user.Password == password);
        if (user is null) { return; }

        // Assuming that the message is already encrypted
        Messages.Add(new Message(Messages.Count + 1, content, user.Id));
    }

    public Message? GetMessageById(int messageId)
    {
        return Messages.Find(message => message.Id == messageId);
    }


    public List<Message> GetAllMessage()
    {
        return Messages;
    }

    public int? GetUserId(string username, string password)
    {
        return Users.Find(user =>
        {
            return user.Username == username && user.Password == password;
        })?.Id;
    }

    public User? GetUser(string username, string password)
    {
        return Users.Find(user =>
        {
            return user.Username == username && user.Password == password;
        });
    }

    public string? GetUserKey(string username, string password)
    {
        return Users.Find(user =>
        {
            return user.Username == username && user.Password == password;
        })?.Crypt_key;
    }
}