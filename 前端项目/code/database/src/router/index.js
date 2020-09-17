import Vue from 'vue'
import VueRouter from 'vue-router'
import Login from '../components/Login.vue'
import changepasswd from '../components/changepasswd.vue'
import forgetpasswd from '../components/forgetpasswd.vue'
import signUp from '../components/signUp.vue'
import operationManage from '../components/operationManage.vue'
import register from '../components/register.vue'
import operationList from '../components/operationList.vue'
import operationOrder from '../components/operationOrder.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    redirect: '/Login'
  },
  {
    path: '/Login',
    component: Login
  },
  {
    path: '/changepasswd',
    component: changepasswd
  },
  {
    path: '/forgetpasswd',
    component: forgetpasswd
  },
  {
    path: '/signUp',
    component: signUp
  },
  {
    path: '/operationManage',
    component: operationManage,
    redirect: '/operationList',
    children: [
      {
        path: '/operationList',
        component: operationList
      },
      {
        path: '/operationOrder',
        component: operationOrder
      }
    ]
  },
  {
    path: '/register',
    component: register
  }
]

const router = new VueRouter({
  routes
})

export default router
