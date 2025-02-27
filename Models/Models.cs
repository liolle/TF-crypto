namespace cryper.models;

public class User(string crypt_key, string username, string password, int id)
{
    public int Id { get; } = id;
    public string Crypt_key { get; } = crypt_key;
    public string Username { get; } = username;
    public string Password { get; } = password;

}

public class Message(int id, string content, int userId)
{
    public int Id { get; } = id;
    public string Content { get; } = content;
    public int UserId { get; } = userId;
}

public class InMessage(string username, string password, string content)
{
    public string Username { get; } = username;
    public string Password { get; } = password;
    public string Content { get; } = content;
}

public class Credential(string username, string password)
{
    public string Username { get; } = username;
    public string Password { get; } = password;
}

