<template>
	<v-container> </v-container>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';

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
	methods: {
		...mapActions(['playlist/GET_PLAYLIST']),
	},
	async created() {
		await this['playlist/GET_PLAYLIST'](this.id);
	},
};
</script>

<style></style>
