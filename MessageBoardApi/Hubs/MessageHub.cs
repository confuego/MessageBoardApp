using System.Linq;
using Microsoft.AspNetCore.SignalR;
using Services;

namespace MessageBoardApi.Hubs
{
    public class MessageHub : Hub
    {
        private readonly IMessageService _messageService;
        
        public MessageHub(IMessageService messageService)
        {
            _messageService = messageService;
        }
        
        public void Send(MessageDto dto)
        {
            _messageService.Create(dto);
            Clients.All.InvokeAsync("send", dto);
        }

        public void Get(int skip, int take)
        {
            Clients.Client(Context.Connection.ConnectionId).InvokeAsync("get", _messageService.Read(skip, take).ToList());
        }
    }
}