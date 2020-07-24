namespace LocalPizza.Core.Interfaces
{
    public interface IItem
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}