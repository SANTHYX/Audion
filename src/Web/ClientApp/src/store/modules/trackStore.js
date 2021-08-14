import trackService from '../../services/trackService'

const trackStore = {
    namespaced: true,

    state: {
        track: {},
        tracksCollection: {},
        error: {}
    },

    getters: {
        GET_TRACK: (state) => state.track,

        GET_TRACKS_COLLECTION: (state) => state.tracksCollection.collection
    },

    mutations: {
        SET_TRACK: (state, trackObj) => {
            state.track = trackObj;
        },

        SET_ERROR: (state, errorObj) => {
            state.error = errorObj
        },

        SET_TRACKS_COLLECTION: (state, tracksCollectionObj) => {
            state.tracksCollection = tracksCollectionObj;
        }
    },

    actions: {
        UPLOAD_TRACK: async ({ commit }, track) => {
            try {
                await trackService.uploadTrack(track);
            } catch (err) {
                console.error(err.response.data.Message);
                commit('SET_ERROR', err.response.data);
            }
        },

        GET_TRACK: async ({ commit }, title) => {
            try {
                const response = await trackService.getTrack(title);
                commit('SET_TRACK', response.data);
            } catch (err) {
                console.error(err.response.data.Message);
            }
        },

        BROWSE_TRACKS: async ({ commit }, tracksQuerry) => {
            try {
                const response = await trackService.browseTracks(tracksQuerry);
                commit('SET_TRACKS_COLLECTION', response.data);
            } catch (err) {
                console.error(err.response.data.Message);
            }
        }
    }
}

export default trackStore;