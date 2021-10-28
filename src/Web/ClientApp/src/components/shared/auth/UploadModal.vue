<template>
	<v-dialog v-model="visable" max-width="700px" persistent>
		<v-card
			min-height="370px"
			@drop.prevent="retriveTrack"
			@dragover.prevent="state.isDraged = true"
			@dragleave="state.isDraged = false"
		>
			<v-card-title>
				<h2>Upload Track</h2>
				<v-spacer />
				<v-icon @click="disableModal" color="red">mdi-close</v-icon>
			</v-card-title>
			<v-divider />
			<v-card-text v-if="!track.file" id="drag-interface">
				<v-row justify="center" class="mt-5 pa-5 dotted">
					<v-col>
						<p class="overline font-italic text-center">
							Drag soundtrack that you wanna upload on server
						</p>
						<v-row justify="center" align="center">
							<v-icon size="120px">mdi-file</v-icon>
							<h1 class="justify-center">UploadFile</h1>
						</v-row>
					</v-col>
				</v-row>
			</v-card-text>
			<v-card-text v-else>
				<h2 class="mt-3 text-center">{{ track.name }}</h2>
				<v-row justify="center" class="mt-2">
					<v-img
						dark
						gradient="to top right, rgba(100,115,201,.33), rgba(25,32,72,.7)"
						aspect-ratio="1.2"
						max-width="300px"
					/>
				</v-row>
				<v-row justify="center" class="mt-7">
					<v-btn class="success" @click="uploadTrackAction(track)">
						Upload
					</v-btn>
				</v-row>
			</v-card-text>
			<v-card-actions class="justify-center" id="error">
				<v-alert v-model="state.isThrow" type="error" dense>
					<p class="text-center align-center">
						Invalid type of file, this file is not .mp3 or .wav
					</p>
				</v-alert>
			</v-card-actions>
			<v-overlay :value="state.isDraged" :absolute="true" />
		</v-card>
	</v-dialog>
</template>

<script>
export default {
	name: 'UploadModal',
	props: ['visable', 'uploadTrackAction'],
	data: () => ({
		track: {
			name: '',
			file: null,
		},
		state: {
			isThrow: false,
			isDraged: false,
		},
	}),
	methods: {
		retriveTrack(e) {
			this.state.isDraged = false;
			let file = e.dataTransfer.files[0];
			if (this.isValidType(file)) {
				this.setTrack(file);
			} else {
				this.state.isThrow = true;
				return;
			}
			this.state.isThrow = false;
		},
		setTrack(file) {
			this.track.name = file.name;
			this.track.file = file;
		},
		isValidType(file) {
			return file.type === 'audio/mpeg' || file.type === 'audio/wav';
		},
		disableModal() {
			this.$emit('upload-modal-visibility', false);
			this.state.isThrow = false;
			this.track = {};
		},
	},
};
</script>

<style scoped>
.dotted {
	border: 2px gray dotted;
}
</style>
