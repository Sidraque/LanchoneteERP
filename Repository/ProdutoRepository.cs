using LanchoneteCore.Interfaces;
using LanchoneteCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanchoneteCore.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly LanchoneteCoreContext _context;

        public ProdutoRepository(LanchoneteCoreContext contexto)
        {
            _context = contexto;
        }
        public IEnumerable<Produto> produtos => _context.Produto;
    }
}
