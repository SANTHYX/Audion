<template>
	<v-container>
		<h2>Results of searching phrase "{{ this.$route.query.phrase }}"</h2>
		<v-divider />
	</v-container>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';

export default {
	name: 'SearchResults',
	computed: {
		...mapGetters('track', ['GET_TRACKS_COLLECTION']),
	},
	methods: {
		...mapActions('track', ['BROWSE_TRACKS', 'GET_TRACK']),
	},
	async created() {
		await this.BROWSE_TRACKS(this.$route.query);
	},
};
</script>

<style></style>
