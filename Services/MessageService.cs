using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Data.DbSets;


namespace Services
{

    public class MessageDto
    {
        public int Id { get; set; }
        
        public string Description { get; set; }
        
        public string Title { get; set; }
        
        public string User { get; set; }
        
        public DateTime CreatedDate { get; set; }
    }
    
    public interface IMessageService
    {
        IEnumerable<MessageDto> Read(int skip, int take);
        void Create(MessageDto dto);
    }
    
    public class MessageService : IMessageService
    {
        private readonly MessagingContext _context;
        
        public MessageService(MessagingContext context)
        {
            _context = context;
        }
        
        public IEnumerable<MessageDto> Read(int skip, int take)
        {
            return _context.Messages
                .OrderBy(x => x.CreatedDate)
                .Skip(skip)
                .Take(take).Select(x => new MessageDto
                {
                    Id = x.Id,
                    Description = x.Description,
                    Title = x.Title,
                    User = x.User
                });
        }

        public void Create(MessageDto dto)
        {
            var messageToSave = new Message
            {
                Description = dto.Description,
                Title = dto.Title,
                CreatedDate = DateTime.UtcNow,
                User = dto.User
            };
            
            _context.Messages.Add(messageToSave);
            _context.SaveChanges();

            dto.CreatedDate = messageToSave.CreatedDate;
        }
    }
}