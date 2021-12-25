import api from '../../commons/plugins/axios'

const userService = {
    getUser: async (userName) => {
        const response = await api.get(`/users/${userName}`);

        return response;
    },
    browseUsers: async (queryObj) => {
        const response = await api.get(`/users`, { params: queryObj });

        return response;
    }
};

export default userService;