<template>
	<v-container id="account" fluid>
		<v-row justify="space-between">
			<v-card>
				<v-navigation-drawer height="100vh">
					<v-list>
						<v-list-item v-for="route in routes" :key="route.routeName">
							<v-btn :to="{ name: route.routeName }" plain>
								{{ route.title }}
							</v-btn>
						</v-list-item>
					</v-list>
				</v-navigation-drawer>
			</v-card>
			<v-col>
				<router-view
					:user="this['user/USER']"
					:userName="this['identity/userName']"
					:updateProfileAction="this['profile/UPDATE_PROFILE']"
					:changeCreedentialsAction="this['identity/CHANGE_CREEDENTIALS']"
					:fetchUserAction="this['user/GET_USER']"
					:clearStateMutation="this['user/CLEAR_STATE']"
				/>
			</v-col>
		</v-row>
	</v-container>
</template>

<script>
import { mapGetters, mapMutations, mapActions } from 'vuex';

export default {
	name: 'Account',
	computed: {
		...mapGetters(['identity/userName', 'user/USER']),
	},
	data: () => ({
		routes: [
			{
				routeName: 'UserOverview',
				title: 'Overview',
			},
			{
				routeName: 'EditProfile',
				title: 'Profile',
			},
			{
				routeName: 'EditCreedentials',
				title: 'Account',
			},
			{
				routeName: 'ManageTracks',
				title: 'Tracks',
			},
			{
				routeName: 'ManagePlaylists',
				title: 'Playlists',
			},
		],
	}),
	methods: {
		...mapActions([
			'user/GET_USER',
			'profile/CREATE_PROFILE',
			'profile/UPDATE_PROFILE',
			'identity/CHANGE_CREEDENTIALS',
		]),
		...mapMutations(['user/CLEAR_STATE']),
	},
};
</script>

<style>
#account {
	width: 100vw;
}
</style>
