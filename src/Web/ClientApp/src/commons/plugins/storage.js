const storage = {
    storeToken: (tokenObj) => {
        const { accessToken, refresh, userName } = tokenObj;
        localStorage.setItem('accessToken', accessToken);
        localStorage.setItem('refresh', refresh);
        localStorage.setItem('userName', userName);
    },

    removeToken: () => {
        localStorage.removeItem('accessToken');
        localStorage.removeItem('refresh');
        localStorage.removeItem('userName');
    },

    getAccessToken: () => localStorage.getItem('accessToken'),

    getRefresh: () => localStorage.getItem('refresh'),

    getUserName: () => localStorage.getItem('userName'),

    getTokenObj: () => {
        const accessToken = storage.getAccessToken();
        const refresh = storage.getRefresh();
        const userName = storage.getUserName();
        return { accessToken, refresh, userName }
    },
};

export default storage;