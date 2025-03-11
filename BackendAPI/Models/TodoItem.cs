using System.ComponentModel.DataAnnotations;

namespace BackendAPI.Models
{
    public class TodoItem
    {
        [Key]
        public int TodoId { get; set; }
        public string Name { get; set; } = null!;
        public string? Notes { get; set; }
        public bool Done { get; set; }
    }
}
