import identityService from '../services/identityService'

const identityStore = {
    namespaced: true,

    state: {
        tokens: identityService.getTokenObj(),
    },

    getters: {
        isAuthenticated: (state) =>
            !!state.tokens.userName &&
            state.tokens.refresh &&
            state.tokens.expiresAt !== null,

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
        REGISTER_USER: async (context, userModel) => {
            try {
                await identityService.registerUser(userModel);
            } catch (err) {
                throw new Error(err.response.data.Message);
            }
        },

        LOGIN_USER: async (context, creedendialsObj) => {
            try {
                const response = await identityService.loginUser(creedendialsObj);
                context.commit('SET_IDENTITY', response.data);
            } catch (err) {
                throw new Error(err.response.data.Message);
            }
        },

        LOGOUT_USER: async (context) => {
            try {
                await identityService.revokeToken({ refreshToken: context.state.tokens.refresh });
                context.commit('CLEAR_IDENTITY');
            } catch (err) {
                throw new Error(err.response.data.Message);
            }
        },

        CHANGE_CREEDENTIALS: async (context, creedentialsObj) => {
            try {
                await identityService.changeCreedentials(creedentialsObj);
            } catch (err) {
                throw new Error(err.response.data.Message);
            }
        }
    }
}

export default identityStore;