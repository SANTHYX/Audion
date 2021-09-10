<template>
	<v-container id="account" fluid>
		<v-row>
			<v-card height="100vh">
				<v-navigation-drawer>
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
				<router-view :user="user" :updateProfilePromise="updateProfile" />
			</v-col>
		</v-row>
	</v-container>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';

export default {
	name: 'Account',
	computed: {
		...mapGetters({
			userName: 'identityStore/userName',
			user: 'userStore/GET_USER',
		}),
	},
	methods: {
		...mapActions({
			getUser: 'userStore/GET_USER',
			createProfile: 'profileStore/CREATE_PROFILE',
			updateProfile: 'profileStore/UPDATE_PROFILE',
		}),
	},
	async mounted() {
		await this.getUser(this.userName);
	},
};
</script>

<style></style>
