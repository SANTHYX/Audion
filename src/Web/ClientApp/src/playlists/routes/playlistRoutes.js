const playlistRoutes = [
    {
        path: 'playlist/:id',
        name: 'Playlist',
        component: () => import('../views/Playlist.vue'),
        prop: true
    },
];

export default playlistRoutes;