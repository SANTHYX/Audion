const userRoutes = [
    {
        path: '/user/:userName',
        name: 'User',
        component: () => import('../views/User.vue'),
        props: true
    },
    {
        path: '/account',
        component: () => import('../views/account/Account.vue'),
        children: [
            {
                path: '',
                name: 'UserOverview',
                component: () => import('../views/account/UserOverview.vue'),
                props: true,
            },
            {
                path: 'profile',
                name: 'EditProfile',
                component: () => import('../views/account/ProfileForm.vue'),
                props: true,
            },
            {
                path: 'creedentials',
                name: 'EditCreedentials',
                component: () => import('../views/account/CredentialsForm.vue'),
                props: true,
            },

        ],
        meta: { requiresAuth: true }
    }
]

export default userRoutes;