import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '@/views/public/Home.vue'
import identityRoutes from './modules/identityRoutes'
import userRoutes from './modules/userRoutes'
import trackRoutes from './modules/trackRoutes'
import playlistRoutes from './modules/playlistRoutes'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  ...identityRoutes,
  ...userRoutes,
  ...trackRoutes,
  ...playlistRoutes,
  {
    path: '*',
    redirect: {
      name: 'Home'
    }
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
