import playlistService from '../../services/playlistService'

const playlistStore = {
    namespaced: true,

    state: {
        playlist: {},
        playlistsCollection: {}
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
                console.error(err.message);
            }
        },

        UPDATE_PLAYLIST: async (playlistObj) => {
            try {
                await playlistService.updatePlaylist(playlistObj);
            } catch (err) {
                console.error(err.message);
            }
        },

        DELETE_PLAYLIST: async (playlistObj) => {
            try {
                await playlistService.deletePlaylist(playlistObj);
            } catch (err) {
                console.error(err.message);
            }
        },

        GET_PLAYLIST: async ({ commit }, id) => {
            try {
                const response = await playlistService.getPlaylist(id);
                commit('SET_PLAYLIST', response.data);
            } catch (err) {
                console.error(err.message);
            }
        },

        BROWSE_PLAYLISTS: async ({ commit }, playlistsQuerry) => {
            try {
                const response = await playlistService.browsePlaylists(playlistsQuerry);
                commit('SET_PLAYLISTS_COLLECTION', response.data);
            } catch (err) {
                console.error(err);
            }
        }
    }
}

export default playlistStore;