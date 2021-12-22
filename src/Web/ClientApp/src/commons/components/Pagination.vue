<template>
	<v-pagination
		class="mt-15"
		:length="totalPages"
		@input="switchPage"
		v-model="currentPage"
		total-visible="5"
		light
	/>
</template>

<script>
export default {
	props: {
		totalPages: {
			type: Number,
			required: true,
		},
		visablePages: {
			type: Number,
			required: true,
		},
	},
	data: () => ({
		currentPage: 0,
	}),
	methods: {
		switchPage() {
			this.$emit('switchPage', this.currentPage);
		},
	},
};
</script>

<style></style>
