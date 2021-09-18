<template>
	<v-container id="profile-form">
		<v-card class="mx-auto mt-12" max-width="600">
			<v-card-text>
				<v-form class="mt-4">
					<v-text-field
						label="FirstName"
						v-model="profileObj.firstName"
						dense
						outlined
					/>
					<v-text-field
						label="LastName"
						v-model="profileObj.lastName"
						dense
						outlined
					/>
					<v-text-field label="City" v-model="profileObj.city" dense outlined />
				</v-form>
			</v-card-text>
			<v-card-actions class="justify-center">
				<v-btn class="success">Confirm</v-btn>
			</v-card-actions>
		</v-card>
	</v-container>
</template>

<script>
export default {
	name: 'profile-form',
	props: {
		updateProfileAction: {
			type: Function,
			required: true,
		},
	},
	data: () => ({
		profileObj: {
			firstName: '',
			lastName: '',
			city: '',
			country: '',
			postalCode: '',
		},
	}),
};
</script>

<style></style>
