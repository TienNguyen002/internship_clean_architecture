using TitanWeb.Domain.DTO.Image;

namespace TitanWeb.Domain.DTO.SubItem
{
    public class SubItemDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public ImageDTO Image { get; set; }
    }
}
