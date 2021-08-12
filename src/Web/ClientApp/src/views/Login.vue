<template>
	<div id="login">
		<v-main>
			<v-card>
				<v-card-title>
					<h2 class="display-3">Login</h2>
				</v-card-title>

				<v-card-subtitle>
					<h3 class="subtitle">Please, enter your creednetials</h3>
				</v-card-subtitle>

				<v-card-text>
					<v-form>
						<v-text-field label="Login" v-model="creedentials.login" />
						<v-text-field
							label="Password"
							v-model="creedentials.password"
							type="password"
						/>
						<v-btn class="success" @click="loginUser(creedentials)"
							>Login</v-btn
						>
					</v-form>
				</v-card-text>
			</v-card>
		</v-main>
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

<style></style>
