<template>
	<v-app>
		<v-navbar
			:isAuthenticated="isAuthenticated"
			:userName="userName"
			:logoutAction="this['identityStore/LOGOUT_USER']"
		/>
		<v-main>
			<router-view />
		</v-main>
		<v-footer />
	</v-app>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';
import TheNavbar from './components/shared/TheNavbar.vue';
import TheFooter from './components/shared/TheFooter.vue';

export default {
	name: 'App',
	computed: {
		...mapGetters('identityStore', ['userName', 'isAuthenticated']),
	},
	methods: {
		...mapActions(['identityStore/LOGOUT_USER']),
	},
	components: {
		'v-navbar': TheNavbar,
		'v-footer': TheFooter,
	},
};
</script>
