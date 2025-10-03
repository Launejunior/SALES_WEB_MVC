using Microsoft.EntityFrameworkCore;
using SALES_WEB_MVC.Data;
using SALES_WEB_MVC.Models;
using System.Linq;


namespace SALES_WEB_MVC.Services
{
    public class DepartamentoService
    {
        private readonly SALES_WEB_MVCContext _context;

        public DepartamentoService(SALES_WEB_MVCContext context)
        {
            _context = context;
        }
        public async Task<List<Departamento>> FindAllAsync()
        {
            //necesário importar o Entityframeworkcore
            return await _context.Departamento.OrderBy(x => x.Nome).ToListAsync();
        }




    }
}
