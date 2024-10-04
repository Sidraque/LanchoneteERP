using LanchoneteCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanchoneteCore.Services
{
    public class ClienteService
    {
        private readonly LanchoneteCoreContext _context;

        public ClienteService(LanchoneteCoreContext context)
        {
            _context = context;
        }

        public List<Cliente> FindAll()
        {
            return _context.Cliente.OrderBy(x => x.Nome).ToList();
        }
    }
}
