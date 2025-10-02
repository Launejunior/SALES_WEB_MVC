namespace SALES_WEB_MVC.Models
{
    public class SellerVendedor
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public double BaseSalário { get; set; }
        public Departamento Departamento { get; set; }
        public ICollection<SalesRecorde> SalesRecorde { get; set; } = 
            new List<SalesRecorde>();

        public SellerVendedor() { }

        public SellerVendedor(int id, string? nome, string? email, 
            DateTime dataNascimento, double baseSalário, Departamento departamento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            BaseSalário = baseSalário;
            Departamento = departamento;
        }

        public void AddSales(SalesRecorde sr)
        {
            SalesRecorde.Add(sr);
        }
        public void RemoveSales(SalesRecorde sr)
        {
            SalesRecorde.Remove(sr);
        }
        public double TotalSales(DateTime inicial, DateTime final)
        {
            return SalesRecorde.Where(sr => sr.Data >= inicial && sr.Data <= 
            final).Sum(sr => sr.AmountQuantidade);
        }
    }
}




