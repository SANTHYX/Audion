const identityRoutes = [
    {
        path: '/login',
        name: 'Login',
        component: () => import(/* webpackChunkName: "login" */ '../../views/Login.vue')
    },

    {
        path: '/register',
        name: 'Register',
        component: () => import(/* webpackChunkName: "register" */ '../../views/Register.vue')
    }
];

export default identityRoutes;