import Vue from 'vue'
import Router from 'vue-router';
import Register from "./components/Register.vue";
import Peoples from "./components/Peoples.vue";
import Update from "./components/Update.vue";

Vue.use(Router);

export default new Router({
    routes: [{
        path: '/',
        name: 'Peoples',
        component: Peoples
    },
    {
        path: '/Register',
        name: 'Register',
        component: Register
    },
    {
        path: '/Update/:id',
        name: 'Update',
        component: Update
    },

    {
        path: '/Peoples',
        name: 'Peoples',
        component: Peoples
    }
]
})