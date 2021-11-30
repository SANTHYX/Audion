import storage from './storage';
import axios from 'axios';
import identityService from '../../identity/services/identityService'

const api = axios.create({
    baseURL: process.env.API_BASE_URL,
})

api.interceptors.request.use(
    request => {
        let token = storage.getAccessToken();
        if (token)
            request.headers['Authorization'] = `Bearer ${token}`;

        return request;
    },
    err => Promise.reject(err));

api.interceptors.response.use(
    response => response,
    async err => {
        if (err.response.status === 401 && !err.response.config.url.includes('/login')) {
            let refresh = storage.getRefresh();
            await identityService.refreshToken({ refreshToken: refresh });
            return api(err.config)
        }
        return Promise.reject(err);
    });

export default api;