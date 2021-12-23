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
				<v-card-text> </v-card-text>
			</v-card>
		</v-row>
	</v-container>
</template>

<script>
export default {
	name: 'ManageTracks',
};
</script>

<style></style>
