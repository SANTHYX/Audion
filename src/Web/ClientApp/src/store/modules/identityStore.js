import identityService from '../../services/identityService'

const identityStore = {
    namespaced: true,

    state: {
        tokens: {},
        error: {}
    },

    getters: {

    },

    mutations: {
        SET_IDENTITY: (state, tokensObj) => {
            state.tokens = tokensObj;
        },

        SET_ERROR: (state, errorObj) => {
            state.error = errorObj
        },

        CLEAR_IDENTITY: (state) => {
            state.tokens = {}
        },
    },

    actions: {
        REGISTER_USER: async ({ commit }, userModel) => {
            try {
                await identityService.registerUser(userModel);
            } catch (err) {
                console.error(err.response.data.Message);
                commit('SET_ERROR', err.response.data);
            }
        },

        LOGIN_USER: async ({ commit }, creedendialsObj) => {
            try {
                const response = await identityService.loginUser(creedendialsObj);
                commit('SET_IDENTITY', response.data);
            } catch (err) {
                console.error(err.response.data.Message);
                commit('SET_ERROR', err.response.data);
            }
        },

        LOGOUT_USER: async ({ commit }, tokens) => {
            try {
                await identityService.revokeToken(tokens);
                commit('CLEAR_IDENTITY');
            } catch (err) {
                console.error(err.response.data.Message);
                commit('SET_ERROR', err.response.data);
            }
        }
    }
}

export default identityStore;