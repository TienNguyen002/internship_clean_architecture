namespace TitanWeb.Domain.DTO.Section
{
    public class SectionDetailDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string? JapaneseTitle { get; set; }
        public string UrlSlug { get; set; }
        public string? Description { get; set; }
        public string? JapaneseDescription { get; set; }
        public string BackgroundUrl { get; set; }
        public int SectionOrder { get; set; }
    }
}
