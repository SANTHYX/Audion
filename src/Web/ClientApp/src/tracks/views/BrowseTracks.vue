<template>
	<v-container v-if="tracksCollection">
		<v-row dense>
			<h2>Results of searching Track "{{ $route.query.title }}"</h2>
			<v-spacer />
			<h3>Found Results: {{ tracksTotalResults }}</h3>
		</v-row>
		<v-divider class="my-2" />
		<v-container class="collection-wraper">
			<browse-track-card
				v-for="track in tracksCollection"
				:key="track.id"
				:isAuthenticated="isAuthenticated"
				:track="track"
				@openPlaylistsModal="openPlaylistsModal"
				@check="$router.push({ name: 'Track', params: { id: track.id } })"
			/>
		</v-container>
		<pagination
			:totalPages="tracksTotalPages"
			:visablePages="5"
			@switchPage="changePage"
		/>
		<add-to-playlist-modal
			v-model="isVisable"
			:collection="playlistsCollection"
			@switchPage="changeModalPage"
		/>
	</v-container>
</template>

<script>
import { mapActions, mapGetters, mapMutations } from 'vuex';
import BrowseTrackCard from '../components/BrowseTrackCard.vue';
import Pagination from '@/commons/components/Pagination.vue';

export default {
	name: 'BrowseTracks',
	props: {
		isAuthenticated: {
			type: Boolean,
		},
	},
	computed: {
		tracksCollection() {
			return this['track/GET_TRACKS_COLLECTION'].collection;
		},
		tracksTotalResults() {
			return this['track/GET_TRACKS_COLLECTION'].totalResults;
		},
		tracksTotalPages() {
			return this['track/GET_TRACKS_COLLECTION'].totalPages;
		},
		playlistsCollection() {
			return this['playlist/GET_PLAYLISTS_COLLECTION'].collection;
		},

		...mapGetters([
			'track/GET_TRACKS_COLLECTION',
			'playlist/GET_PLAYLISTS_COLLECTION',
		]),
	},
	data: () => ({
		trackId: '',
		isVisable: false,
	}),
	methods: {
		async changePage(page) {
			this.$router.replace({ query: { ...this.$route.query, page } });
		},
		async changeModalPage(page) {
			await this['playlist/BROWSE_USER_PLAYLISTS']({ page });
		},
		openPlaylistsModal(id) {
			this.isVisable = true;
			this.trackId = id;
		},

		...mapActions(['track/BROWSE_TRACKS', 'playlist/BROWSE_USER_PLAYLISTS']),
		...mapMutations(['track/REMOVE_TRACKS_COLLECTION']),
	},
	components: {
		AddToPlaylistModal: () => import('../components/AddToPlaylistModal.vue'),
		BrowseTrackCard,
		Pagination,
	},
	async mounted() {
		await this['track/BROWSE_TRACKS'](this.$route.query);
	},
	destroyed() {
		this['track/REMOVE_TRACKS_COLLECTION']();
	},
};
</script>

<style>
.collection-wraper {
	display: flex;
	flex-direction: column;
	align-items: center;
	min-height: 64vh;
}
</style>
