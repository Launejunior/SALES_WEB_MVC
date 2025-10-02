

namespace SALES_WEB_MVC.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public ICollection<SellerVendedor> SellerVendedores { get; set; }
           = new List<SellerVendedor>();


        public Departamento() { }

        public Departamento(int id, string? nome)
        {
            Id = id;
            Nome = nome;
        }

        public void AddSellerVendedor(SellerVendedor sellerVendedor)
        {
            SellerVendedores.Add(sellerVendedor);
        }

        public double TotalSalesRecorde(DateTime inicial, DateTime final)
        {
            return SellerVendedores.Sum(sellerVendedor => sellerVendedor.TotalSales(inicial, final));
        }
    }
}

