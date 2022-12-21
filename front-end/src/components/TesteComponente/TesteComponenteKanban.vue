<template>
  <div class="group-wrapper">
    <q-card-section class="q-pa-sm">
      <q-card class="q-pa-md">
        <div class="">
          <span class="text-h7">
            OrdemServico - {{ props.cardTag.ordemServicoId }}</span
          >
        </div>
        <div>
          <span class="text-h7">
            Descrição - {{ props.cardTag.descricao }}</span
          >
        </div>
        <div>
          <span class="text-h7"> Produto - {{ props.cardTag.produtoId }}</span>
        </div>
        <div>
          <span class="text-h7">
            OrdemProducao - {{ props.cardTag.ordemProducaoId }}</span
          >
        </div>
        <div>
          <span class="text-h7"> Status - {{ props.cardTag.situacao }}</span>
        </div>
      </q-card>
    </q-card-section>
  </div>
</template>
<script setup lang="ts">
import { EnumOrdemServicoSituacao, TodoOrdemServico } from 'src/types'

interface Props {
  status: EnumOrdemServicoSituacao
  title: string
  cardTag: TodoOrdemServico
}

const props = defineProps<Props>()

const updateTodo = (
  todo: TodoOrdemServico,
  newStatus: EnumOrdemServicoSituacao
) => {
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



</style>
