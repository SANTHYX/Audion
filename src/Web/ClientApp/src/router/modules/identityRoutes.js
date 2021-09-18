const identityRoutes = [
    {
        path: '/login',
        name: 'Login',
        component: () => import(/* webpackChunkName: "login" */ '@/views/public/Login.vue')
    },
    {
        path: '/register',
        name: 'Register',
        component: () => import(/* webpackChunkName: "register" */ '@/views/public/Register.vue')
    },
    {
        path: '/account',
        component: () => import('@/views/auth/Account.vue'),
        children: [
            {
                path: '',
                name: 'UserOverview',
                component: () => import('@/views/auth/account/UserOverview.vue'),
                props: true,
            },
            {
                path: 'profile',
                name: 'EditProfile',
                component: () => import('@/views/auth/account/ProfileForm.vue'),
                props: true,
            },
            {
                path: 'creedentials',
                name: 'EditCreedentials',
                component: () => import('@/views/auth/account/CredentialsForm.vue'),
                props: true,
            }
        ],
        meta: { requiresAuth: true },
    },
];

export default identityRoutes;