import Vue from 'vue'
import Vuex from 'vuex'
import identityStore from './modules/identityStore'

Vue.use(Vuex)

export default new Vuex.Store({
  modules: {
    identityStore
  }
})
