<template>
	<v-container v-show="!state.isLoading">
		<v-card>
			<v-card-text>
				<h2 class="display-2">Welcome in user Overview :{{ user.userName }}</h2>
			</v-card-text>
		</v-card>
	</v-container>
</template>

<script>
export default {
	name: 'AccountOverview',
	props: {
		user: {
			type: Object,
			required: true,
		},
		userName: {
			type: String,
			required: true,
		},
		fetchUserAction: {
			required: true,
		},
		clearStateMutation: {
			required: true,
		},
	},
	data: () => ({
		state: {
			isLoading: true,
		},
	}),
	async mounted() {
		try {
			await this.fetchUserAction(this.userName);
			this.state.isLoading = false;
		} catch (err) {
			this.state.isLoading = false;
		}
	},
	destroyed() {
		this.clearStateMutation();
	},
};
</script>

<style></style>
