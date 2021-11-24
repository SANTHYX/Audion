import api from '../../commons/plugins/axios'

const profileService = {
    createProfile: async (profileModel) => {
        await api.post('/profiles', profileModel);
    },

    updateProfile: async (profileModel) => {
        await api.put('/profiles', profileModel)
    },

    uploadAvatar: async (avatarModel) => {
        const avatarForm = new FormData();
        avatarForm.append("avatar", avatarModel.avatar);

        await api.put('/profiles/upload-avatar', avatarForm);
    }
};

export default profileService;