namespace EmailFlow.Models
{
    public class Recipient
    {
        public int RecipientId { get; set; }

        public string EmailAddress {  get; set; }

        public string FirstName {  get; set; }

        public string LastName{  get; set; }

        public string PhoneNumber { get; set; }

        public bool IsActive {  get; set; }
        public bool IsOptedIn { get; set; }

        public int GroupID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


    }
}
