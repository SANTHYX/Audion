<template>
	<v-container> </v-container>
</template>

<script>
export default {
	name: 'DefaultBrowse',
	computed: {
		collection() {
			return this.defaultCollection.collection;
		},
	},
	props: {
		browseDefaultAction: {
			type: Function,
			required: true,
		},
		defaultCollection: {
			type: Object,
		},
	},
	async mounted() {
		await this.browseDefaultAction(this.$route.query);
	},
	destroyed() {},
};
</script>

<style></style>
