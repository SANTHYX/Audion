import identityService from '../../services/identityService'

const identityStore = {
    namespaced: true,

    state: {
        tokens: identityService.getTokenObj(),
    },

    getters: {
        isAuthenticated: (state) => state.tokens !== JSON.stringify('[]'),

        userName: (state) => state.tokens.userName
    },

    mutations: {
        SET_IDENTITY: (state, tokensObj) => {
            state.tokens = tokensObj;
        },

        CLEAR_IDENTITY: (state) => {
            state.tokens = {}
        },
    },

    actions: {
        REGISTER_USER: async (userModel) => {
            try {
                await identityService.registerUser(userModel);
            } catch (err) {
                throw new Error(err.response.data.Message);
            }
        },

        LOGIN_USER: async ({ commit }, creedendialsObj) => {
            try {
                const response = await identityService.loginUser(creedendialsObj);
                commit('SET_IDENTITY', response.data);
            } catch (err) {
                throw new Error(err.response.data.Message);
            }
        },

        LOGOUT_USER: async ({ commit }, tokens) => {
            try {
                await identityService.revokeToken(tokens);
                commit('CLEAR_IDENTITY');
            } catch (err) {
                throw new Error(err.response.data.Message);
            }
        },

        CHANGE_CREEDENTIALS: async (creedentialsObj) => {
            try {
                await identityService.changeCreedentials(creedentialsObj);
            } catch (err) {
                throw new Error(err.response.data.Message);
            }
        }
    }
}

export default identityStore;