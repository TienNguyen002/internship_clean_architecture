using TitanWeb.Domain.DTO.SubItem;

namespace TitanWeb.Domain.DTO.Items
{
    public class ItemForCategoryDTO
    {
        public int Id { get; set; }
        public string? BoldTitle { get; set; }
        public string Title { get; set; }
        public string UrlSlug { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public string? TelNumber { get; set; }
        public string ImageUrl { get; set; }
        public string ButtonLabel { get; set; }
        public bool ButtonStatus { get; set; }
        public IList<SubItemDTO> SubItems { get; set; } 
    }
}
