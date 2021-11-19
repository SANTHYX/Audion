<template>
	<v-container> </v-container>
</template>

<script>
export default {
	name: 'PlaylistBrowse',
	computed: {
		collection() {
			return this.playlistsCollection.collection;
		},
	},
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
			type: Object,
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
