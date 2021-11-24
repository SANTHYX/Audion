const searchingRoutes = [
    {
        path: '/search',
        name: 'SearchResults',
        props: true,
        component: () => import('../../views/public/Search.vue'),
        children: [
            {
                path: '',
                name: 'DefaultBrowse',
                component: () => import('../../views/public/sub-routes/search/DefaultBrowse.vue')
            },
            {
                path: 'track',
                name: 'TracksBrowse',
                component: () => import('../../views/public/sub-routes/search/TrackBrowse.vue')
            },
            {
                path: 'playlist',
                name: 'PlaylistsBrowse',
                component: () => import('../../views/public/sub-routes/search/PlaylistBrowse.vue')
            },

        ],
        beforeEnter: (to, from, next) => {
            if (!Object.entries(to.query).length) {
                next('*');
                return;
            } else next();
        }
    },
]

export default searchingRoutes;