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
      <q-select
          filled
          v-model="selectionOrdemServico"
          multiple
          :options="optionsOrdemServico"
          use-chips
          stack-label
          label="Filtro"
          class="q-pa-sm col-4"
        />
      <h7>{{ selectionProduto }}</h7>

      <div class="groups-wrapper">
        <q-card class="q-mr-lg bg-indigo-1 q-pa-sm" flat>
          <div class="row q-pa-sm text-h6">EM PLANEJAMENTO</div>
          <KanbanGroup
            title="Planejamento"
            :status="statusA"
            :list="ordemServicoEmPlanejamento"
          />
          <div class="row justify-center q-pa-xs">
            <q-btn
              color="primary q-pa-md text-h6"
              :to="{ name: 'produto' }"
              dense
              flat
              icon="add"
              >adicionar</q-btn
            >
          </div>
        </q-card>

        <q-card class="q-mr-lg bg-indigo-1 q-pa-sm" flat>
          <div class="q-pa-sm text-h6">EM PRODUÇÂO</div>
          <KanbanGroup
            title="Em Producao"
            :status="statusB"
            :list="ordemServicoEmProducao"
          />
        </q-card>

        <q-card class="q-mr-lg bg-indigo-1 q-pa-sm" flat>
          <div class="q-pa-sm text-h6">FINALIZADO</div>
          <KanbanGroup
            title="Finalizado"
            :status="statusC"
            :list="ordemServicoFinalizado"
          />
        </q-card>
      </div>
    </div>
  </q-page>
</template>
<script setup lang="ts">
import { EnumOrdemServicoSituacao, TodoOrdemServico } from 'src/types'
import KanbanGroup from 'src/components/Kanban/KanbanGroup.vue'

import { ref, reactive, onMounted } from 'vue'
import clienteService from 'src/services/cliente'
import produtoService from 'src/services/produto'
import { QPage, QSelect, QCard, QBtn } from 'quasar'
import ordemProducaoService from 'src/services/ordemProducao'
import ordemServicoService from 'src/services/ordemServico'

const { listCliente } = clienteService()
const { listProduto } = produtoService()
const { listOrdemServico } = ordemServicoService()
const { listOrdemProducao } = ordemProducaoService()

const optionsCliente = ref()
const optionsProduto = ref()

const optionsOrdemServico = ref()


const selectionCliente = ref()
const selectionProduto = ref()

const selectionOrdemServico = ref()

const statusA = ref(EnumOrdemServicoSituacao.EM_PLANEJAMENTO)
const statusB = ref(EnumOrdemServicoSituacao.EM_PRODUCAO)
const statusC = ref(EnumOrdemServicoSituacao.FINALIZADO)

const ordemServicoEmPlanejamento = reactive<Array<TodoOrdemServico>>([])
const ordemServicoEmProducao = reactive<Array<TodoOrdemServico>>([])
const ordemServicoFinalizado = reactive<Array<TodoOrdemServico>>([])

// const clienteArray = reactive<Array<TodoCliente>>([])

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

    optionsOrdemServico.value = dataServico

    // Alimenta a Coluna Em Planejamento
    ordemServicoEmPlanejamento.splice(
      0,
      ordemProducaoService.length,
      ...dataServico.filter((result: any) => result.situacao === statusA.value)
    )

    // Alimenta a Coluna Em Producção
    ordemServicoEmProducao.splice(
      0,
      ordemProducaoService.length,
      ...dataServico.filter((result: any) => result.situacao === statusB.value)
    )

    // Alimenta a Coluna Finalizado
    ordemServicoEmProducao.splice(
      0,
      ordemProducaoService.length,
      ...dataServico.filter((result: any) => result.situacao === statusC.value)
    )

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
    console.log(ordemServicoEmPlanejamento)
    console.log(selectionProduto)
    // ordemServicoArray.value = data
  } catch (error) {
    console.log(error)
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
