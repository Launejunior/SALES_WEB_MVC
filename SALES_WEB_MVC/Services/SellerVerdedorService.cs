using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using SALES_WEB_MVC.Data;
using SALES_WEB_MVC.Models;
using SALES_WEB_MVC.Services.Exception;
//using SALES_WEB_MVC.Services.Exceptions;


namespace SALES_WEB_MVC.Services
{
    public class SellerVendedorService
    {
        private readonly SALES_WEB_MVCContext _context;

        public SellerVendedorService(SALES_WEB_MVCContext context)
        {
            _context = context;
        }

        //Entra a lógica de Negócio
        public async Task<List<SellerVendedor>> FindAllAsync()
        {
            return await _context.SellerVendedores.ToListAsync();
        }

        public async Task InsertAsync(SellerVendedor obj)
        {
            //obj.Department=_context.Department.First();
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<SellerVendedor> FindByIdAsync(int id)
        {
            if (_context == null)
            {
                throw new ArgumentNullException(nameof(_context), "Context is null");
            }
            // Carrega o vendedor com seu departamento
            var seller = await _context.SellerVendedores
                                        .Include(obj => obj.Departamento)
                                        .FirstOrDefaultAsync(obj => obj.Id == id);

            // Verifica se o vendedor é nulo
            if (seller == null)
            {
                // Se não for encontrado nenhum vendedor com o ID especificado
                return null; // Ou você pode lançar uma exceção, se preferir
            }
            return seller;
            //return await _context.Sellers.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.SellerVendedores.FindAsync(id);
                _context.SellerVendedores.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);

            }
        }

        public async Task UpdateAsync(SellerVendedor obj)
        {
            bool hasAny = await _context.SellerVendedores.AnyAsync(x => x.Id == obj.Id);

            if (!hasAny)
            {

                throw new NotFoundException("Não Achei o Dado");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();

            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }

    }
}

