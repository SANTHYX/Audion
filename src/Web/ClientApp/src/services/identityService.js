import api from '../plugins/axios'

const identityService = {
    registerUser: async (userModel) => {
        try {
            await api.post('/identity/register', userModel);
        } catch (err) {
            console.error(err.message);
        }
    },

    loginUser: async (userCreedentials) => {
        try {
            const response = await api.post('/identity/login', userCreedentials);

            return response;
        } catch (err) {
            console.error(err.message);
        }
    },

    refreshToken: async (tokens) => {
        try {
            const response = await api.post('identity/refresh-token', tokens);

            return response;
        } catch (err) {
            console.error(err.message);
        }
    },

    revokeToken: async (tokens) => {
        try {
            await api.put('identity/revoke-token', tokens);
        } catch (err) {
            console.error(err.message);
        }
    }
};

export default identityService;