using System.ComponentModel.DataAnnotations;

namespace TitanWeb.Domain.DTO.Button
{
    public class ButtonDTO
    {
        public int ButtonId { get; set; }
        public string Label { get; set; }
        public bool Status { get; set; }
        [Timestamp]
        public byte[] Version { get; set; }
    }
}
