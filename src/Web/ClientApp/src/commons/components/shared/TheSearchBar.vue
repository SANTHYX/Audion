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
			@keypress.enter="
				$router.push({ name: 'BrowseTracks', query: { title: title, page: 1 } })
			"
		/>
		<v-btn
			color="blue"
			:to="{ name: 'BrowseTracks', query: { title: title, page: 1 } }"
			replace
		>
			<v-icon>mdi-magnify</v-icon>
		</v-btn>
	</v-row>
</template>

<script>
export default {
	name: 'TheSearchBar',
	data: () => ({
		title: '',
	}),
};
</script>

<style></style>
