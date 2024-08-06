using Dinners2.Dtos;

namespace Dinners2.Commands
{
    public class EditDinnerCommand
    {
        public Guid Id;
        public string Name { get; set; }
        public string Description { get; set; }
        public DinnerType Type { get; set; }
        public MeatType MeatType { get; set; }
        public List<string> Ingredients { get; set; } = new List<string>();
        public List<string> Tags { get; set; } = new List<string>();
        public byte[]? ImageData { get; set; }
    }
}
