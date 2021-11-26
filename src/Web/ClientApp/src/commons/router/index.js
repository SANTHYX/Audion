import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/public/Home.vue'
import identityRoutes from '../../identity/routes/identityRoutes'
import userRoutes from '../../users/routes/userRoutes'
import trackRoutes from '../../tracks/routes/trackRoutes'
import playlistRoutes from '../../playlists/routes/playlistRoutes'
import identityStore from '../../identity/store/identityStore'
import searchingRoutes from './modules/searchingRoutes'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  ...searchingRoutes,
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
    } else next('*');
  } else next();
});

export default router;