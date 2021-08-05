import identityService from '../../services/identityService'

const identityStore = {
    namespaced: true,

    state: {

    },

    getters: {

    },

    mutations: {

    },

    actions: {
        REGISTER_ASYNC: async (userModel) => {
            await identityService.registerUser(userModel);
        },
    }
}

export default identityStore;