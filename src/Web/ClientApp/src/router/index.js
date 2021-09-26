import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '@/views/public/Home.vue'
import identityRoutes from './modules/identityRoutes'
import userRoutes from './modules/userRoutes'
import trackRoutes from './modules/trackRoutes'
import playlistRoutes from './modules/playlistRoutes'
import identityStore from '../store/modules/identityStore'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/search',
    name: 'SearchResults',
    props: true,
    component: () => import('@/views/public/SearchResults.vue'),
    beforeEnter: (to, from, next) => {
      if (!Object.entries(to.query).length) {
        next('*');
        return;
      } else next();
    }
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

router.beforeEach((to, from, next) => {
  if (to.matched.some(record => record.meta.requiresAuth)) {
    if (identityStore.getters.isAuthenticated(identityStore.state)) {
      next();
      return;
    } else {
      next('*');
    }
  } else {
    next();
  }
});

export default router;
