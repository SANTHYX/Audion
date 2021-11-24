<template>
	<v-container>
		<h2>Results of searching phrase "{{ this.$route.query.phrase }}"</h2>
		<v-divider />
		<router-view
			:browseTrackAction="['track/BROWSE_TRACKS']"
			:browsePlaylistAction="['playlist/BROWSE_PLAYLISTS']"
			:tracksCollection="['track/GET_TRACKS_COLLECTION']"
			:playlistsCollection="['playlist/GET_PLAYLISTS_COLLECTION']"
			:removeTracksMethod="['track/REMOVE_TRACKS_COLLECTION']"
			:removePlaylistsMethod="['playlist/REMOVE_PLAYLISTS_COLLECTION']"
			:key="$route.fullPath"
		/>
	</v-container>
</template>

<script>
import { mapGetters, mapActions, mapMutations } from 'vuex';

export default {
	name: 'Search',
	computed: {
		...mapGetters([
			'track/GET_TRACKS_COLLECTION',
			'playlist/GET_PLAYLISTS_COLLECTION',
		]),
	},
	methods: {
		...mapMutations([
			'track/REMOVE_TRACKS_COLLECTION',
			'playlist/REMOVE_PLAYLISTS_COLLECTION',
		]),
		...mapActions(['track/BROWSE_TRACKS', 'playlist/BROWSE_PLAYLISTS']),
	},
};
</script>

<style></style>
