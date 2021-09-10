import Vue from 'vue'
import Vuex from 'vuex'
import identityStore from './modules/identityStore'
import profileStore from './modules/profileStore'
import userStore from './modules/userStore'
import trackStore from './modules/trackStore'
import playlistStore from './modules/playlistStore'

Vue.use(Vuex)

export default new Vuex.Store({
  modules: {
    identityStore,
    profileStore,
    userStore,
    trackStore,
    playlistStore
  }
})
