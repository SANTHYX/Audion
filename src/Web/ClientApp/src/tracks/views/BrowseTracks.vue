<template>
	<v-container v-if="tracksCollection">
		<v-row dense>
			<h2>Results of searching Track "{{ $route.query.title }}"</h2>
			<v-spacer />
			<h3>Found Results: {{ tracksTotalResults }}</h3>
		</v-row>
		<v-divider class="my-2" />
		<v-container id="list-height">
			<v-card
				class="mt-5"
				v-for="item in tracksCollection"
				:key="item.track"
				width="1300px"
			>
				<v-card-title>
					<h3>{{ item.title }}</h3>
				</v-card-title>
				<v-card-text>
					<v-img
						dark
						gradient="to top right, rgba(100,115,201,.33), rgba(25,32,72,.7)"
						aspect-ratio="1"
						max-width="200px"
					/>
					<v-spacer />
				</v-card-text>
				<v-card-actions>
					<v-btn
						class="ml-2"
						color="orange"
						@click="openPlaylistsModal(item.id)"
						:disabled="!isAuthenticated"
						width="200px"
					>
						Add To Playlist
						<v-icon>mdi-plus</v-icon>
					</v-btn>
					<v-spacer />
					<v-btn
						class="success"
						:to="{ name: 'Track', params: { id: item.id } }"
					>
						Check
						<v-icon>mdi-play</v-icon>
					</v-btn>
				</v-card-actions>
			</v-card>
		</v-container>
		<pagination
			:totalPages="tracksTotalPages"
			:visablePages="5"
			@switchPage="changePage($event)"
		/>
		<add-to-playlist-modal
			v-if="isAuthenticated"
			v-model="isVisable"
			:collection="playlistsCollection"
			@switchPage="changeModalPage($event)"
		/>
	</v-container>
</template>

<script>
import { mapActions, mapGetters, mapMutations } from 'vuex';
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
			await this['track/BROWSE_TRACKS'](this.$route.query);
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
#list-height {
	display: flex;
	flex-direction: column;
	align-items: center;
	min-height: 64vh;
}
</style>
