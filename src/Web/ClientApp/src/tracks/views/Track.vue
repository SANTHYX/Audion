<template>
	<v-container v-if="trackURL">
		<h2>{{ track.title }}</h2>
		<audio-player :trackURL="trackURL" />
	</v-container>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';
import AudioPlayer from '../components/AudioPlayer.vue';

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

		...mapGetters(['track/GET_TRACK']),
	},
	methods: {
		...mapActions(['track/GET_TRACK_ASYNC']),
	},
	components: {
		AudioPlayer,
	},
	async created() {
		await this['track/GET_TRACK_ASYNC'](this.id);
	},
};
</script>

<style></style>
