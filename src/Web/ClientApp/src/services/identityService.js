import api from '../plugins/axios'

const identityService = {
    registerUser: async (userModel) => {
        await api.post('', userModel);
    },

    loginUser: async (userCreedentials) => {
        const response = await api.post('', userCreedentials);
        return response;
    },

    refreshToken: async (tokens) => {
        const response = await api.post('', tokens)
        return response;
    },

    revokeToken: async (tokens) => {
        await api.put('', tokens);
    }
};

export default identityService;