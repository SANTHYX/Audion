import axios from 'axios';
import identityService from '../../identity/services/identityService'

const api = axios.create({
    baseURL: process.env.API_BASE_URL,
})

api.interceptors.request.use(
    request => {
        const tokens = identityService.getTokenObj();
        if (tokens)
            request.headers['Authorization'] = `Bearer ${tokens.accessToken}`;

        return request;
    },
    err => Promise.reject(err));

api.interceptors.response.use(
    response => response,
    async err => {
        const tokens = identityService.getTokenObj();
        if (err.response.status === '401' && !err.response.config.url.includes('login')) {
            await identityService.refreshToken({ 'refreshToken': tokens.refresh });
            return api(err.config)
        }

        return Promise.reject(err);
    });

export default api;