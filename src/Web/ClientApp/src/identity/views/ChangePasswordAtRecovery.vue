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
				<v-btn @click="changePassword">Change</v-btn>
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
	data: () => ({
		newPassword: '',
		validationRules: {
			isRequired: (v) => !!v || 'This field is required',
		},
	}),
	methods: {
		async changePassword() {
			if (this.$refs.form.validate()) {
				const recoveryObj = {
					recoveryId: this.recoveryId,
					newPassword: this.newPassword,
				};
				await this['identity/SET_PASSWORD_AT_RECOVERY'](recoveryObj);
			} else return;
		},

		...mapActions(['identity/SET_PASSWORD_AT_RECOVERY']),
	},
};
</script>
