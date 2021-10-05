<template>
	<v-container id="account" fluid>
		<v-row>
			<v-card>
				<v-navigation-drawer height="100vh">
					<v-list>
						<v-list-item>
							<v-btn :to="{ name: 'UserOverview' }" plain>
								Overview
							</v-btn>
						</v-list-item>
						<v-list-item>
							<v-btn :to="{ name: 'EditProfile' }" plain>
								Profile
							</v-btn>
						</v-list-item>
						<v-list-item>
							<v-btn :to="{ name: 'EditCreedentials' }" plain>
								Account
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

<style></style>
