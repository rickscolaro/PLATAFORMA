using System.ComponentModel;

namespace back_end.Models.enums
{
    public enum EnumOrdemServicoSituacao
    {

        [Description("Em Planejamento")]
        EM_PLANEJAMENTO = 1,

        [Description("Em Produção")]
        EM_PRODUCAO = 2,

        [Description("Finalizado")]
        FINALIZADO = 3,
    }
}