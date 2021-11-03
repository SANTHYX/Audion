<template>
	<div id="audio-player">
		<v-card>
			<v-card-title> </v-card-title>
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
};
</script>

<style></style>
