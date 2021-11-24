import playlistService from '../service/playlistService'

const playlistStore = {
    namespaced: true,

    state: {
        playlist: {},
        playlistsCollection: {},
    },

    getters: {
        GET_PLAYLIST: (state) => state.playlist,

        GET_PLAYLISTS_COLLECTION: (state) => state.playlistsCollection.collection,
    },

    mutations: {
        SET_PLAYLIST: (state, playlistObj) => {
            state.playlist = playlistObj
        },

        SET_PLAYLISTS_COLLECTION: (state, playlistsCollectionObj) => {
            state.playlistsCollection = playlistsCollectionObj
        },

        REMOVE_PLAYLIST: (state) => {
            state.playlist = {}
        },

        REMOVE_PLAYLISTS_COLLECTION: (state) => {
            state.playlistsCollection = {}
        }
    },

    actions: {
        CREATE_PLAYLIST: async (context, playlistObj) => {
            try {
                await playlistService.createPlaylist(playlistObj);
            } catch (err) {
                throw new Error(err.response.data.Message);
            }
        },

        UPDATE_PLAYLIST: async (context, playlistObj) => {
            try {
                await playlistService.updatePlaylist(playlistObj);
            } catch (err) {
                throw new Error(err.response.data.Message);
            }
        },

        DELETE_PLAYLIST: async (context, playlistObj) => {
            try {
                await playlistService.deletePlaylist(playlistObj);
            } catch (err) {
                throw new Error(err.response.data.Message);
            }
        },

        GET_PLAYLIST: async (context, id) => {
            try {
                const response = await playlistService.getPlaylist(id);
                context.commit('SET_PLAYLIST', response.data);
            } catch (err) {
                throw new Error(err.response.data.Message);
            }
        },

        BROWSE_PLAYLISTS: async (context, playlistsQuerry) => {
            try {
                const response = await playlistService.browsePlaylists(playlistsQuerry);
                context.commit('SET_PLAYLISTS_COLLECTION', response.data);
            } catch (err) {
                throw new Error(err.response.data.Message);
            }
        }
    }
}

export default playlistStore;