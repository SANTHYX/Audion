<template>
	<v-app>
		<v-navbar
			:isAuthenticated="isAuthenticated"
			:userName="userName"
			:logoutAction="this['identity/LOGOUT_USER']"
			:uploadTrackAction="this['track/UPLOAD_TRACK']"
		/>
		<v-main>
			<router-view :key="$route.fullPath" :isAuthenticated="isAuthenticated" />
		</v-main>
		<v-footer />
	</v-app>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';
// eslint-disable-next-line no-unused-vars
import router from 'vue-router';
import TheNavbar from './commons/components/shared/TheNavbar.vue';
import TheFooter from './commons/components/shared/TheFooter.vue';

export default {
	name: 'App',
	computed: {
		...mapGetters('identity', ['userName', 'isAuthenticated']),
	},
	methods: {
		...mapActions(['identity/LOGOUT_USER', 'track/UPLOAD_TRACK']),
	},
	components: {
		'v-navbar': TheNavbar,
		'v-footer': TheFooter,
	},
};
</script>
