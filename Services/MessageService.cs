using cryper.database;
using cryper.models;

namespace cryper.services;

public interface IMessageService
{
    void AddMessage(string content, Credential credential);
    List<Message> GetAllMessage(Credential credential);
}

public class MessageService(IDatabaseContext databaseContext, Crypto crypto) : IMessageService
{
    public void AddMessage(string content, Credential credential)
    {
        string? crypt_key = databaseContext.GetUserKey(credential.Username, credential.Password);
        if (crypt_key is null) { return; }
        databaseContext.AddMessage(crypto.Encrypt(content, crypt_key), credential.Username, credential.Password);
    }

    public List<Message> GetAllMessage(Credential credential)
    {
        List<Message> messages = databaseContext.GetAllMessage();
        User? user = databaseContext.GetUser(credential.Username, credential.Password);
        if (user is null) { return messages; }
        return messages.Select(val =>
        {
            if (user.Id != val.UserId){return val;}
            return new Message(val.Id, crypto.Decrypt(val.Content, user.Crypt_key), val.UserId);
        }).ToList();
    }

}