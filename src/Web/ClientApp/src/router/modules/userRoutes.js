const userRoutes = [
    {
        path: '/user/:userName',
        component: () => import('@/views/auth/User.vue'),
        props: true,
        children: [
            {
                path: '',
                name: 'UserOverview',
                props: true,
                component: () => import('../../views/auth/user/UserOverview.vue')
            },
            {
                path: 'profile',
                name: 'EditProfile',
                component: () => import('../../views/auth/user/ProfileForm.vue')
            },
            {
                path: 'creedentials',
                name: 'EditCreedentials',
                component: () => import('../../views/auth/user/CredentialsForm.vue')
            }
        ]
    },
];

export default userRoutes;