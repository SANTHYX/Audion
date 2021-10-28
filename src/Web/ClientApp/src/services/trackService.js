import api from '../plugins/axios'

const trackService = {
    uploadTrack: async (trackModel) => {
        const model = new FormData();
        model.append('title', trackModel.title);
        model.append('track', trackModel.track);
        await api.post('/tracks', model);
    },

    getTrack: async (title) => {
        const response = await api.get(`/tracks/${title}`);

        return response;
    },

    browseTracks: async (tracksQuery) => {
        const response = await api.get('/tracks', { params: { ...tracksQuery } });

        return response;
    }
};

export default trackService;