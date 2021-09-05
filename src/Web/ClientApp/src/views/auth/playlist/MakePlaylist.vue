<template>
	<v-container>
		<v-card>
			<v-card-title>
				<h2 class="display-2">Make Playlist</h2>
			</v-card-title>
			<v-card-text>
				<v-text-field label="Track" />
				<v-textarea label="Description" />
			</v-card-text>
			<v-card-actions>
				<v-btn width="120">
					Submit
				</v-btn>
			</v-card-actions>
		</v-card>
	</v-container>
</template>

<script>
export default {
	data: () => ({
		playlistObj: {},
		rules: [],
	}),
	methods: {},
};
</script>

<style></style>
