<template>
	<v-container id="user"> </v-container>
</template>

<script>
import { mapActions, mapGetters } from 'vuex';

export default {
	name: 'User',
	props: {
		userName: {
			type: String,
			required: true,
		},
	},
	computed: {
		...mapGetters(['userStore/USER']),
	},
	methods: {
		...mapActions(['userStore/GET_USER']),
	},
	async mounted() {
		await this['userStore/GET_USER'](this.userName);
	},
};
</script>

<style></style>
