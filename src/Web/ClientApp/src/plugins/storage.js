const storage = {
    storeToken: (tokenObj) => {
        const { accessToken, refresh } = tokenObj;
        localStorage.setItem('accessToken', accessToken);
        localStorage.setItem('refresh', refresh);
    },

    removeToken: () => {
        localStorage.removeItem('accessToken');
        localStorage.removeItem('refresh');
    },

    getAccessToken: () => localStorage.getItem('accessToken'),

    getRefresh: () => localStorage.getItem('refresh'),


};

export default storage;