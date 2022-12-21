using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using back_end.Models.enums;

namespace back_end.Models
{
    public class OrdemProducao
    {
        [Key]
        public int OrdemProducaoId { get; set; }
        public string Descricao { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }


        public EnumOrdemProducaoSituacao Situacao { get; set; }

        public ICollection<OrdemServico> OrdemServicos { get; set; }

    }
}