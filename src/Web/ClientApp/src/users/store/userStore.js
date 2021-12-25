import userService from '../service/userService'

const userStore = {
    namespaced: true,

    state: {
        user: {},
        usersCollection: {}
    },

    getters: {
        USERS_COLLECTION: (state) => state.usersCollection,

        USER: (state) => state.user,
    },

    mutations: {
        SET_USER: (state, userObj) => {
            state.user = userObj;
        },

        SET_USERS_COLLECTION: (state, usersCollection) => {
            state.usersCollection = usersCollection;
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
        },

        BROWSE_USERS: async (context, queryObj) => {
            try {
                const response = await userService.browseUsers(queryObj);
                context.commit('SET_USERS_COLLECTION', response.data);
            } catch (err) {
                throw new Error(err.response.data.Message);
            }
        }
    }
}

export default userStore;