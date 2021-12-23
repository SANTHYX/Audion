<template>
	<v-container>
		<v-flex>
			<v-layout justify-center>
				<v-row justify="center" class="my-4">
					<v-btn
						class="mx-4"
						:to="{
							name: 'BrowseTracks',
							query: {
								title: $route.query.title || $route.query.name,
								page: 1,
							},
						}"
						>Tracks
					</v-btn>
					<v-btn
						class="mx-4"
						:to="{
							name: 'BrowsePlaylists',
							query: { name: $route.query.title || $route.query.name, page: 1 },
						}"
					>
						Playlists
					</v-btn>
					<v-btn class="mx-4">Users</v-btn>
				</v-row>
			</v-layout>
		</v-flex>
		<router-view :isAuthenticated="isAuthenticated" />
	</v-container>
</template>

<script>
export default {
	name: 'Search',
	props: {
		isAuthenticated: {
			type: Boolean,
		},
	},
};
</script>

<style>
.menu {
	border: none;
}
</style>
