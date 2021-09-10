<template>
	<v-container id="user"> </v-container>
</template>

<script>
export default {
	name: 'User',
	props: {
		userName: {
			type: String,
			required: true,
		},
	},
};
</script>

<style></style>
