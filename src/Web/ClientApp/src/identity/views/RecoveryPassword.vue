<template>
	<v-container>
		<v-card class="mx-auto mt-12" max-width="600">
			<v-card-title class="justify-center">
				<h1 class="display-2">Change Your Password</h1>
			</v-card-title>
			<v-card-text>
				<v-form class="mt-4" ref="form">
					<v-text-field
						v-model="email"
						:rules="[validationRules.isEmail]"
						dense
					/>
				</v-form>
			</v-card-text>
			<v-card-actions>
				<v-row justify="center">
					<v-btn
						@click="recoveryPassword"
						class="success"
						:disabled="isFormValid"
						>Recover Password</v-btn
					>
				</v-row>
			</v-card-actions>
		</v-card>
	</v-container>
</template>

<script>
import { mapActions } from 'vuex';

export default {
	name: 'PasswordRecovery',
	computed: {
		isFormValid() {
			return this.$refs.form.validate();
		},
	},
	data: () => ({
		email: '',
		validationRules: {
			isEmail: (v) => v.includes('@') || 'Value is not valid email',
		},
	}),
	methods: {
		async recoveryPassword() {
			const emailObj = {
				email: this.email,
			};
			await this['identity/RECOVERY_PASSWORD'](emailObj);
		},
		...mapActions(['identity/RECOVERY_PASSWORD']),
	},
};
</script>

<style></style>
