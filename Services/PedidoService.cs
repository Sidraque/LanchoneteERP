using LanchoneteCore.Models;
using LanchoneteCore.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanchoneteCore.Services
{
    public class PedidoService
    {
        private readonly LanchoneteCoreContext _context;

        public PedidoService(LanchoneteCoreContext context)
        {
            _context = context;
        }

       


    }
}
