<template>
	<v-container v-if="collection">
		<v-row dense>
			<h2>Results of searching Track "{{ $route.query.title }}"</h2>
			<v-spacer />
			<h3>Found Results: {{ totalResults }}</h3>
		</v-row>
		<v-divider class="my-2" />
		<v-container id="list-height">
			<v-card
				class="mt-5"
				v-for="item in collection"
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
					<v-btn color="orange" @click="isVisable = true">
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
		<v-pagination
			class="mt-15"
			v-show="!isCollectionEmpty"
			:length="totalPages"
			light
			@input="changePage"
			total-visible="5"
		/>
		<add-to-playlist-modal v-model="isVisable" />
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
		isCollectionEmpty() {
			return this.collection.length === 0;
		},

		...mapGetters(['track/GET_TRACKS_COLLECTION']),
	},
	data: () => ({
		isVisable: false,
	}),
	methods: {
		async changePage(page) {
			if (page <= this.totalPages || page >= 0) {
				await this['track/BROWSE_TRACKS'](this.$route.query);
				this.$router.replace({
					name: 'BrowseTracks',
					query: { ...this.$route.query, page },
				});
			}
		},
		...mapActions(['track/BROWSE_TRACKS']),
		...mapMutations(['track/REMOVE_TRACKS_COLLECTION']),
	},
	components: {
		AddToPlaylistModal: () => import('../components/AddToPlaylistModal.vue'),
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
