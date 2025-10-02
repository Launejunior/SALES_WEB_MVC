using SALES_WEB_MVC.Models.Enum;

namespace SALES_WEB_MVC.Models
{
    public class SalesRecorde
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double AmountQuantidade { get; set; }
        public SalesStatus Status { get; set; }
        public SellerVendedor SellerVendedor { get; set; }

        public SalesRecorde() { }

        public SalesRecorde(int id, DateTime data, double amountQuantidade, 
            SalesStatus status, SellerVendedor sellerVendedor)
        {
            Id = id;
            Data = data;
            AmountQuantidade = amountQuantidade;
            Status = status;
            SellerVendedor = sellerVendedor;
        }
    }
}


