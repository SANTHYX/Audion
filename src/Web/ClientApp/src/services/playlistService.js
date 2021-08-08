import api from '../plugins/axios'

const playlistService = {
    createPlaylist: async (playlistModel) => {
        try {
            await api.post('/playlists', playlistModel);
        } catch (err) {
            console.error(err.message)
        }
    },

    updatePlaylist: async (playlistModel) => {
        try {
            await api.put('/playlists', playlistModel);
        } catch (err) {
            console.error(err);
        }
    },

    deletePlaylist: async (playlistModel) => {
        try {
            await api.delete('/playlists', playlistModel);
        } catch (err) {
            console.error(err.message);
        }
    },

    getPlaylist: async (id) => {
        try {
            const response = await api.get(`/playlists/${id}`);

            return response;
        } catch (err) {
            console.error(err.message)
        }
    },

    browsePlaylists: async (playlistQuery) => {
        try {
            const response = await api.get('/playlists', { params: { ...playlistQuery } });

            return response;
        } catch (err) {
            console.error(err.message)
        }
    }
}

export default playlistService;