namespace EmailFlow.Models
{
    public class PostMail
    {
        public int ID { get; set; }
        public string To { get; set; }

        public string From { get; set; }

        public string Cc { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

    }
}
