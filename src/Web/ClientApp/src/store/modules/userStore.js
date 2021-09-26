import userService from '../../services/userService'

const userStore = {
    namespaced: true,

    state: {
        user: {},
    },

    getters: {
        USER: (state) => state.user,
    },

    mutations: {
        SET_USER: (state, userObj) => {
            state.user = userObj;
        },

        CLEAR_STATE: (state) => state.user = {}
    },

    actions: {
        GET_USER: async (context, userName) => {
            try {
                const response = await userService.getUser(userName);
                context.commit('SET_USER', response.data);
            } catch (err) {
                throw new Error(err.response.data.Message);
            }
        }
    }
}

export default userStore;