namespace LocalPizza.Core.Interfaces
{
    public interface IItem
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public MenuType MenuType { get; set; }
        public string IMGuri { get; set; }
        public string Description { get; set; }
    }
}