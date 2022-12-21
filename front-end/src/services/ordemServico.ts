import useApi from '../composables/UseApi'

export default function ordemServicoService() {
  const { list, post, update, remove, getById } = useApi('ordemServico')

  const listOrdemServico = list

  return {
    // list,
    listOrdemServico,
    post,
    update,
    remove,
    getById,
  }
}
