import api from '../../commons/plugins/axios'

const trackService = {
    uploadTrack: async (trackModel) => {
        const model = new FormData();
        model.append('Title', trackModel.title);
        model.append('Track', trackModel.file);

        await api.post('/tracks', model);
    },

    getTrack: async (title) => {
        const response = await api.get(`/tracks/${title}`);

        return response;
    },

    browseTracks: async (tracksQuery) => {
        const response = await api.get('/tracks', { params: { ...tracksQuery } });

        return response;
    },

    removeTrack: async (id) => {
        await api.delete(`track/${id}`);
    }
};

export default trackService;