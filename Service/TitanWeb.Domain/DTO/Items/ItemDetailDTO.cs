﻿using TitanWeb.Domain.DTO.Section;
using TitanWeb.Domain.DTO.SubItem;

namespace TitanWeb.Domain.DTO.Items
{
    public class ItemDetailDTO
    {
        public int Id { get; set; }
        public string BoldTitle { get; set; }
        public string? JapaneseBoldTitle { get; set; }
        public string Title { get; set; }
        public string? JapaneseTitle { get; set; }
        public string UrlSlug { get; set; }
        public string? SubTitle { get; set; }
        public string? JapaneseSubTitle { get; set; }
        public string? ShortDescription { get; set; }
        public string? JapaneseShortDescription { get; set; }
        public string? Description { get; set; }
        public string? JapaneseDescription { get; set; }
        public bool IsDisplayed { get; set; }
        public string? Address { get; set; }
        public string? TelNumber { get; set; }
        public string? InfoGmail { get; set; }
        public string? InfoGmail2 { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public SectionForItemDTO Section { get; set; }
        public IList<SubItemDTO> SubItems { get; set; }
        public string ImageUrl { get; set; }
        public string Hyperlink { get; set; }
        public string ButtonLabel { get; set; }
        public string JapaneseButtonLabel { get; set; }
    }
}
