<template>
	<div id="register">
		<v-container>
			<v-card class="mx-auto mt-12" max-width="600">
				<v-card-title class="justify-center">
					<h1 class="display-2">Register</h1>
				</v-card-title>
				<v-card-text>
					<v-form class="mt-4">
						<v-text-field
							label="Login"
							prepend-inner-icon="mdi-account"
							outlined
							dense
							v-model="user.login"
						/>
						<v-text-field
							label="Password"
							outlined
							dense
							prepend-inner-icon="mdi-form-textbox-password"
							type="password"
							v-model="user.password"
						/>
						<v-text-field
							label="E-mail"
							prepend-inner-icon="mdi-email"
							outlined
							dense
							v-model="user.email"
						/>
					</v-form>
				</v-card-text>
				<v-card-actions class="justify-center">
					<v-btn class="success" width="120" @click="registerUser(user)">
						Register
					</v-btn>
				</v-card-actions>
			</v-card>
		</v-container>
	</div>
</template>

<script>
import { mapActions } from 'vuex';

export default {
	name: 'Register',
	data: () => ({
		user: {
			login: '',
			password: '',
			email: '',
		},
	}),
	methods: {
		...mapActions({
			registerUser: 'identityStore/REGISTER_USER',
		}),
	},
};
</script>

<style></style>
