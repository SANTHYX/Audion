<template>
	<v-container> </v-container>
</template>

<script>
export default {
	name: 'PlaylistBrowse',
	props: {
		browsePlaylistAction: {
			type: Function,
			required: true,
		},
		removePlaylistsMethod: {
			type: Function,
			required: true,
		},
		playlistsCollection: {
			type: Function,
		},
	},
	async mounted() {
		await this.browsePlaylistAction(this.$route.query);
	},
	destroyed() {
		this.removePlaylistMethod();
	},
};
</script>

<style></style>
