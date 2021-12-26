<template>
	<v-card>
		<v-card-title>
			<h2>{{ user.userName }}</h2>
		</v-card-title>
		<v-card-actions>
			<v-spacer />
			<v-btn @click="check">Check</v-btn>
		</v-card-actions>
	</v-card>
</template>

<script>
export default {
	name: 'BrowseUserCard',
	props: {
		user: {
			type: Object,
			required: true,
		},
	},
	methods: {
		check() {
			this.$emit('check');
		},
	},
};
</script>

<style></style>
