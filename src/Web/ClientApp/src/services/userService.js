import api from '../plugins/axios'

const userService = {
    getUser: async (userName) => {
        const response = await api.get(`/users/${userName}`);

        return response;
    }
};

export default userService;