<template>
	<v-container id="register">
		<v-card class="mx-auto mt-12" max-width="600">
			<v-card-title class="justify-center">
				<h1 class="display-2">Register</h1>
			</v-card-title>
			<v-card-text>
				<v-form class="mt-4" ref="form">
					<v-text-field
						label="Login"
						prepend-inner-icon="mdi-account"
						outlined
						dense
						:rules="[validationRules.isRequired]"
						v-model="user.userName"
					/>
					<v-text-field
						label="Password"
						outlined
						dense
						prepend-inner-icon="mdi-form-textbox-password"
						type="password"
						:rules="[validationRules.isRequired]"
						v-model="user.password"
					/>
					<v-text-field
						label="E-mail"
						prepend-inner-icon="mdi-email"
						outlined
						dense
						:rules="[validationRules.isRequired, validationRules.isEmail]"
						v-model="user.email"
					/>
				</v-form>
			</v-card-text>
			<v-card-actions>
				<v-col>
					<v-row class="justify-center">
						<v-alert v-model="state.isThrown" border="bottom" type="error">
							{{ error.message }}
						</v-alert>
					</v-row>
					<v-row class="justify-center">
						<v-btn
							class="success"
							width="120"
							@click="registerUser"
							v-if="!state.isAwaiting"
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
		user: {
			userName: '',
			password: '',
			email: '',
		},
		error: {
			message: undefined,
		},
		state: {
			isAwaiting: false,
			isThrown: false,
		},
		validationRules: {
			isRequired: (v) => !!v || 'This field is required',
			isEmail: (v) => v.includes('@') || 'Value is not valid email',
		},
	}),
	methods: {
		async registerUser() {
			if (this.$refs.form.validate()) {
				this.await();
				await this['identity/REGISTER_USER'](this.user);
				this.$router.push({ name: 'Login' });
			} else return;
		},
		await() {
			this.state.isAwaiting = true;
			this.state.isThrown = false;
		},
		throw() {
			this.state.isAwaiting = false;
			this.state.isThrown = true;
		},
		...mapActions(['identity/REGISTER_USER']),
	},
	errorCaptured(err) {
		this.error.message = err.message || 'Error has occured';
		this.throw();
	},
};
</script>

<style></style>
