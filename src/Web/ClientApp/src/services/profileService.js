import api from '../plugins/axios'

const profileService = {
    createProfile: async (profileModel) => {
        try {
            await api.post('/profiles', profileModel);
        } catch (err) {
            console.error(err.message);
        }
    },

    updateProfile: async (profileModel) => {
        try {
            await api.put('/profiles', profileModel)
        } catch (err) {
            console.error(err.message);
        }
    }
};

export default profileService;