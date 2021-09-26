<template>
	<v-app>
		<v-navbar
			:isAuthenticated="isAuthenticated"
			:userName="userName"
			:logoutAction="this['identity/LOGOUT_USER']"
		/>
		<v-main>
			<router-view :key="$route.fullPath" />
		</v-main>
		<v-footer />
	</v-app>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';
// eslint-disable-next-line no-unused-vars
import router from 'vue-router';
import TheNavbar from './components/shared/TheNavbar.vue';
import TheFooter from './components/shared/TheFooter.vue';

export default {
	name: 'App',
	computed: {
		...mapGetters('identity', ['userName', 'isAuthenticated']),
	},
	methods: {
		...mapActions(['identity/LOGOUT_USER']),
	},
	components: {
		'v-navbar': TheNavbar,
		'v-footer': TheFooter,
	},
};
</script>
