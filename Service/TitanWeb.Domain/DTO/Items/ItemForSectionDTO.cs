namespace TitanWeb.Domain.DTO.Items
{
    public class ItemForSectionDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UrlSlug { get; set; }
        public string? SubTitle { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string ImageUrl { get; set; }
        public string ButtonLabel { get; set; }
        public bool ButtonStatus { get; set; }
    }
}
