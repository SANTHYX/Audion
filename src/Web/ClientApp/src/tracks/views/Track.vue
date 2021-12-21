<template>
	<v-container>
		<h2>{{ track.title }}</h2>
	</v-container>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';

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
		...mapGetters(['track/GET_TRACK']),
	},
	methods: {
		...mapActions(['track/GET_TRACK_ASYNC']),
	},
	async created() {
		await this['track/GET_TRACK_ASYNC'](this.id);
	},
};
</script>

<style></style>
