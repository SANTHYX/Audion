<template>
	<v-app-bar app color="gray" dark flat>
		<div class="d-flex align-center">
			<v-img
				alt="Vuetify Logo"
				class="shrink mr-2"
				contain
				src="https://cdn.vuetifyjs.com/images/logos/vuetify-logo-dark.png"
				transition="scale-transition"
				width="40"
			/>
			<v-img
				alt="Vuetify Name"
				class="shrink mt-1 hidden-sm-and-down"
				contain
				min-width="100"
				src="https://cdn.vuetifyjs.com/images/logos/vuetify-name-dark.png"
				width="100"
			/>
		</div>
		<v-spacer></v-spacer>
		<v-btn :to="{ name: 'Register' }" plain>
			<v-icon left>mdi-account-plus</v-icon>
			Register
		</v-btn>
		<v-btn :to="{ name: 'Login' }" plain>
			<v-icon left>mdi-login</v-icon>
			Login
		</v-btn>
	</v-app-bar>
</template>

<script>
export default {
	name: 'Navbar',
	props: {
		authStatus: {
			type: Boolean,
			required: true,
		},
	},
	data: () => ({
		menuItems: {
			auth: [],
			default: [],
		},
	}),
};
</script>

<style></style>
