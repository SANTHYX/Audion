<template>
	<div id="audio-player"></div>
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
