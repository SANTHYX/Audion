import api from '../plugins/axios'

const userService = {
    getUser: async (userName) => {
        try {
            const response = await api.get(`/users/${userName}`);

            return response;
        } catch (err) {
            console.error(err.message);
        }
    }
};

export default userService;