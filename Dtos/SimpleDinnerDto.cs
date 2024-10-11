using System.ComponentModel.DataAnnotations;

namespace Dinners2.Dtos
{
    // Basically just DinnerDto but without images hehe
    public class SimpleDinnerDto
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Description { get; set; }

        public DinnerType Type { get; set; }

        public MeatType? MeatType { get; set; }

        public SkillLevel SkillLevel { get; set; }

        public List<string> Ingredients { get; set; } = new List<string>();

        public bool WorthMakingLeftovers { get; set; } = false;

        public string? Notes { get; set; }

        public List<string> Tags { get; set; } = new List<string>();
    }
}
