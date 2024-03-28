namespace TitanWeb.Domain.DTO.RequestForm
{
    public class RequestFormDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
