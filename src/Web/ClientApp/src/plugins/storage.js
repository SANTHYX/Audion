const storage = {
    storeToken: (tokenObj) => {
        const { accessToken, refresh, expiresAt } = tokenObj;
        localStorage.setItem('accessToken', accessToken);
        localStorage.setItem('refresh', refresh);
        localStorage.setItem('expiresAt', expiresAt);
    },

    removeToken: () => {
        localStorage.removeItem('accessToken');
        localStorage.removeItem('refresh');
        localStorage.removeItem('expiresAt');
    },

    getAccessToken: () => localStorage.getItem('accessToken'),

    getRefresh: () => localStorage.getItem('refresh'),
};

export default storage;