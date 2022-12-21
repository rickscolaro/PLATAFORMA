<template>
  <div class="xxx">
    <q-card class="q-mr-lg bg-indigo-1 q-pa-sm" flat >
      <div class="q-pa-sm text-h6" style="width:350px">{{ props.title }}</div>
      <Draggable
        class="draggable"
        :list="props.list"
        group="cards"
        item-key="ordemServicoId"
      >
        <template #item="{ element }">
          <TesteComponenteKanban
            title="Planejamento"
            :status="props.status"
            :list="props.list"
            :card-tag="element"
          />
        </template>
      </Draggable>
    </q-card>
  </div>
</template>
<script setup lang="ts">
import { EnumOrdemServicoSituacao } from 'src/types'
import Draggable from 'vuedraggable'
import TesteComponenteKanban from '../TesteComponente/TesteComponenteKanban.vue'

interface Props {
  status: EnumOrdemServicoSituacao
  list: any[]
  title: string
}

const props = defineProps<Props>()
</script>
<style>
.draggable {
  min-height: 200px;
}
</style>
