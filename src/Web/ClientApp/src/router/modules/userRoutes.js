const userRoutes = [
    {
        path: '/user/:userName',
        name: 'User',
        component: () => import('@/views/public/User.vue'),
        props: true
    }
];

export default userRoutes;