import api from '../plugins/axios'

const profileService = {
    createProfile: async (profileModel) => {
        try {
            await api.post('/profiles', profileModel);
        } catch (err) {
            console.error(err.response.data);
        }
    },

    updateProfile: async (profileModel) => {
        try {
            await api.put('/profiles', profileModel)
        } catch (err) {
            console.error(err.response.data);
        }
    }
};

export default profileService;