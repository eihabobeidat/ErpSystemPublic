using ErpSystem.core.Data;
using ErpSystem.core.DTO;
using ErpSystem.core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErpSystem.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        IMessageService _service;
        public MessageController(IMessageService service)
        {
            _service = service;
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<int> Delete(decimal id)
        {
            return await _service.Delete(id);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<List<ChatMessageDTO>> GetAll()
        {
            return  await _service.GetAll();
        }

        [HttpPost]
        [Route("Insert")]
        public async Task<int> Insert([FromBody] Message message)
        {
            return await _service.Insert(message);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<int> Update([FromBody] Message message)
        {
            return await _service.Update(message);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<Message> GetById(decimal id)
        {
            return await _service.GetById(id);
        }
        
        [HttpPost]
        [Route("GetConversation")]
        public async Task<List<Message>> GetConversation([FromBody] ConversationDTO conversationDTO)
        {
            return await _service.GetConversation(conversationDTO);
        }

        [HttpPost]
        [Route("GetMessages/{id}")]
        public async Task<List<Message>> GetMessages(decimal id)
        {
            return await _service.GetMessages(id);
        }
        


    }
}
