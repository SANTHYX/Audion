<template>
	<v-container>
		<v-row dense>
			<v-card width="455px" height="200px" id="create-playlist-card">
				<v-card-title class="justify-center">
					<h3 class="text-align-center">
						Do You Want To Create A New Playlist?
					</h3>
				</v-card-title>
				<v-card-actions class="justify-center">
					<v-btn
						:to="{ name: 'MakePlaylist', query: { redirect: $route.fullPath } }"
					>
						Create Playlist
					</v-btn>
				</v-card-actions>
			</v-card>
			<v-spacer />
			<v-card width="600px" height="600px" id="favorite-playlists">
				<v-card-title class="justify-center">
					<h3>Playlists</h3>
				</v-card-title>
				<v-divider />
				<v-card-text>
					<v-card
						class="mt-2"
						v-for="playlist in collection"
						:key="playlist.id"
					>
						<v-card-text>
							<h2>{{ playlist.name }}</h2>
						</v-card-text>
					</v-card>
				</v-card-text>
			</v-card>
		</v-row>
	</v-container>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';

export default {
	name: 'ManagePlaylists',
	computed: {
		collection() {
			return this['playlist/GET_PLAYLISTS_COLLECTION'].collection;
		},
		...mapGetters(['playlist/GET_PLAYLISTS_COLLECTION']),
	},
	methods: {
		...mapActions(['playlist/BROWSE_USER_PLAYLISTS']),
	},
	async mounted() {
		await this['playlist/BROWSE_USER_PLAYLISTS']({ page: 1 });
	},
};
</script>

<style></style>
