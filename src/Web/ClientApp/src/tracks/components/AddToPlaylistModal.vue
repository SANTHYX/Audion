<template>
	<v-dialog :value="visable" max-width="800px" persistent>
		<v-card min-height="640px">
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
			<v-card-actions class="mt-5 border">
				<v-flex>
					<v-layout wrap justify-center class="flex-container">
						<v-card
							v-for="item in collection"
							:key="item.id"
							width="150px"
							height="120px"
							class="my-3"
						>
							<v-layout justify-end align-start>
								<v-checkbox
									v-model="choosenPlaylists"
									:value="{ id: item.id }"
								/>
							</v-layout>
						</v-card>
					</v-layout>
					<pagination :totalPages="totalPages" :visablePages="5" />
				</v-flex>
			</v-card-actions>
			<v-card-actions class="justify-center">
				<v-btn class="success my-8" @click="handle">Add To Playlists</v-btn>
			</v-card-actions>
		</v-card>
	</v-dialog>
</template>

<script>
import Pagination from '@/commons/components/Pagination.vue';

export default {
	props: {
		visable: {
			type: Boolean,
			required: true,
		},
		collection: {
			required: true,
		},
		totalPages: {
			type: Number,
			default: 1,
		},
	},
	data: () => ({
		choosenPlaylists: [],
	}),
	model: {
		prop: 'visable',
		event: 'show',
	},
	methods: {
		switchPage(e) {
			this.$emit('switchPage', e);
		},
		close() {
			this.$emit('show', !this.visable);
		},
		handle() {
			this.$emit('handle', this.choosenPlaylists);
		},
	},
	components: {
		Pagination,
	},
	async created() {
		await this.switchPage();
	},
};
</script>

<style>
.border {
	border: 1px rgb(214, 214, 214) solid;
	min-height: 50vh;
}
.flex-container {
	min-height: 30vh;
}
</style>
