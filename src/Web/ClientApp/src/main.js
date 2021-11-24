import Vue from 'vue'
import App from './App.vue'
import router from './commons/router'
import store from './commons/store/index'
import vuetify from './commons/plugins/vuetify'

Vue.config.productionTip = false

new Vue({
  router,
  store,
  vuetify,
  render: h => h(App)
}).$mount('#app')
