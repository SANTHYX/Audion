<template>
	<v-dialog :value="visable" max-width="800px" persistent>
		<v-card height="640px">
			<v-card-title>
				<h2>Add To Playlist</h2>
				<v-spacer />
				<v-icon :value="visable" @click="close" color="red">mdi-close</v-icon>
			</v-card-title>
			<v-divider />
			<v-card-subtitle class="mt-5">
				<v-row justify="center">
					<h3 class="mt-5">
						Choose any of your playlist that you wanna add this track
					</h3>
				</v-row>
			</v-card-subtitle>
			<v-card-text class="mt-5 border">
				<v-card max-width="150px" height="140px" class="mt-5">
					<v-card-title>hi</v-card-title>
				</v-card>
			</v-card-text>
		</v-card>
	</v-dialog>
</template>

<script>
export default {
	props: {
		visable: {
			type: Boolean,
			required: true,
		},
	},
	data: () => ({
		choosenPlaylists: {},
	}),
	model: {
		prop: 'visable',
		event: 'show',
	},
	methods: {
		close() {
			this.$emit('show', !this.visable);
		},
	},
};
</script>

<style>
.border {
	border: 1px rgb(214, 214, 214) solid;
}
</style>
