<template>
	<v-card width="1300px">
		<v-card-title>
			<h3>
				{{ getCurrentPos | toMinutesAndSeconds }} /
				{{ duration | toMinutesAndSeconds }}
			</h3>
			<v-spacer />
			<v-btn @click="loop">
				<v-icon :color="state.isLooping ? 'red' : 'green'">mdi-reload</v-icon>
			</v-btn>
		</v-card-title>
		<v-card-text>
			<v-slider
				class="audio-slider"
				height="40px"
				:min="0.000001"
				:max="duration"
				step="0.00000001"
				v-model="audio.currentTime"
				dense
			/>
		</v-card-text>
		<v-card-actions>
			<v-btn class="mx-1" @click="previous">
				<v-icon color="green">mdi-skip-previous</v-icon>
			</v-btn>
			<v-btn class="mx-1" @click="playPause">
				<v-icon color="green" v-show="!isPlaying">mdi-play</v-icon>
				<v-icon color="red" v-show="isPlaying">mdi-pause</v-icon>
			</v-btn>
			<v-btn class="mx-1" @mousedown="forward">
				<v-icon color="green">mdi-skip-next</v-icon>
			</v-btn>
			<v-spacer />
			<div class="fix">
				<v-slider
					prepend-icon="mdi-volume-high"
					v-model="audio.volume"
					min="0"
					max="0.7"
					value="0.2"
					step="0.01"
				/>
			</div>
		</v-card-actions>
	</v-card>
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
	filters: {
		toMinutesAndSeconds(position) {
			let minutes = Math.floor(position / 60);
			let seconds = (position % 60).toFixed(0);

			return `${minutes}:${seconds < 10 ? '0' : ''}${seconds}`;
		},
	},
	watch: {
		currentPosition(val) {
			if (this.currentDuration === val) {
				this.state.isPlaying = false;
			}
		},
	},
	computed: {
		isPlaying() {
			return this.state.isPlaying;
		},
		volume() {
			return this.audio.volume;
		},
		duration() {
			return this.currentDuration;
		},
		getCurrentPos() {
			return this.currentPosition;
		},
	},
	data: () => ({
		audio: new Audio(),
		currentPosition: 0,
		currentDuration: 0,
		state: {
			isPlaying: false,
			isLooping: false,
		},
	}),
	methods: {
		previous() {
			this.$emit('previous', this.audio);
		},
		playPause() {
			this.currentDuration = this.audio.duration;
			this.$emit('playPause', this.audio);
			this.state.isPlaying = !this.state.isPlaying;
		},
		forward() {
			this.$emit('forward', this.audio);
		},
		loop() {
			this.$emit('loop', this.audio);
			this.state.isLooping = !this.state.isLooping;
		},
		getCurrentPosition() {
			this.audio.ontimeupdate = () => {
				this.currentPosition = this.audio.currentTime;
			};
		},
	},
	mounted() {
		this.audio.src = this.trackURL;
		this.audio.volume = 0.3;
		this.getCurrentPosition();
	},
	destroyed() {
		this.audio.load();
	},
};
</script>

<style>
.fix {
	margin-top: 25px;
	margin-right: 3px;
	width: 170px;
	display: flex;
	align-items: flex-end;
}
</style>
