import { api } from 'boot/axios'

export default function useApi(url: any) {
  const list = async () => {
    try {
      const { data } = await api.get(url)
      return data
    } catch (error) {
      throw new Error()
    }
  }

  const getById = async (id: any) => {
    try {
      const { data } = await api.get(`${url}/${id}`)
      return data
    } catch (error) {
      throw new Error()
    }
  }

  const post = async (form: any) => {
    try {
      const { data } = await api.post(url, form) // Passa a url eo os valores
      return data
    } catch (error) {
      throw new Error()
    }
  }

  const update = async (form: any) => {
    try {
      const { data } = await api.put(`${url}/${form.id}`, form) // Passa a url e o id eo os valores
      return data
    } catch (error) {
      throw new Error()
    }
  }

  const remove = async (id: any) => {
    try {
      const { data } = await api.delete(`${url}/${id}`) // Passa a url e o id eo os valores
      return data
    } catch (error) {
      throw new Error()
    }
  }
  return {
    list,
    post,
    update,
    remove,
    getById,
  }
}
