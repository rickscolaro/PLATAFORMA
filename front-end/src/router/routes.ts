import { RouteRecordRaw } from 'vue-router'

const routes: RouteRecordRaw[] = [
  {
    path: '/',
    component: () => import('layouts/MainLayout.vue'),
    children: [
      {
        path: '',
        name: 'home',
        component: () => import('pages/IndexPage.vue'),
      },
      {
        path: 'form-post/:id?',
        name: 'formPost',
        component: () => import('pages/FormPost.vue'),
      },
      {
        path: 'kanban-list/:id?',
        name: 'kanbanList',
        component: () => import('pages/Kanban/KanbanPage.vue'),
      },
      {
        path: 'produto/:id?',
        name: 'produto',
        component: () => import('pages/Produto/ProdutoPage.vue'),
      },

      {
        path: 'teste',
        name: 'teste',
        component: () => import('pages/Teste/TestePage.vue'),
      },
    ],
  },

  // Always leave this as last one,
  // but you can also remove it
  {
    path: '/:catchAll(.*)*',
    component: () => import('pages/ErrorNotFound.vue'),
  },
]

export default routes
