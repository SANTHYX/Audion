<template>
	<v-container>
		<v-row dense>
			<h2>Results of searching Track "{{ $route.query.title }}"</h2>
			<v-spacer />
			<h3>Found Results: {{ totalResults }}</h3>
		</v-row>
		<v-divider class="my-2" />
		<v-card class="mt-5" v-for="item in collection" :key="item.track">
			<v-card-title>
				<h3>{{ item.title }}</h3>
			</v-card-title>
			<v-card-actions>
				<v-spacer />
				<v-btn class="success" :to="{ name: 'Track', params: { id: item.id } }">
					Check
					<v-icon>mdi-play</v-icon>
				</v-btn>
			</v-card-actions>
		</v-card>
		<!-----------Have To do Pagiantion----------------->
		<v-pagination
			class="mt-15"
			:length="totalPages"
			total-visible="5"
			dark
			circle
		/>
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
		totalResults() {
			return this['track/GET_TRACKS_COLLECTION'].totalResults;
		},
		totalPages() {
			return this['track/GET_TRACKS_COLLECTION'].totalPages;
		},
		page() {
			return this['track/GET_TRACKS_COLLECTION'].page;
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
