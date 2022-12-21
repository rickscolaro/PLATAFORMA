<template>
  <q-page class="q-pa-lg">
    <div class="row col-12">
      <q-select
        outlined
        v-model="selectionCliente"
        :options="optionsCliente"
        label="Cliente"
        class="q-pa-sm col-4"
        option-label="descricao"
        option-value="clienteId"
      />

      <q-select
        outlined
        v-model="selectionProduto"
        :options="optionsProduto"
        label="Produção"
        class="q-pa-sm col-4"
        option-label="descricao"
        option-value="produtoId"
      />

      <div class="groups-wrapper">


        <CardTeste :list="ordemServicoArray" :status="statusA" title="EM PLANEJAMENTO"/>
        <CardTeste :list="ordemServicoEmProducao" :status="statusB" title="EM PRODUÇÂO" />
        <CardTeste :list="ordemServicoFinalizado" :status="statusC" title="FINALIZADO"/>

        <!-- <q-card class="q-mr-lg bg-indigo-1 q-pa-sm" flat>
          <div class="q-pa-sm text-h6">EM PRODUÇÂO</div>
          <Draggable
            class="draggable"
            :list="ordemServicoEmProducao"
            group="cards"
            item-key="ordemServicoId"
            @change="onDraggableChange"
          >
            <template #item="{ element }">
              <TesteComponenteKanban
                title="Planejamento"
                :status="statusA"
                :card-tag="element"
              />
            </template>
          </Draggable>
        </q-card>

      -->


      </div>
    </div>
  </q-page>
</template>
<script setup lang="ts">
import {
  TodoCliente,
  EnumOrdemServicoSituacao,
  TodoOrdemServico,
  TodoProduto,
} from 'src/types'
import KanbanGroup from 'src/components/Kanban/KanbanGroup.vue'

import { ref, reactive, onMounted, onUpdated } from 'vue'
import clienteService from 'src/services/cliente'
import produtoService from 'src/services/produto'
import { QPage, QSelect, QCard, QCardSection } from 'quasar'
import ordemProducaoService from 'src/services/ordemProducao'
import ordemServicoService from 'src/services/ordemServico'

import Draggable from 'vuedraggable'
import CardTeste from 'src/components/TesteComponente/CardTeste.vue'

const { listCliente } = clienteService()
const { listProduto } = produtoService()
const { listOrdemServico } = ordemServicoService()
const { listOrdemProducao } = ordemProducaoService()

const optionsCliente = ref()
const optionsProduto = ref()
const selectionCliente = ref()
const selectionProduto = ref()

const statusA = ref(EnumOrdemServicoSituacao.EM_PLANEJAMENTO)
const statusB = ref(EnumOrdemServicoSituacao.EM_PRODUCAO)
const statusC = ref(EnumOrdemServicoSituacao.FINALIZADO)

const ordemServicoArray = reactive<Array<TodoOrdemServico>>([])
const ordemServicoEmProducao = reactive<Array<TodoOrdemServico>>([])
const ordemServicoFinalizado = reactive<Array<TodoOrdemServico>>([])

const clienteArray = reactive<Array<TodoCliente>>([])

const getCliente = async () => {
  // debugger
  const data = await listCliente()
  optionsCliente.value = data

  // clienteArray.push(selection.value)

  // console.log(clienteArray)
}

const getProduto = async () => {
  // debugger
  const data = await listProduto()
  optionsProduto.value = data

  // clienteArray.push(selection.value)

  // console.log(clienteArray)
}

const getOrdemServico = async () => {
  try {
    // debugger

    const dataServico = await listOrdemServico()

    const dataProducao = await listOrdemProducao()

    // ordemServicoArray

    ordemServicoArray.splice(0, ordemProducaoService.length, ...dataServico)

    // ordemServicoArray.splice(
    //   0,
    //   ordemServicoArray.length,
    //   ...dataServico.filter(
    //     (result: any) =>
    //       result.situacao === statusA.value || statusB.value || statusC.value
    //     // &&
    //     // result.ordemProducao.filter((x: any) => x.clienteId) ===
    //     //   props.filter.clienteId
    //   )
    // )
    console.log(ordemServicoArray)
    console.log(selectionProduto)
    // ordemServicoArray.value = data
  } catch (error) {
    console.log(error)
  }
}

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
    updateTodo(payload?.added?.element, statusA.value)
  }
}



onMounted(() => {
  getCliente()
  getProduto()

  getOrdemServico()
})

// onUpdated(() => {
//   getOrdemServico()
// })
</script>
<style>
.groups-wrapper {
  display: flex;
}

</style>
