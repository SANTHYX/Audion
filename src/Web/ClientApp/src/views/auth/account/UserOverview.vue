<template>
	<div>
		<v-container class="fill-height">
			<h2 class="display-2">Welcome in user Overview :{{ user.userName }}</h2>
		</v-container>
	</div>
</template>

<script>
export default {
	name: 'AccountOverview',
	props: {
		user: {
			type: Object,
			required: true,
		},
	},
};
</script>

<style></style>
