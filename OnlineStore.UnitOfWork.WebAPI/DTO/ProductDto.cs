namespace OnlineStore.UnitOfWork.WebAPI.DTO
{
    public class ProductDto
    {
        public string Product_Name { get; set; } = null!;
        public decimal ListPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public float Discount { get; set; }
        public string CategoryName { get; set; } = null!;
    }

    public class AddOrUpdateProductDto
    {
        public int? Id { get; set; }
        public string Product_Name { get; set; } = null!;
        public decimal ListPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public float Discount { get; set; }
        public int CategoryId { get; set; }
    }
}
