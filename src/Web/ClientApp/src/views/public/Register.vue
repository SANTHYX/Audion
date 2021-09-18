<template>
	<v-container id="register">
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
						v-model="userObj.userName"
					/>
					<v-text-field
						label="Password"
						outlined
						dense
						prepend-inner-icon="mdi-form-textbox-password"
						type="password"
						v-model="userObj.password"
					/>
					<v-text-field
						label="E-mail"
						prepend-inner-icon="mdi-email"
						outlined
						dense
						v-model="userObj.email"
					/>
				</v-form>
			</v-card-text>
			<v-card-actions>
				<v-col>
					<v-row class="justify-center">
						<v-alert v-model="error.isThrown" border="bottom" type="error">
							{{ error.message }}
						</v-alert>
					</v-row>
					<v-row class="justify-center">
						<v-btn
							class="success"
							width="120"
							@click="registerUser"
							v-if="!isAwaiting"
						>
							Register
						</v-btn>
						<v-progress-circular indeterminate color="green" v-else />
					</v-row>
				</v-col>
			</v-card-actions>
		</v-card>
	</v-container>
</template>

<script>
import { mapActions } from 'vuex';

export default {
	name: 'Register',
	data: () => ({
		userObj: {
			userName: '',
			password: '',
			email: '',
		},
		error: {
			message: undefined,
			isThrown: false,
		},
		validationRules: [],
		isAwaiting: false,
	}),
	methods: {
		async registerUser() {
			this.isAwaiting = true;
			this.error.isThrown = false;
			await this['identityStore/REGISTER_USER'](this.userObj);
			this.$router.push('/');
		},
		...mapActions(['identityStore/REGISTER_USER']),
	},
	errorCaptured(err) {
		this.error.message = err.message;
		this.error.isThrown = true;
		this.isAwaiting = false;
	},
};
</script>

<style></style>
