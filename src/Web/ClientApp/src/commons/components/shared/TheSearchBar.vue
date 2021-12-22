<template>
	<v-row class="align-center">
		<v-text-field
			class="mt-6"
			color="green"
			placeholder="Search..."
			v-model="title"
			filled
			outlined
			dense
			@keypress.enter="search"
		/>
		<v-btn color="blue" @click="search" replace>
			<v-icon>mdi-magnify</v-icon>
		</v-btn>
	</v-row>
</template>

<script>
export default {
	name: 'TheSearchBar',
	computed: {
		isNotEmptyPhrase() {
			return this.title !== '';
		},
	},
	data: () => ({
		title: '',
	}),
	methods: {
		search() {
			if (this.isNotEmptyPhrase) {
				this.$router.push({
					name: 'BrowseTracks',
					query: { title: this.title, page: 1 },
				});
			}
			return;
		},
	},
};
</script>

<style></style>
