<template>
	<v-container v-if="trackURL">
		<v-row dense justify="center">
			<v-card class="mb-2" width="1300px">
				<v-card-title>
					<h3 class="text-center">{{ track.title }}</h3>
				</v-card-title>
				<v-divider />
				<v-card-text>
					<v-row justify="space-beetwen">
						<v-chip class="ml-2 mt-2">
							Download
							<v-icon>mdi-download</v-icon>
						</v-chip>
						<v-spacer />
						<v-icon size="35px" class="mr-2 mt-2">mdi-heart</v-icon>
					</v-row>
					<v-row justify="center">
						<v-img
							dark
							gradient="to top right, rgba(100,115,201,.33), rgba(25,32,72,.7)"
							aspect-ratio="1.2"
							max-width="300px"
							height="300px"
							class="my-8"
						/>
					</v-row>
				</v-card-text>
			</v-card>
			<audio-player
				:trackURL="trackURL"
				@playPause="playPause"
				@loop="loop"
				@forward="forward"
				@previous="previous"
			/>
			<component />
			<comment-section>
				<comment />
			</comment-section>
		</v-row>
	</v-container>
</template>

<script>
import { mapGetters, mapActions, mapMutations } from 'vuex';
import AudioPlayer from '../components/AudioPlayer.vue';
import TrackDetails from '../components/TrackDetails.vue';
import CommentSection from '../components/CommentSection.vue';
import Comment from '../components/Comment.vue';

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
	data: () => ({
		isLooping: false,
	}),
	methods: {
		playPause(e) {
			e.paused ? e.play() : e.pause();
		},
		loop(e) {
			this.isLooping = !this.isLooping;
			e.loop = this.isLooping;
		},
		forward(e) {
			e.currentTime += 0.5;
		},
		previous(e) {
			e.currentTime -= 0.5;
		},

		...mapActions(['track/GET_TRACK_ASYNC']),
		...mapMutations(['track/REMOVE_TRACK']),
	},
	components: {
		AudioPlayer,
		TrackDetails,
		CommentSection,
		Comment,
	},
	async mounted() {
		await this['track/GET_TRACK_ASYNC'](this.id);
	},
	destroyed() {
		this['track/REMOVE_TRACK']();
	},
};
</script>

<style></style>
