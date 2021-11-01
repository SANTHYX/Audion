<template>
	<v-container>
		<v-card>
			<v-card-text> </v-card-text>
		</v-card>
	</v-container>
</template>

<script>
export default {
	name: 'MyPlaylists',
	props: {
		playlistsList: {
			type: Object,
			default: null,
		},
	},
};
</script>

<style></style>
