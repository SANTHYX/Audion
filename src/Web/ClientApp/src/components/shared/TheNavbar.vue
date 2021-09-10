<template>
	<v-app-bar app color="gray" dark flat>
		<v-spacer></v-spacer>
		<!--rendering routes in menu based on reactive local data and authentication status-->
		<div v-if="isAuthenticated">
			<v-btn
				v-for="route in routes.default"
				:key="route.label"
				:to="{ name: `${route.routeName}` }"
				plain
			>
				<v-icon left>{{ route.icon }}</v-icon>
				{{ route.label }}
			</v-btn>
		</div>
		<div v-else>
			<v-btn
				v-for="route in routes.auth"
				:key="route.label"
				:to="{ name: `${route.routeName}` }"
				plain
			>
				<v-icon left>{{ route.icon }}</v-icon>
				{{ route.label }}
			</v-btn>
		</div>
	</v-app-bar>
</template>

<script>
export default {
	name: 'Navbar',
	props: {
		isAuthenticated: {
			type: Boolean,
			required: true,
		},
		userName: { type: String },
	},
	data: () => ({
		routes: {
			auth: [],
			default: [
				{ icon: 'mdi-login', routeName: 'Login', label: 'Login' },
				{ icon: 'mdi-account-plus', routeName: 'Register', label: 'Register' },
			],
		},
	}),
};
</script>

<style></style>
