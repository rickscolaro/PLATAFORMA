using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using back_end.Models.enums;

namespace back_end.Models
{
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }

        public ICollection<OrdemServico> OrdemServicos { get; set; }
        public ICollection<OrdemProducao> OrdemProducoes { get; set; }

    }
}