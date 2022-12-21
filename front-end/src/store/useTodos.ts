import { Todo } from 'src/components/models'
import { TodoStatus } from 'src/types/types'
import { computed, reactive } from 'vue'

interface TodoStore {
  [TodoStatus.Pendente]: Todo[]
  [TodoStatus.EmProgresso]: Todo[]
  [TodoStatus.Completo]: Todo[]
}


const defautVal = <any>{
  [TodoStatus.Pendente]: [
    {
      id: 1,
      title: 'Aprenda VueJs',
      description: 'Aprenda a codar com Vue',
      status: TodoStatus.Pendente,
    },
  ],
  [TodoStatus.EmProgresso]: [],
  [TodoStatus.Completo]: [],
}

const todoStore = reactive<TodoStore>(defautVal)

export default () => {
  const getTodoByStatus = (TodoStatus: TodoStatus) => {
    return computed(() => todoStore[TodoStatus])
  }

  const updateTodo = (todo: Todo, newStatus: TodoStatus) => {
    todo.status = newStatus
  }

  const addNewTodo = (todo: Todo) => {
    todoStore[todo.status].push(todo)
  }

  const deleteTodo = (todoDelete: Todo) => {
    todoStore[todoDelete.status] = todoStore[todoDelete.status].filter(
      (todo) => todo.id !== todoDelete.id
    )
  }

  return {
    getTodoByStatus,
    addNewTodo,
    deleteTodo,
    updateTodo,
  }
}
