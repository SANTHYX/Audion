import identityService from '../../services/identityService'

const identityStore = {
    namespaced: true,

    state: {
        tokens: {}
    },

    getters: {

    },

    mutations: {
        SET_IDENTITY: (state, tokensObj) => {
            state.tokens = tokensObj;
        },

        CLEAR_IDENTITY: (state) => {
            state.tokens = {}
        }
    },

    actions: {
        REGISTER_USER: async (userModel) => {
            try {
                await identityService.registerUser(userModel);
            } catch (err) {
                console.error(err.message);
            }
        },

        LOGIN_USER: async ({ commit }, creedendialsObj) => {
            try {
                const response = await identityService.loginUser(creedendialsObj);
                commit('SET_IDENTITY', response.data);
            } catch (err) {
                console.error(err.message);
            }
        },

        LOGOUT_USER: async ({ commit }, tokens) => {
            try {
                await identityService.revokeToken(tokens);
                commit('CLEAR_IDENTITY');
            } catch (err) {
                console.error(err.message);
            }
        }
    }
}

export default identityStore;