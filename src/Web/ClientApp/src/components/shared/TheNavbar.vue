<template>
	<v-app-bar app color="gray" dark flat outlined>
		<v-spacer />
		<the-search-bar />
		<v-spacer />
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
			<v-row align="center">
				<v-btn class="mr-3" outlined @click="modalVisibility = true">
					<v-icon>mdi-plus</v-icon>
					Upload
				</v-btn>
				<upload-modal
					v-model="modalVisibility"
					@upload="uploadTrackAction($event)"
				/>
				<v-btn
					v-for="route in routes.auth"
					:key="route.label"
					:to="{ name: route.routeName }"
					plain
				>
					<v-icon left>{{ route.icon }}</v-icon>
					{{ route.label }}
				</v-btn>
				<drop-menu
					:userName="userName"
					:dropdownRoutes="dropdownRoutes"
					@handle="logoutAction"
				/>
			</v-row>
		</div>
	</v-app-bar>
</template>

<script>
import TheSearchBar from './TheSearchBar.vue';
import DropMenu from './auth/DropMenu.vue';

export default {
	name: 'Navbar',
	props: {
		isAuthenticated: { type: Boolean, required: true },
		userName: { type: String },
		logoutAction: { type: Function, required: true },
		uploadTrackAction: { type: Function, required: true },
	},
	data: () => ({
		routes: {
			auth: [
				{
					icon: 'mdi-home',
					routeName: 'Home',
					label: 'Home',
				},
			],
			default: [
				{
					icon: 'mdi-login',
					routeName: 'Login',
					label: 'Login',
				},
				{
					icon: 'mdi-account-plus',
					routeName: 'Register',
					label: 'Register',
				},
			],
		},
		dropdownRoutes: [
			{
				icon: 'mdi-account',
				routeName: 'UserOverview',
				label: 'Account',
			},
		],
		modalVisibility: false,
	}),
	components: {
		TheSearchBar,
		DropMenu,
		UploadModal: () => import('./auth/UploadModal.vue'),
	},
};
</script>

<style>
.pointer {
	cursor: pointer;
}
</style>
