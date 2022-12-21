<template>
  <q-page padding>
    <q-table title="Treats" :rows="posts" :columns="columns" row-key="name">
      <template v-slot:top>
        <q-btn color="primary" label="Add row" :to="{ name: 'formPost' }" />
      </template>
      <template v-slot:body-cell-actions="props">
        <q-td :props="props" class="q-gutter-sm">
          <q-btn
            icon="delete"
            color="negative"
            dense
            size="md"
            @click="handleDeletePost(props.row.id)"
          ></q-btn>

          <q-btn
            icon="edit"
            color="info"
            dense
            size="md"
            @click="handleEditPost(props.row.id)"
          ></q-btn>
        </q-td>
      </template>
    </q-table>
  </q-page>
</template>

<script setup lang="ts">
import { onMounted, ref } from 'vue'
import postsService from '../services/produto'
import { useQuasar } from 'quasar'
import { useRouter } from 'vue-router'

const $q = useQuasar()

const { list, remove } = postsService()

const posts = ref([])

const router = useRouter()

const getPosts = async () => {
  try {
    const data = await list()
    posts.value = data
  } catch (error) {
    console.log(error)
  }
}

const handleDeletePost = async (id: any) => {
  try {
    $q.dialog({
      title: 'Remover',
      message: 'Você deseja apagar este item?',
      cancel: true,
      persistent: true,
    }).onOk(async () => {
      await remove(id)
      $q.notify({
        message: 'Apagado com sucesso',
        icon: 'check',
        color: 'positive',
      })
      await getPosts()
    })
  } catch (error) {
    $q.notify({
      message: 'Error ao apagar',
      icon: 'times',
      color: 'negative',
    })
  }
}

const handleEditPost = (id: any) => {
  router.push({ name: 'formPost', params: { id } })
}

const columns = [
  {
    name: 'formularioId',
    field: 'formularioId',
    label: 'Id',
    sortable: true,
  },
  {
    name: 'title',
    field: 'title',
    label: 'Titulo',
    sortable: true,
  },
  {
    name: 'author',
    field: 'author',
    label: 'Autor',
    sortable: true,
  },
]

onMounted(() => {
  getPosts()
})
</script>
