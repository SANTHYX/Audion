<template>
	<div id="login">
		<v-container>
			<v-card class="mx-auto mt-12" max-width="600">
				<v-card-title class="justify-center">
					<h1 class="display-2">Login</h1>
				</v-card-title>
				<v-card-text>
					<v-form class="mt-4">
						<v-text-field
							label="Login"
							prepend-inner-icon="mdi-account"
							outlined
							dense
							v-model="creedentials.login"
						/>
						<v-text-field
							label="Password"
							prepend-inner-icon="mdi-form-textbox-password"
							outlined
							dense
							v-model="creedentials.password"
							type="password"
						/>
					</v-form>
				</v-card-text>
				<v-card-actions class="justify-center">
					<v-btn class="success" width="120" @click="loginUser(creedentials)">
						Login
					</v-btn>
				</v-card-actions>
				<v-card-subtitle class="flex justify-center">
					<v-row class="justify-center">
						<p>
							Did you forgot your password?
							<router-link id="href-fix" tag="a" to="Register" exact="exact">
								Click here
							</router-link>
						</p>
					</v-row>
				</v-card-subtitle>
			</v-card>
		</v-container>
	</div>
</template>

<script>
import { mapActions } from 'vuex';

export default {
	name: 'Login',
	data: () => ({
		creedentials: {
			login: '',
			password: '',
		},
	}),
	methods: {
		...mapActions({
			loginUser: 'identityStore/LOGIN_USER',
		}),
	},
};
</script>

<style>
#href-fix {
	text-decoration: none;
	color: rgb(25, 131, 57);
}
</style>
