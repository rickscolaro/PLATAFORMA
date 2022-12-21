using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using back_end.Models.enums;

namespace back_end.Models
{
    public class OrdemServico
    {
        [Key]
        public int OrdemServicoId { get; set; }
        public string Descricao { get; set; }

        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }


        public EnumOrdemServicoSituacao Situacao { get; set; }

        public int OrdemProducaoId { get; set; }
        public OrdemProducao OrdemProducao { get; set; }


    }
}