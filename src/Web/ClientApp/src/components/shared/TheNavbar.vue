<template>
	<v-app-bar app color="gray" dark flat outlined>
		<v-spacer />
		<the-search-bar />
		<v-spacer />
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
			<v-row align="center">
				<v-btn outlined @click="modalVisibility = true">
					<v-icon>mdi-plus</v-icon>
					Upload
				</v-btn>
				<upload-modal
					:visable="modalVisibility"
					@upload-modal-visibility="disableVisibility"
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
					:logoutAction="logoutAction"
					:dropdownRoutes="dropdownRoutes"
				/>
			</v-row>
		</div>
	</v-app-bar>
</template>

<script>
import TheSearchBar from './TheSearchBar.vue';
import DropMenu from './auth/DropMenu.vue';
import UploadModal from './auth/UploadModal.vue';

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
			auth: [{ icon: 'mdi-home', routeName: 'Home', label: 'Home' }],
			default: [
				{ icon: 'mdi-login', routeName: 'Login', label: 'Login' },
				{ icon: 'mdi-account-plus', routeName: 'Register', label: 'Register' },
			],
		},
		dropdownRoutes: [
			{ icon: 'mdi-account', routeName: 'UserOverview', label: 'Account' },
		],
		modalVisibility: false,
	}),
	methods: {
		disableVisibility(val) {
			this.modalVisibility = val;
		},
	},
	components: {
		TheSearchBar,
		DropMenu,
		UploadModal,
	},
};
</script>

<style>
.pointer {
	cursor: pointer;
}
</style>
