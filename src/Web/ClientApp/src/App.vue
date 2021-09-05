<template>
	<v-app>
		<v-navbar />
		<v-main>
			<router-view />
		</v-main>
		<v-footer />
	</v-app>
</template>

<script>
import TheNavbar from './components/shared/TheNavbar.vue';
import TheFooter from './components/shared/TheFooter.vue';

export default {
	name: 'App',
	components: {
		'v-navbar': TheNavbar,
		'v-footer': TheFooter,
	},
};
</script>
