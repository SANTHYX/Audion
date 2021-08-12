<template>
	<div id="register">
		<v-main>
			<v-card>
				<v-card-title>
					<h2 class="display-3">Register</h2>
				</v-card-title>

				<v-card-subtitle>
					<h3 class="subtitle">Pass your account information</h3>
				</v-card-subtitle>

				<v-card-text>
					<v-form>
						<v-text-field label="Login" v-model="user.login" />
						<v-text-field
							label="Password"
							type="password"
							v-model="user.password"
						/>
						<v-text-field label="E-mail" v-model="user.email" />
						<v-btn class="success" @click="registerUser(user)">Register</v-btn>
					</v-form>
				</v-card-text>
			</v-card>
		</v-main>
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
