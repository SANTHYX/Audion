import profileService from '../../services/profileService'

const profileStore = {
    namespaced: true,

    actions: {
        CREATE_PROFILE: async (profileObj) => {
            try {
                await profileService.createProfile(profileObj);
            } catch (err) {
                throw new Error(err.response.data.Message);
            }
        },

        UPDATE_PROFILE: async (profileObj) => {
            try {
                await profileService.updateProfile(profileObj);
            } catch (err) {
                throw new Error(err.response.data.Message);
            }
        }
    }
};

export default profileStore