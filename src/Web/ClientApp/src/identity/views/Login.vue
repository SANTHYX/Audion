<template>
	<v-container id="login">
		<v-card class="mx-auto mt-12" max-width="600">
			<v-card-title class="justify-center">
				<h1 class="display-2">Login</h1>
			</v-card-title>
			<v-card-text>
				<v-form class="mt-4" ref="form">
					<v-text-field
						label="Login"
						prepend-inner-icon="mdi-account"
						outlined
						dense
						:rules="[validationRules.isRequired]"
						v-model="creedentials.userName"
					/>
					<v-text-field
						label="Password"
						prepend-inner-icon="mdi-form-textbox-password"
						outlined
						dense
						:rules="[validationRules.isRequired]"
						v-model="creedentials.password"
						type="password"
					/>
				</v-form>
			</v-card-text>
			<v-card-actions>
				<v-col>
					<!------------- ErrorsAlertRow -------------->
					<v-row class="justify-center">
						<v-alert v-model="state.isThrown" border="bottom" type="error">
							{{ error.message }}
						</v-alert>
					</v-row>
					<!------------- ButtonRow -------------->
					<v-row class="justify-center">
						<v-btn
							class="success"
							width="120"
							@click="loginUser"
							v-if="!state.isAwaiting"
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
		},
		state: {
			isAwaiting: false,
			isThrown: false,
		},
		validationRules: {
			isRequired: (v) => !!v || 'This field is required',
		},
	}),
	methods: {
		async loginUser() {
			if (this.$refs.form.validate()) {
				this.await();
				await this['identity/LOGIN_USER'](this.creedentials);
				this.$router.push(this.$route.query.redirect || '/');
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
		...mapActions(['identity/LOGIN_USER']),
	},
	errorCaptured(err) {
		this.error.message = err.message || 'Error has occured';
		this.throw();
	},
};
</script>

<style>
#href-fix {
	text-decoration: none;
	color: rgb(25, 131, 57);
}
</style>
