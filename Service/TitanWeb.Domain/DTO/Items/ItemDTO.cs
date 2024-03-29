using TitanWeb.Domain.DTO.Button;
using TitanWeb.Domain.DTO.Section;
using TitanWeb.Domain.DTO.SubItem;

namespace TitanWeb.Domain.DTO.Items
{
    public class ItemDTO
    {
        public int Id { get; set; }
        public string BoldTitle { get; set; }
        public string Title { get; set; }
        public string UrlSlug { get; set; }
        public string? SubTitle { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public string? TelNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public SectionForItemDTO Section { get; set; }
        public IList<SubItemDTO> SubItems { get; set; }
        public string ImageUrl { get; set; }
        public ButtonDTO Button { get; set; }
    }
}
