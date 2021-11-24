<template>
	<v-row class="align-center">
		<v-text-field
			class="mt-6"
			color="green"
			placeholder="Search..."
			v-model="searchPhrase"
			filled
			outlined
			dense
			@keypress.enter="
				$router.push({ name: 'SearchResults', query: { phrase: searchPhrase } })
			"
		/>
		<v-btn
			color="blue"
			:to="{ name: 'SearchResults', query: { phrase: searchPhrase } }"
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
		searchPhrase: '',
	}),
};
</script>

<style></style>
