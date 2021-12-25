<template>
	<v-card class="mt-5" width="1300px">
		<v-card-title>
			<h3>{{ track.title }}</h3>
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
				class="ml-2 mb-5"
				color="orange"
				@click="openModal(track.id)"
				:disabled="!isAuthenticated"
				width="200px"
			>
				Add To Playlist
				<v-icon>mdi-plus</v-icon>
			</v-btn>
			<v-spacer />
			<v-btn class="success mr-2 mb-5" @click="check">
				Check
				<v-icon>mdi-play</v-icon>
			</v-btn>
		</v-card-actions>
	</v-card>
</template>

<script>
export default {
	name: 'TrackCard',
	props: {
		isAuthenticated: {
			type: Boolean,
		},
		track: {
			type: Object,
			required: true,
		},
	},
	data: () => ({
		isVisable: false,
	}),
	methods: {
		openModal(trackId) {
			this.$emit('openPlaylistsModal', trackId);
		},
		check() {
			this.$emit('check');
		},
	},
};
</script>

<style></style>
