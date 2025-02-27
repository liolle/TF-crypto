using cryper.models;
using cryper.services;
using Microsoft.AspNetCore.Mvc;

namespace cryper.controllers;

public class MessageController(IMessageService messageService) : ControllerBase
{
    [HttpPost]
    [Route("/add")]
    public IActionResult AddMessage([FromBody] InMessage inMessage)
    {
        messageService.AddMessage(inMessage.Content, new Credential(inMessage.Username, inMessage.Password));
        return Ok();
    }

    [HttpPost]
    [Route("/all")]
    public IActionResult AllMessage([FromBody] Credential credential)
    {
        return Ok(messageService.GetAllMessage(credential));
    }
}