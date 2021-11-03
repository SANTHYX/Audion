<template>
	<v-container> </v-container>
</template>

<script>
export default {
	name: 'DefaultBrowse',
	props: {
		browseDefaultAction: {
			type: Function,
			required: true,
		},
		defaultCollection: {
			type: Function,
		},
	},
	async mounted() {
		await this.browseDefaultAction(this.$route.query);
	},
	destroyed() {},
};
</script>

<style></style>
