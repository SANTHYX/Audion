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
            {
                path: 'playlists',
                name: 'ManagePlaylists',
                component: () => import('../../playlists/views/sub-routes/ManagePlaylists.vue'),
            },
            {
                path: 'tracks',
                name: 'ManageTracks',
                component: () => import('../../tracks/views/sub-route/ManageTracks.vue')
            },
        ],
        meta: { requiresAuth: true }
    },
    {
        path: '/account/playlists/create',
        name: 'MakePlaylist',
        component: () => import('../../playlists/views/sub-routes/MakePlaylist.vue')
    },
]

export default userRoutes;