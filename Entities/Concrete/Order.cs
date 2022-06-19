namespace Entities.Concrete
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
