using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dinners2.Dtos
{
    public class DinnerDto
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

        public List<string> Tags { get; set; } = new List<string>();

        public byte[]? ImageData { get; set; }
    }

    public enum DinnerType
    {
        Fish,
        Meat,
        Chicken,
        Vegan,
        Soup,
        Pasta,
        Other
    }

    public enum MeatType
    {
        Beef,
        Pork,
        Lamb,
        Chicken,
        Wild,
        Other
    }

    public enum SkillLevel
    {
        Easy,
        Medium,
        Hard,
        Expert,
        Impossible
    }
}
