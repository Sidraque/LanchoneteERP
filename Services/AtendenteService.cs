using LanchoneteCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanchoneteCore.Services
{
    public class AtendenteService
    {
        private readonly LanchoneteCoreContext _context;

        public AtendenteService(LanchoneteCoreContext context)
        {
            _context = context;
        }

        public List<Atendente> FindAll()
        {
            return _context.Atendente.OrderBy(x => x.Nome).ToList();
        }
    }
}
