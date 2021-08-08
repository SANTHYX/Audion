import api from '../plugins/axios'

const trackService = {
    uploadTrack: async (trackModel) => {
        try {
            const model = new FormData();
            await api.post('/tracks', model);
        } catch (err) {
            console.error(err.message);
        }
    },

    getTrack: async (title) => {
        try {
            const response = await api.get(`/tracks/${title}`);

            return response;
        } catch (err) {
            console.error(err.messgae);
        }
    },

    browseTracks: async (tracksQuery) => {
        try {
            const response = await api.get('/tracks', { params: { ...tracksQuery } });

            return response;
        } catch (err) {
            console.error(err.message);
        }
    }
};

export default trackService;