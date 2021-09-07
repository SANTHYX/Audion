const identityRoutes = [
    {
        path: '/login',
        name: 'Login',
        component: () => import(/* webpackChunkName: "login" */ '@/views/Login.vue')
    },
    {
        path: '/register',
        name: 'Register',
        component: () => import(/* webpackChunkName: "register" */ '@/views/Register.vue')
    },
    {
        path: '/account',
        component: () => import('@/views/auth/Account.vue'),
        children: [
            {
                path: '',
                name: 'UserOverview',
                component: () => import('@/views/auth/account/UserOverview.vue')
            },
            {
                path: 'profile',
                name: 'EditProfile',
                component: () => import('@/views/auth/account/ProfileForm.vue')
            },
            {
                path: 'creedentials',
                name: 'EditCreedentials',
                component: () => import('@/views/auth/account/CredentialsForm.vue')
            }
        ]
    },
];

export default identityRoutes;