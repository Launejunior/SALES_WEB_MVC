using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SALES_WEB_MVC.Models;

namespace SALES_WEB_MVC.Data
{
    public class SALES_WEB_MVCContext : DbContext
    {
        public SALES_WEB_MVCContext (DbContextOptions<SALES_WEB_MVCContext> options)
            : base(options)
        {
        }

        public DbSet<SALES_WEB_MVC.Models.Departamento> Departamento { get; set; } = default!;
        public DbSet<SellerVendedor> SellerVendedores { get; set; } = default!;
        public DbSet<SalesRecorde> SalesRecorde { get; set; } = default!;
    }
}


