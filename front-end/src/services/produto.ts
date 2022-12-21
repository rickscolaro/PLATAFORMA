import useApi from '../composables/UseApi'

export default function produtoService() {
  const { list, post, update, remove, getById } = useApi('produto')

  const listProduto = list

  return {
    // list,
    listProduto,
    post,
    update,
    remove,
    getById,
  }
}
