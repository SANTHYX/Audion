import api from '../plugins/axios'
import storage from '../plugins/storage'

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
            storage.storeToken(response.data);

            return response;
        } catch (err) {
            console.error(err.response.data);
        }
    },

    refreshToken: async (tokens) => {
        try {
            const response = await api.post('identity/refresh-token', tokens);

            return response;
        } catch (err) {
            console.error(err.response.data);
        }
    },

    revokeToken: async (tokens) => {
        try {
            await api.put('identity/revoke-token', tokens);
            storage.removeToken();
        } catch (err) {
            console.error(err.response.data);
        }
    }
};

export default identityService;