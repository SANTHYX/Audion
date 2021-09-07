<template>
	<div>
		<v-container class="fill-height">
			<h2 class="display-2">Welcome in user Overview :{{ 'XDDD' }}</h2>
		</v-container>
	</div>
</template>

<script>
import { mapActions } from 'vuex';

export default {
	methods: {
		...mapActions({
			getUser: 'userStore/GET_USER',
		}),
	},
};
</script>

<style></style>
