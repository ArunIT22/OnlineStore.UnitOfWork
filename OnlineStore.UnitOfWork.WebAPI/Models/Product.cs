namespace OnlineStore.UnitOfWork.WebAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal ListPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public float Discount { get; set; }
        public DateTime AddedDate { get; set; } = DateTime.Now;

        //Table Reference
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
