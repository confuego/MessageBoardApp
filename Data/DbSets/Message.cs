using System;

namespace Data.DbSets
{
    public class Message
    {
        public int Id { get; set; }
        
        public string User { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public DateTime CreatedDate { get; set; }
    }
}