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
			<v-card-text v-if="!file" id="drag-interface">
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
				<h2>{{ trackTags.title }}</h2>
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
		trackTags: {
			title: '',
			artist: '',
			genre: '',
			artwork: '',
		},
		state: {
			isThrow: false,
			isDraged: false,
		},
		file: null,
	}),
	methods: {
		retriveTrack(e) {
			this.state.isDraged = false;
			let files = e.dataTransfer.files;
			if (files[0].type === 'audio/mp3' || files[0].type === 'audio/wav') {
				this.file = files[0];
				this.loadMetadata(this.file);
			} else {
				this.state.isThrow = true;
				return;
			}
			this.state.isThrow = false;
		},
		loadMetadata(file) {
			file;
		},
		disableModal() {
			this.$emit('upload-modal-visibility', false);
			this.state.isThrow = false;
			this.file = null;
			this.trackTags = {};
		},
	},
};
</script>
<style scoped>
.dotted {
	border: 2px gray dotted;
}
</style>
