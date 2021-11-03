<template>
	<v-container> </v-container>
</template>

<script>
export default {
	name: 'TrackBrowse',
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
			type: Function,
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
