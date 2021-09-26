<template>
	<v-app-bar app color="gray" dark flat>
		<v-spacer></v-spacer>
		<!----------------SearchBar---------------------->
		<v-text-field
			class="mt-6"
			color="green"
			placeholder="Search..."
			v-model="searchPhrase"
			filled
			outlined
			dense
			@keypress.enter="
				$router.push({ name: 'SearchResults', query: { phrase: searchPhrase } })
			"
		/>
		<v-btn
			color="blue"
			:to="{ name: 'SearchResults', query: { phrase: searchPhrase } }"
			replace
		>
			<v-icon>
				mdi-magnify
			</v-icon>
		</v-btn>
		<v-spacer></v-spacer>
		<!--rendering routes in menu based on reactive local data and authentication status-->
		<div v-if="!isAuthenticated">
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
			<v-btn outlined>
				<v-icon>mdi-plus</v-icon>
				Upload
			</v-btn>
			<v-btn
				v-for="route in routes.auth"
				:key="route.label"
				:to="{ name: `${route.routeName}` }"
				plain
			>
				<v-icon left>{{ route.icon }}</v-icon>
				{{ route.label }}
			</v-btn>
			<v-menu offset-y auto open-on-hover>
				<template v-slot:activator="{ on, attrs }">
					<v-btn plain v-bind="attrs" v-on="on">
						<span>Hi {{ userName }}</span>
						<v-icon>mdi-menu-down</v-icon>
					</v-btn>
				</template>
				<v-list>
					<v-list-item class="pointer" @click="logoutAction">
						<v-list-item-icon>
							<v-icon>mdi-logout</v-icon>
						</v-list-item-icon>
						<v-list-item-title>Logout</v-list-item-title>
					</v-list-item>
					<v-list-item class="pointer" :to="{ name: 'UserOverview' }">
						<v-list-item-icon>
							<v-icon>mdi-account</v-icon>
						</v-list-item-icon>
						<v-list-item-title>Account</v-list-item-title>
					</v-list-item>
				</v-list>
			</v-menu>
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
		userName: {
			type: String,
		},
		logoutAction: {
			type: Function,
			required: true,
		},
	},
	data: () => ({
		searchPhrase: '',
		routes: {
			auth: [{ icon: 'mdi-home', routeName: 'Home', label: 'Home' }],
			default: [
				{ icon: 'mdi-login', routeName: 'Login', label: 'Login' },
				{ icon: 'mdi-account-plus', routeName: 'Register', label: 'Register' },
			],
		},
	}),
};
</script>

<style>
.pointer {
	cursor: pointer;
}
</style>
