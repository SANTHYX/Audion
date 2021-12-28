<template>
	<v-container v-if="trackURL">
		<v-row dense justify="center">
			<v-card class="mb-2 mt-5" width="1300px">
				<v-card-title>
					<h3 class="text-center">{{ track.title }}</h3>
				</v-card-title>
				<v-divider />
				<v-card-text>
					<v-row justify="space-between">
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
			<v-tabs class="mt-5" center-active centered>
				<v-tab @click="currentTab = 'TracksList'">Comments</v-tab>
				<v-tab @click="currentTab = 'CommentSection'">Comments</v-tab>
				<v-tab @click="currentTab = 'Equalizer'">Equalizer</v-tab>
			</v-tabs>
			<component class="mt-2" :is="currentTab" />
		</v-row>
	</v-container>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';
import AudioPlayer from '../../tracks/components/AudioPlayer.vue';
import TracksList from '../../playlists/components/TracksList.vue';
import CommentSection from '../../tracks/components/CommentSection.vue';
import Equalizer from '../../tracks/components/Equalizer.vue';

export default {
	name: 'Playlist',
	props: {
		id: {
			type: String,
			required: true,
		},
	},
	computed: {
		...mapGetters(['playlist/PLAYLIST']),
	},
	data: () => ({
		currentTab: 'TracksList',
		currentTrack:
	}),
	methods: {
		...mapActions(['playlist/GET_PLAYLIST']),
	},
	components: {
		AudioPlayer,
		TracksList,
		CommentSection,
		Equalizer,
	},
	async created() {
		await this['playlist/GET_PLAYLIST'](this.id);
	},
};
</script>

<style></style>
