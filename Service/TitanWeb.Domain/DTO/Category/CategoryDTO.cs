using TitanWeb.Domain.DTO.Items;

namespace TitanWeb.Domain.DTO.Category
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string UrlSlug { get; set; } 
        public string? Description { get; set; }
        public IList<ItemForCategoryDTO> Items { get; set; }
    }
}
