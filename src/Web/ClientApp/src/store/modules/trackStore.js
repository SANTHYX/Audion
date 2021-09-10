import trackService from '../../services/trackService'

const trackStore = {
    namespaced: true,

    state: {
        track: {},
        tracksCollection: {},
    },

    getters: {
        GET_TRACK: (state) => state.track,

        GET_TRACKS_COLLECTION: (state) => state.tracksCollection.collection
    },

    mutations: {
        SET_TRACK: (state, trackObj) => {
            state.track = trackObj;
        },

        SET_TRACKS_COLLECTION: (state, tracksCollectionObj) => {
            state.tracksCollection = tracksCollectionObj;
        }
    },

    actions: {
        UPLOAD_TRACK: async (track) => {
            try {
                await trackService.uploadTrack(track);
            } catch (err) {
                throw new Error(err.response.data.Message);
            }
        },

        GET_TRACK: async ({ commit }, title) => {
            try {
                const response = await trackService.getTrack(title);
                commit('SET_TRACK', response.data);
            } catch (err) {
                throw new Error(err.response.data.Message);
            }
        },

        BROWSE_TRACKS: async ({ commit }, tracksQuerry) => {
            try {
                const response = await trackService.browseTracks(tracksQuerry);
                commit('SET_TRACKS_COLLECTION', response.data);
            } catch (err) {
                throw new Error(err.response.data.Message);
            }
        }
    }
}

export default trackStore;