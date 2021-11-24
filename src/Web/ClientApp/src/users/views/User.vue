<template>
	<v-container id="user" v-show="!state.isLoading">
		<div v-if="Object.entries(this['user/USER']).length">
			{{ `Hi ${userName}` }}
		</div>
		<v-row class="justify-center" v-else>
			<v-icon size="120px">mdi-alert-circle</v-icon>
		</v-row>
	</v-container>
</template>

<script>
import { mapActions, mapMutations, mapGetters } from 'vuex';

export default {
	name: 'User',
	props: ['userName'],
	data: () => ({
		state: {
			isLoading: true,
		},
	}),
	computed: {
		...mapGetters(['user/USER']),
	},
	methods: {
		...mapActions(['user/GET_USER']),
		...mapMutations(['user/CLEAR_STATE']),
	},
	async created() {
		try {
			await this['user/GET_USER'](this.userName);
			this.state.isLoading = false;
		} catch (err) {
			this.state.isLoading = false;
		}
	},
	destroyed() {
		this['user/CLEAR_STATE']();
	},
};
</script>

<style></style>
