namespace Application
{
    public class OrderDto
    {
        public int Id { get; set; }
        public decimal Total { get; internal set; }
    }
}