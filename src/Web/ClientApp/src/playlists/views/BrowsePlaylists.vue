<template>
	<v-container v-if="collection">
		<v-row dense>
			<h2>Results of searching Playlist "{{ $route.query.name }}"</h2>
			<v-spacer />
			<h3>Found Results: {{ totalResults }}</h3>
		</v-row>
		<v-divider class="my-2" />
		<v-container class="collection-wraper">
			<browse-playlist-card
				v-for="playlist in collection"
				:key="playlist.id"
				:playlist="playlist"
				@open="$router.push({ name: 'Playlist', params: { id: playlist.id } })"
			/>
		</v-container>
		<pagination
			:totalPages="totalPages"
			:visablePages="5"
			@switchPage="changePage"
		/>
	</v-container>
</template>

<script>
import { mapActions, mapGetters, mapMutations } from 'vuex';
import Pagination from '../../commons/components/Pagination.vue';
import BrowsePlaylistCard from '../components/BrowsePlaylistCard.vue';

export default {
	name: 'BrowsePlaylists',
	computed: {
		collection() {
			return this['playlist/GET_PLAYLISTS_COLLECTION'].collection;
		},
		totalPages() {
			return this['playlist/GET_PLAYLISTS_COLLECTION'].totalPages;
		},
		totalResults() {
			return this['playlist/GET_PLAYLISTS_COLLECTION'].totalResults;
		},

		...mapGetters(['playlist/GET_PLAYLISTS_COLLECTION']),
	},
	methods: {
		changePage(page) {
			this.$router.replace({ query: { ...this.$route.query, page } });
		},

		...mapActions(['playlist/BROWSE_PLAYLISTS']),
		...mapMutations(['playlist/REMOVE_PLAYLISTS_COLLECTION']),
	},
	components: {
		Pagination,
		BrowsePlaylistCard,
	},
	async mounted() {
		await this['playlist/BROWSE_PLAYLISTS'](this.$route.query);
	},
	destroyed() {
		this['playlist/REMOVE_PLAYLISTS_COLLECTION']();
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
