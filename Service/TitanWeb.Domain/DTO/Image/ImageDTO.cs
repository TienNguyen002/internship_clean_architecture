namespace TitanWeb.Domain.DTO.Image
{
    public class ImageDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public string? Hyperlink { get; set; }
        public bool IsLogo { get; set; }
    }
}
