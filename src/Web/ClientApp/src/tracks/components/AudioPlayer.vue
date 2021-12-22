<template>
	<div id="audio-player">
		<v-card>
			<v-card-title>
				<v-spacer />
				<v-btn @click="previous">
					<v-icon>mdi-previous</v-icon>
				</v-btn>
				<v-btn @click="play">
					<v-icon v-if="!isPlaying" color="green">mdi-play</v-icon>
					<v-icon v-else color="red">mdi-pause</v-icon>
				</v-btn>
				<v-btn @click="next"></v-btn>
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
		isPlaying: false,
	}),
	methods: {
		previous() {
			this.$emit('previous');
		},
		play() {
			this.$emit('play');
		},
		next() {
			this.$emit('next');
		},
	},
};
</script>

<style></style>
