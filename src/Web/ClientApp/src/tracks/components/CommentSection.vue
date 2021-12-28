<template>
	<v-card width="1300px" height="200px">
		<v-card-text>
			<comment
				v-for="comment in comments"
				:key="comment.id"
				:comment="comment"
			/>
		</v-card-text>
	</v-card>
</template>

<script>
import Comment from './Comment.vue';

export default {
	props: {
		comments: {
			type: Array,
			required: true,
		},
	},
	components: {
		Comment,
	},
};
</script>

<style></style>
