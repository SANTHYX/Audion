const playlistRoutes = [
    {
        path: '/playlist/:id',
        name: 'Playlist',
        component: () => import('../views/Playlist.vue'),
        props: true
    },
];

export default playlistRoutes;