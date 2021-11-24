import api from '../../commons/plugins/axios'

const playlistService = {
    createPlaylist: async (playlistModel) => {
        await api.post('/playlists', playlistModel);
    },

    updatePlaylist: async (playlistModel) => {
        await api.put('/playlists', playlistModel);
    },

    deletePlaylist: async (playlistModel) => {
        await api.delete('/playlists', playlistModel);
    },

    getPlaylist: async (id) => {
        const response = await api.get(`/playlists/${id}`);

        return response;
    },

    browsePlaylists: async (playlistQuery) => {
        const response = await api.get('/playlists', { params: { ...playlistQuery } });

        return response;
    }
}

export default playlistService;