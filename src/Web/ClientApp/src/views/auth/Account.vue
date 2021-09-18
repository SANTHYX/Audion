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
				<router-view
					:user="user"
					:updateProfileAction="this['profileStore/UPDATE_PROFILE']"
					:changeCreedentialsAction="this['identityStore/CHANGE_CREEDENTIALS']"
				/>
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
			user: 'userStore/USER',
		}),
	},
	methods: {
		...mapActions([
			'userStore/GET_USER',
			'profileStore/CREATE_PROFILE',
			'profileStore/UPDATE_PROFILE',
			'identityStore/CHANGE_CREEDENTIALS',
		]),
	},
	async mounted() {
		await this['userStore/GET_USER'](this.userName);
	},
};
</script>

<style></style>
