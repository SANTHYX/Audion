const playlistRoutes = [
    {
        path: 'search/playlist',
        name: 'BrowsePlaylists',
        component: () => import('../views/BrowsePlaylists.vue')
    }
];

export default playlistRoutes;