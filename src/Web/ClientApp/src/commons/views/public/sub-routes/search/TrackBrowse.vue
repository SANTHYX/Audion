<template>
	<v-container> </v-container>
</template>

<script>
export default {
	name: 'TrackBrowse',
	computed: {
		collection() {
			return this.tracksCollection.collection;
		},
	},
	props: {
		browseTrackAction: {
			type: Function,
			required: true,
		},
		removeTracksMethod: {
			type: Function,
			required: true,
		},
		tracksCollection: {
			type: Object,
		},
	},
	async mounted() {
		await this.browseTrackAction(this.$route.query);
	},
	destroyed() {
		this.removeTrackMethod();
	},
};
</script>

<style></style>
