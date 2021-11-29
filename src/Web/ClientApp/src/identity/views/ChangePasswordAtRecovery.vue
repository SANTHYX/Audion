<template>
	<v-container>
		<v-card class="mx-auto mt-12" max-width="600">
			<v-card-title class="justify-center">
				<h1 class="display-2">Change Your Password</h1>
			</v-card-title>
			<v-card-text>
				<v-form class="mt-4" ref="form">
					<v-text-field
						v-model="newPassword"
						:rules="[validationRules.isRequired]"
						type="password"
						dense
					/>
				</v-form>
			</v-card-text>
			<v-card-actions>
				<v-row justify="center">
					<v-btn @click="changePassword" class="success" :disabled="isFormValid"
						>Change
					</v-btn>
				</v-row>
			</v-card-actions>
		</v-card>
	</v-container>
</template>

<script>
import { mapActions } from 'vuex';

export default {
	name: 'ChangePasswordAtRecovery',
	props: {
		recoveryId: {
			type: String,
			required: true,
		},
	},
	computed: {
		isFormValid() {
			return this.$refs.form.validate();
		},
	},
	data: () => ({
		newPassword: '',
		validationRules: {
			isRequired: (v) => !!v || 'This field is required',
		},
	}),
	methods: {
		async changePassword() {
			const recoveryObj = {
				recoveryId: this.recoveryId,
				newPassword: this.newPassword,
			};
			await this['identity/SET_PASSWORD_AT_RECOVERY'](recoveryObj);
		},

		...mapActions(['identity/SET_PASSWORD_AT_RECOVERY']),
	},
};
</script>
