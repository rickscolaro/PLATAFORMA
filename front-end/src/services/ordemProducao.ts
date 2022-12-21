import useApi from '../composables/UseApi'

export default function ordemProducaoService() {
  const { list, post, update, remove, getById } = useApi('ordemProducao')

  const listOrdemProducao = list

  return {
    // list,
    listOrdemProducao,
    post,
    update,
    remove,
    getById,
  }
}
