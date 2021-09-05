<template>
	<v-container id="user" fluid>
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
				<router-view />
			</v-col>
		</v-row>
	</v-container>
</template>

<script>
export default {
	name: 'User',
};
</script>

<style></style>
