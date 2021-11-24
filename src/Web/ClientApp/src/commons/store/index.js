import Vue from 'vue'
import Vuex from 'vuex'
import identityStore from '../../identity/store/identityStore'
import profileStore from '../../users/store/profileStore'
import userStore from '../../users/store/userStore'
import trackStore from '../../tracks/store/trackStore'
import playlistStore from '../../playlists/store/playlistStore'

Vue.use(Vuex)

export default new Vuex.Store({
  modules: {
    'identity': identityStore,
    'profile': profileStore,
    'user': userStore,
    'track': trackStore,
    'playlist': playlistStore
  }
})
