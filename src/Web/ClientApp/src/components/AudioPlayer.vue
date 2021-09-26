<template>
	<div id="audio-player">
		<v-card>

		</v-card>
	</div>
</template>

<script>
export default {
	name: 'audio-player',
	props: {
		track: {
			type: File,
			required: true,
		},
	},
};
</script>

<style></style>
