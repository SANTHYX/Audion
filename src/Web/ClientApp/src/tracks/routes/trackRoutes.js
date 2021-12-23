const trackRoutes = [
    {
        path: '/track/:id',
        name: 'Track',
        component: () => import('../views/Track.vue'),
        props: true
    }
];

export default trackRoutes;