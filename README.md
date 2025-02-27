## Simple API for Message Encryption with In-Memory Storage

This API provides basic message encryption while using a temporary in-memory database.

#### Endpoints:
    POST /add – Stores a message in the database.
    POST /all – Retrieves all messages.

Only messages added by the requesting user are displayed in plain text.
## Dependencies 

[BStorm.Tools.Encryptions](https://www.nuget.org/packages/BStorm.Tools.Encryptions)
