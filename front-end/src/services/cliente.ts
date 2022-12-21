import useApi from '../composables/UseApi'

export default function clienteService() {
  const { list, post, update, remove, getById } = useApi('cliente')

  const listCliente = list

  return {
    // list,
    listCliente,
    post,
    update,
    remove,
    getById,
  }
}
