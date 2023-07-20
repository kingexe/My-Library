import { createRouter, createWebHistory } from 'vue-router'
import AddBookView from '../components/AddBook/AddBookView.vue'
import ListBookView from '../components/ListBook/ListBookView.vue'
import EditBook from '../components/EditBook/EditBook.vue'


const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [

   
    {
      path: '/EditBook/:id',
      name: 'EditBook',
      component: EditBook
    },
    {
      path: '/AddBook',
      name: 'AddBookView',
      component: AddBookView
    },
    {
      path: '/ListBook',
      name: 'ListBookView',
      component: ListBookView
    }
  ]
})

export default router
