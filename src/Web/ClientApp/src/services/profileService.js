import api from '../plugins/axios'

const profileService = {
    createProfile: async (profileModel) => {
        await api.post('/profiles', profileModel);
    },

    updateProfile: async (profileModel) => {
        await api.put('/profiles', profileModel)
    }
};

export default profileService;