<template>
	<v-container id="login">
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
						v-model="creedentials.userName"
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
			<v-card-actions>
				<v-col>
					<!------------- ErrorsAlertRow -------------->
					<v-row class="justify-center">
						<v-alert v-model="error.isThrown" border="bottom" type="error">
							{{ error.message }}
						</v-alert>
					</v-row>
					<!------------- ButtonRow -------------->
					<v-row class="justify-center">
						<v-btn
							class="success"
							width="120"
							@click="loginUser"
							v-if="!isAwaiting"
						>
							Login
						</v-btn>
						<v-progress-circular indeterminate color="green" v-else />
					</v-row>
				</v-col>
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
</template>

<script>
import { mapActions } from 'vuex';

export default {
	name: 'Login',
	data: () => ({
		creedentials: {
			userName: '',
			password: '',
		},
		error: {
			message: undefined,
			isThrown: false,
		},
		validationRules: [],
		isAwaiting: false,
	}),
	methods: {
		async loginUser() {
			this.isAwaiting = true;
			this.error.isThrown = false;
			await this['identityStore/LOGIN_USER'](this.creedentials);
			this.$router.push(this.$route.query.redirect || '/');
		},
		...mapActions(['identityStore/LOGIN_USER']),
	},
	errorCaptured(err) {
		this.error.message = err.message;
		this.error.isThrown = true;
		this.isAwaiting = false;
	},
};
</script>

<style>
#href-fix {
	text-decoration: none;
	color: rgb(25, 131, 57);
}
</style>
