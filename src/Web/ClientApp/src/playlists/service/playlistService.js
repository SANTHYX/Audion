import api from '../../commons/plugins/axios'

const playlistService = {
    createPlaylist: async (playlistModel) => {
        await api.post('/playlists', playlistModel);
    },

    updatePlaylist: async (playlistModel) => {
        await api.put('/playlists', playlistModel);
    },

    deletePlaylist: async (id) => {
        await api.delete(`playlists/${id}`);
    },

    getPlaylist: async (id) => {
        const response = await api.get(`/playlists/${id}`);

        return response;
    },

    browsePlaylists: async (playlistQuery) => {
        const response = await api.get('/playlists', { params: { ...playlistQuery } });

        return response;
    },

    browseUserPlaylists: async (browseQuery) => {
        const response = await api.get('/playlists/user', { params: { ...browseQuery } });

        return response;
    }
}

export default playlistService;