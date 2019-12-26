import Vue from 'vue'
import App from './App.vue'
import 'bootstrap'; 
import 'bootstrap/dist/css/bootstrap.min.css';
import axios from 'axios'
import VueAxios from 'vue-axios'
import router from './router'
import { library } from '@fortawesome/fontawesome-svg-core'
import { faUser, faEnvelope, faPhone, faBriefcase, faHeart } from '@fortawesome/free-solid-svg-icons'
import { faVuejs } from '@fortawesome/free-brands-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import { VueMaskDirective } from "v-mask";
Vue.directive("mask", VueMaskDirective);


library.add(faUser, faEnvelope, faPhone, faBriefcase, faHeart, faVuejs)

Vue.component('font-awesome-icon', FontAwesomeIcon)

Vue.config.productionTip = false

Vue.use(VueAxios, axios)

new Vue({
  router,
  render: h => h(App),
}).$mount('#app')
