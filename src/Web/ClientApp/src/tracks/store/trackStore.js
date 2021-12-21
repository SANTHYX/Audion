import trackService from '../service/trackService'

const trackStore = {
    namespaced: true,

    state: {
        track: {},
        tracksCollection: {},
    },

    getters: {
        GET_TRACK: (state) => state.track,

        GET_TRACKS_COLLECTION: (state) => state.tracksCollection
    },

    mutations: {
        SET_TRACK: (state, trackObj) => {
            state.track = trackObj;
        },

        SET_TRACKS_COLLECTION: (state, tracksCollectionObj) => {
            state.tracksCollection = tracksCollectionObj;
        },

        REMOVE_TRACK: (state) => {
            state.track = {}
        },

        REMOVE_TRACKS_COLLECTION: (state) => {
            state.tracksCollection = {}
        }
    },

    actions: {
        UPLOAD_TRACK: async (context, track) => {
            try {
                await trackService.uploadTrack(track);
            } catch (err) {
                throw new Error(err.response.data.Message);
            }
        },

        GET_TRACK_ASYNC: async (context, title) => {
            try {
                const response = await trackService.getTrack(title);
                context.commit('SET_TRACK', response.data);
            } catch (err) {
                throw new Error(err.response.data.Message);
            }
        },

        BROWSE_TRACKS: async (context, tracksQuerry) => {
            try {
                const response = await trackService.browseTracks(tracksQuerry);
                context.commit('SET_TRACKS_COLLECTION', response.data);
            } catch (err) {
                throw new Error(err.response.data.Message);
            }
        },

        REMOVE_TRACK: async (context, id) => {
            try {
                await trackService.removeTrack(id);
            } catch (err) {
                throw new Error(err.response.data.Message);
            }
        }
    }
}

export default trackStore;