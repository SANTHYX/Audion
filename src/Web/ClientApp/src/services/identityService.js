import api from '../plugins/axios'
import storage from '../plugins/storage'

const identityService = {
    registerUser: async (userModel) => {
        await api.post('/identity/register', userModel);
    },

    loginUser: async (userCreedentials) => {
        const response = await api.post('/identity/login', userCreedentials);
        storage.storeToken(response.data);

        return response;
    },

    refreshToken: async (tokens) => {
        const response = await api.post('identity/refresh-token', tokens);

        return response;

    },

    revokeToken: async (tokens) => {
        await api.put('identity/revoke-token', tokens);
        storage.removeToken();
    }
};

export default identityService;