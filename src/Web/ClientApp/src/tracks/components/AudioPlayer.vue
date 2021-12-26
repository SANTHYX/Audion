<template>
	<div id="audio-player">
		<v-card>
			<v-card-title>
				<v-spacer />
				<v-btn class="mx-1" @click="previous">
					<v-icon>mdi-previous</v-icon>
				</v-btn>
				<v-btn class="mx-1" @click="playPause">
					<v-icon color="green">mdi-play</v-icon>
				</v-btn>
				<v-btn class="mx-1" @click="next"></v-btn>
				<v-slider
					class="audio-slider"
					min="0"
					max="1"
					step="0.01"
					v-model="volume"
					dense
				/>
			</v-card-title>
		</v-card>
	</div>
</template>

<script>
export default {
	name: 'AudioPlayer',
	props: {
		trackURL: {
			type: String,
			required: true,
		},
	},
	data: () => ({
		volume: 0.5,
	}),
	methods: {
		previous() {
			this.$emit('previous');
		},
		playPause() {
			this.$emit('playPause');
		},
		next() {
			this.$emit('next');
		},
	},
};
</script>

<style></style>
