import userService from '../../services/userService'

const userStore = {
    namespaced: true,

    state: {
        user: {},
    },

    getters: {
        GET_USER: (state) => state.user,
    },

    mutations: {
        SET_USER: (state, userObj) => {
            state.user = userObj;
        },
    },

    actions: {
        GET_USER: async ({ commit }, userName) => {
            try {
                const response = await userService.getUser(userName);
                commit('SET_USER', response.data);
            } catch (err) {
                console.error(err.response.data.Message);
            }
        }
    }
}

export default userStore;