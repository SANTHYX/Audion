<template>
	<v-container>
		<v-row dense>
			<h2>Results of searching Playlist "{{ $route.query.name }}"</h2>
			<v-spacer />
			<h3>Found Results: {{ totalResults }}</h3>
		</v-row>
		<v-divider class="my-2" />
		<v-container> </v-container>
	</v-container>
</template>

<script>
import { mapActions, mapGetters, mapMutations } from 'vuex';

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
		...mapActions(['playlist/BROWSE_PLAYLISTS']),
		...mapMutations(['playlist/REMOVE_PLAYLISTS_COLLECTION']),
	},
	async mounted() {
		await this['playlist/BROWSE_PLAYLISTS'](this.$route.query);
	},
	destroyed() {
		this['playlist/REMOVE_PLAYLISTS_COLLECTION']();
	},
};
</script>
