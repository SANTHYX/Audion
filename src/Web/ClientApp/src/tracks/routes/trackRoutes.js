const trackRoutes = [
    {
        path: '/search/track',
        name: 'BrowseTracks',
        component: () => import('../views/BrowseTracks.vue')
    },
    {
        path: '/track/:id',
        name: 'Track',
        component: () => import('../views/Track.vue'),
        props: true
    }
];

export default trackRoutes;