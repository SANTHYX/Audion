<template>
	<div>
		<v-container class="fill-height">
			<h2 class="display-2">Welcome in user Overview :{{ userName }}</h2>
		</v-container>
	</div>
</template>

<script>
import { mapActions } from 'vuex';

export default {
	props: {
		userName: {
			type: String,
			required: true,
		},
	},
	methods: {
		...mapActions({
			getUser: 'userStore/GET_USER',
		}),
	},
	async created() {
		await this.getUser(this.userName);
	},
};
</script>

<style></style>
