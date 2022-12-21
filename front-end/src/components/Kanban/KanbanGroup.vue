<template>
  <div class="group-wrapper mamaco">
    <Draggable
      class="draggable mamaco"
      :list="props.list"
      group="todos"
      item-key="ordemServicoId"
      @change="onDraggableChange"
    >
      <template #item="{ element: todo }">
        <q-card-section class="q-pa-sm">
          <q-card class="q-pa-md">
            <div>
              <card> OrdemServico - {{ todo.ordemServicoId }}</card>
            </div>
            <div>
              <span> Descrição - {{ todo.descricao }}</span>
            </div>
            <div>
              <span> Produto - {{ todo.produtoId }}</span>
            </div>
            <div>
              <span> OrdemProducao - {{ todo.ordemProducaoId }}</span>
            </div>
            <div>
              <span> Status - {{ todo.situacao }}</span>
            </div>
          </q-card>
        </q-card-section>
      </template>
    </Draggable>
  </div>
</template>
<script setup lang="ts">
import Draggable from 'vuedraggable'

interface Props {
  status: any
  title: string
  list: any[]
}

const props = defineProps<Props>()

const updateTodo = (todo: any, newStatus: any) => {
  // debugger
  // console.log(props.title)
  todo.situacao = newStatus
}

const onDraggableChange = (payload: any) => {
  // console.log(props.title)
  if (payload?.added?.element) {
    // update todo status
    updateTodo(payload?.added?.element, props.status)
  }
}

// const getOrdemServico = async () => {
//   try {
//     // debugger

//     const dataServico = await listOrdemServico()

//     const dataProducao = await listOrdemProducao()

//     ordemServicoArray.splice(
//       0,
//       ordemServicoArray.length,
//       ...dataServico.filter(
//         (result: any) =>
//           result.situacao === props.status &&
//           result.ordemProducao.filter((x: any) => x.clienteId) ===
//             props.filter.clienteId
//       )
//     )
//     // ordemServicoArray.value = data
//   } catch (error) {
//     console.log(error)
//   }
// }

// onUpdated(() => {
//   getOrdemServico()
// })

// onMounted(() => {
//   getOrdemServico()
// })
</script>

<style scoped>
.group-wrapper {
  width: 350px;
}

.draggable {
  min-height: 500px;
}

.mamaco {
  height: calc(100% - 20px);
}
</style>
