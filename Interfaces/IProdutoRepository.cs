using LanchoneteCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanchoneteCore.Interfaces
{
    public interface IProdutoRepository
    {
        IEnumerable<Produto> produtos { get; }
        //IEnumerable<Lanche> LanchesPreferidos { get; }
        //Lanche GetLancheById(int lancheId);
    }
}


