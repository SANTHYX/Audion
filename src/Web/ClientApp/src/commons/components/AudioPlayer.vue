<template>
	<div id="audio-player">
		<v-card>
			<v-card-title>
				<v-btn @click="previous"></v-btn>
				<v-btn @click="play"></v-btn>
				<v-btn @click="next"></v-btn>
			</v-card-title>
		</v-card>
	</div>
</template>

<script>
export default {
	name: 'AudioPlayer',
	props: {
		track: {
			type: File,
			required: true,
		},
	},
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
