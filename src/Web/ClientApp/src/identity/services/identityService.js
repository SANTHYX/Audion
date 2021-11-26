import api from '../../commons/plugins/axios'
import storage from '../../commons/plugins/storage'

const identityService = {
    getTokenObj: () => {
        const accessToken = storage.getAccessToken();
        const refresh = storage.getRefresh();
        const userName = storage.getUserName();
        return { accessToken, refresh, userName }
    },

    registerUser: async (userModel) => {
        await api.post('/identity/register', userModel);
    },

    loginUser: async (userCreedentials) => {
        const response = await api.post('/identity/login', userCreedentials);
        storage.storeToken(response.data);

        return response;
    },

    refreshToken: async (tokens) => {
        const response = await api.post('/identity/refresh-token', tokens);
        storage.storeToken(response.data);

        return response;
    },

    revokeToken: async (tokens) => {
        await api.put('/identity/revoke-token', tokens);
        storage.removeToken();
    },

    changeCreedentials: async (userCreedentials) => {
        await api.put('/identity/change-creedentials', userCreedentials);
    },

    recoveryPassword: async (emailObj) => {
        await api.post('/identity/recovery-password', emailObj);
    },

    setPasswordAtRecovery: async (recoveryObj) => {
        await api.put(`/identity/recovery-password/${recoveryObj.recoveryId}`, recoveryObj);
    }
};

export default identityService;