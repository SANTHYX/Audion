<template>
	<v-app>
		<v-navbar :authStatus="isAuthenticated" :userName="userName" />
		<v-main>
			<router-view />
		</v-main>
		<v-footer />
	</v-app>
</template>

<script>
import { mapGetters } from 'vuex';
import TheNavbar from './components/shared/TheNavbar.vue';
import TheFooter from './components/shared/TheFooter.vue';

export default {
	name: 'App',
	computed: {
		...mapGetters('identityStore', ['userName', 'isAuthenticated']),
	},
	components: {
		'v-navbar': TheNavbar,
		'v-footer': TheFooter,
	},
};
</script>
