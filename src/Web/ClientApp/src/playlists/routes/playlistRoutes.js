const playlistRoutes = [
    {
        path: 'search/playlist',
        name: 'BrowsePlaylists',
        component: () => import('../views/BrowsePlaylists.vue')
    },
    {
        path: 'playlist/:id',
        name: 'Playlist',
        component: () => import('../views/Playlist.vue'),
        prop: true
    }
];

export default playlistRoutes;