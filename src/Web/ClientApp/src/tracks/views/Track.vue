<template>
	<v-container v-if="trackURL">
		<h2>{{ track.title }}</h2>
		<h3>{{ duration }}/{{ totalTime }}</h3>
		<audio-player :trackURL="trackURL" @playPause="playTrack" />
		<comment-section>
			<comment />
		</comment-section>
	</v-container>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';
import AudioPlayer from '../components/AudioPlayer.vue';
import CommentSection from '../components/CommentSection.vue';
import Comment from '../components/Comment.vue';
import trackManager from '../helpers/audioManager';

export default {
	name: 'Track',
	props: {
		id: {
			type: String,
			required: true,
		},
	},
	computed: {
		track() {
			return this['track/GET_TRACK'];
		},
		trackURL() {
			return this['track/GET_TRACK'].track;
		},
		audio() {
			return trackManager.getAudio();
		},
		totalTime() {
			return this.audio.currentTime;
		},

		...mapGetters(['track/GET_TRACK']),
	},
	methods: {
		playTrack() {
			this.audio.volume = 0.2;
			this.audio.play();
		},

		...mapActions(['track/GET_TRACK_ASYNC']),
	},
	components: {
		AudioPlayer,
		CommentSection,
		Comment,
	},
	async mounted() {
		await this['track/GET_TRACK_ASYNC'](this.id);
		trackManager.loadAudio(this.trackURL);
	},
};
</script>

<style></style>
