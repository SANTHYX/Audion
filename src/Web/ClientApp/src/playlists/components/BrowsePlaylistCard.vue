<template>
	<v-card class="mt-5" width="1300px">
		<v-card-title>
			<h2>{{ playlist.name }}</h2>
		</v-card-title>
		<v-divider />
		<v-card-text>
			<v-img
				dark
				gradient="to top right, rgba(100,115,201,.33), rgba(25,32,72,.7)"
				aspect-ratio="1"
				max-width="200px"
			/>
			<v-spacer />
		</v-card-text>
		<v-card-actions>
			<v-btn class="ml-2" @click="like">Like</v-btn>
			<v-spacer />
			<v-btn class="mr-2" @click="open">Open</v-btn>
		</v-card-actions>
	</v-card>
</template>

<script>
export default {
	props: {
		playlist: {
			type: Object,
			required: true,
		},
	},
	methods: {
		open() {
			this.$emit('open');
		},
		like() {
			this.$emit('like');
		},
	},
};
</script>

<style></style>
