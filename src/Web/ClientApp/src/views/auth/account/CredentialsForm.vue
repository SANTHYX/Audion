<template>
	<v-container>
		<v-card class="mx-auto mt-12" max-width="600">
			<v-card-text>
				<v-text-field
					label="OldPassword"
					v-model="creedentialsObj.oldPassword"
					type="password"
					dense
					outlined
				/>
				<v-text-field
					label="NewPassword"
					v-model="creedentialsObj.newPassword"
					type="password"
					dense
					outlined
				/>
			</v-card-text>
			<v-card-actions class="justify-center">
				<v-btn class="success" width="150" min-width="100" dark>Change</v-btn>
			</v-card-actions>
		</v-card>
	</v-container>
</template>

<script>
export default {
	name: 'Credentials',
	props: {
		changeCreedentials: {
			required: true,
		},
	},
	data: () => ({
		creedentialsObj: {
			oldPassword: '',
			newPassword: '',
		},
		rules: [],
	}),
};
</script>

<style></style>
