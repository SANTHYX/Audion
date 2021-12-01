<template>
	<v-container>
		<h2>Results of searching Track {{ $route.query.name }}</h2>
		<v-divider class="my-2" />
	</v-container>
</template>

<script>
import { mapActions, mapGetters, mapMutations } from 'vuex';

export default {
	name: 'BrowseTracks',
	computed: {
		collection() {
			return this['track/GET_TRACKS_COLLECTION'].collection;
		},

		...mapGetters(['track/GET_TRACKS_COLLECTION']),
	},
	methods: {
		...mapActions(['track/BROWSE_TRACKS']),
		...mapMutations(['track/REMOVE_TRACKS_COLLECTION']),
	},
	async mounted() {
		await this['track/BROWSE_TRACKS'](this.$route.query);
	},
	destroyed() {
		this['track/REMOVE_TRACKS_COLLECTION']();
	},
};
</script>

<style></style>
