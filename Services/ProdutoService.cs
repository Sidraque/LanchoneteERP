using LanchoneteCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LanchoneteCore.Services
{
    public class ProdutoService
    {
        private readonly LanchoneteCoreContext _context;

        public ProdutoService(LanchoneteCoreContext context)
        {
            _context = context;
        }

        public List<Produto> FindAll()
        {
            return _context.Produto.OrderBy(x => x.Nome).ToList();
        }
        public IEnumerable<Produto> produtos => _context.Produto.Include(c => c.Disponibilidade);
    }
}
