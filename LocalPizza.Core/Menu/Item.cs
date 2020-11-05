using LocalPizza.Core.Interfaces;

namespace LocalPizza.Core.Menu
{
    public class Item : IItem
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ProductRange Range { get; set; }
        public string ProductPicture { get; set; }
    }
}