/* eslint-disable no-use-before-define */

export enum EnumOrdemServicoSituacao {
  EM_PLANEJAMENTO = 1,
  EM_PRODUCAO = 2,
  FINALIZADO = 3,
}

export enum EnumOrdemProducaoSituacao {
  EM_PLANEJAMENTO = 1,
  EM_PRODUCAO = 2,
  FINALIZADO = 3,
}

export interface TodoCliente {
  clienteId: number
  descricao: string
}

export interface TodoProduto {
  produtoId: number
  descricao: string
  quantidade: number
}

export interface TodoOrdemProducao {
  ordemProducaoId: number
  descricao: string
  clienteId: number
  produtoId: number
  situacao: EnumOrdemProducaoSituacao
}

export interface TodoOrdemServico {
  ordemServicoId: number
  descricao: string
  produtoId: number
  ordemProducaoId: number
  situacao: EnumOrdemServicoSituacao
  ordemproducao: TodoOrdemProducao
}
