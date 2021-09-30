<template>
	<v-dialog v-model="visable" max-width="700px" persistent>
		<v-card height="300px" @drop.prevent="retriveTrack" @dragover.prevent>
			<v-card-title>
				<h2>Upload Track</h2>
				<v-spacer />
				<v-icon @click="disableModal" color="red">mdi-close</v-icon>
			</v-card-title>
			<v-divider />
			<v-card-text v-if="!file">
				<v-row justify="center" class="mt-4">
					<p class="overline font-italic">
						Drag soundtrack that you wanna upload on server
					</p>
				</v-row>
				<v-row justify="center" class="mt-2">
					<v-icon size="120px">mdi-file</v-icon>
				</v-row>
				<v-row justify="center" class="mt-3">
					<h1 class="justify-center">UploadFile</h1>
				</v-row>
			</v-card-text>
			<v-card-text else> </v-card-text>
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
		file: null,
		error: {},
	}),
	methods: {
		retriveTrack(e) {
			let files = e.dataTransfer.files;
			if (files[0].type === 'audio/mp3' || files[0].type === 'audio/wav') {
				this.file = files[0];
			} else return;
		},
		loadMetadata() {},
		disableModal() {
			this.$emit('upload-modal-visibility', false);
			this.file = null;
			this.trackObj = {};
		},
	},
};
</script>
