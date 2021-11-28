const identityRoutes = [
    {
        path: '/login',
        name: 'Login',
        component: () => import(/* webpackChunkName: "login" */ '../views/Login.vue')
    },
    {
        path: '/register',
        name: 'Register',
        component: () => import(/* webpackChunkName: "register" */ '../views/Register.vue')
    },
    {
        path: '/recovery-password',
        name: 'RecoveryPassword',
        component: () => import(/* webpackChunkName: "recovery-password" */ '../views/RecoveryPassword.vue')
    },
    {
        path: '/recovery-password/:recoveryId',
        name: 'ChangePasswordAtRecovery',
        component: () => import(/* webpackChunkName: "change-password-at-recovery" */ '../views/ChangePasswordAtRecovery.vue'),
        props: true
    }
];

export default identityRoutes;