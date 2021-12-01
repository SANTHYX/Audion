<template>
	<v-container>
		<h2>Results of searching Playlist {{ $route.query.name }}</h2>
		<v-divider class="my-2" />
	</v-container>
</template>

<script>
import { mapActions, mapGetters, mapMutations } from 'vuex';

export default {
	name: 'BrowsePlaylists',
	computed: {
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
