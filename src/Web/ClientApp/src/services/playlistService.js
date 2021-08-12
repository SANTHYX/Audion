import api from '../plugins/axios'

const playlistService = {
    createPlaylist: async (playlistModel) => {
        try {
            await api.post('/playlists', playlistModel);
        } catch (err) {
            console.error(err.response.data)
        }
    },

    updatePlaylist: async (playlistModel) => {
        try {
            await api.put('/playlists', playlistModel);
        } catch (err) {
            console.error(err.response.data);
        }
    },

    deletePlaylist: async (playlistModel) => {
        try {
            await api.delete('/playlists', playlistModel);
        } catch (err) {
            console.error(err.response.data);
        }
    },

    getPlaylist: async (id) => {
        try {
            const response = await api.get(`/playlists/${id}`);

            return response;
        } catch (err) {
            console.error(err.response.data);
        }
    },

    browsePlaylists: async (playlistQuery) => {
        try {
            const response = await api.get('/playlists', {
                params: { ...playlistQuery }
            });

            return response;
        } catch (err) {
            console.error(err.response.data)
        }
    }
}

export default playlistService;