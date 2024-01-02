namespace EmailFlow.Models
{
    public class Group
    {
            public int GroupID { get; set; }
            public string GroupName { get; set; }
            public string Description { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; } 
            public ICollection<Recipient> Recipients { get; set; } 
    }
}
