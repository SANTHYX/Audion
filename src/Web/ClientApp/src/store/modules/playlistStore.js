import playlistService from '../../services/playlistService'

const playlistStore = {
    namespaced: true,

    state: {
        playlist: {},
        playlistsCollection: {},
    },

    getters: {
        GET_PLAYLIST: (state) => state.playlist,

        GET_PLAYLIST_COLLECTION: (state) => state.playlistsCollection.collection,
    },

    mutations: {
        SET_PLAYLIST: (state, playlistObj) => {
            state.playlist = playlistObj
        },

        SET_PLAYLISTS_COLLECTION: (state, playlistsCollectionObj) => {
            state.playlistsCollection = playlistsCollectionObj
        }
    },

    actions: {
        CREATE_PLAYLIST: async (playlistObj) => {
            try {
                await playlistService.createPlaylist(playlistObj);
            } catch (err) {
                throw new Error(err.response.data.Message);
            }
        },

        UPDATE_PLAYLIST: async (playlistObj) => {
            try {
                await playlistService.updatePlaylist(playlistObj);
            } catch (err) {
                throw new Error(err.response.data.Message);
            }
        },

        DELETE_PLAYLIST: async (playlistObj) => {
            try {
                await playlistService.deletePlaylist(playlistObj);
            } catch (err) {
                throw new Error(err.response.data.Message);
            }
        },

        GET_PLAYLIST: async ({ commit }, id) => {
            try {
                const response = await playlistService.getPlaylist(id);
                commit('SET_PLAYLIST', response.data);
            } catch (err) {
                throw new Error(err.response.data.Message);
            }
        },

        BROWSE_PLAYLISTS: async ({ commit }, playlistsQuerry) => {
            try {
                const response = await playlistService.browsePlaylists(playlistsQuerry);
                commit('SET_PLAYLISTS_COLLECTION', response.data);
            } catch (err) {
                throw new Error(err.response.data.Message);
            }
        }
    }
}

export default playlistStore;