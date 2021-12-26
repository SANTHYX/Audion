<template>
	<v-container v-if="collection">
		<v-row dense>
			<h2>Results of searching User "{{ $route.query.userName }}"</h2>
			<v-spacer />
			<h3>Found Results: {{ totalResults }}</h3>
		</v-row>
		<v-divider class="my-2" />
		<v-container class="collection-wraper">
			<browse-user-card
				v-for="user in collection"
				:key="user.userName"
				:user="user"
				@check="
					$router.push({ name: 'User', params: { userName: user.userName } })
				"
			/>
		</v-container>
		<pagination
			:totalPages="totalPages"
			:visablePages="5"
			switchPage="changePage"
		/>
	</v-container>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';
import Pagination from '../../commons/components/Pagination.vue';
import BrowseUserCard from '../components/BrowseUserCard.vue';

export default {
	name: 'BrowseUsers',
	computed: {
		collection() {
			return this['user/USERS_COLLECTION'].collection;
		},
		totalPages() {
			return this['user/USERS_COLLECTION'].totalPages;
		},
		totalResults() {
			return this['user/USERS_COLLECTION'].totalResults;
		},

		...mapGetters(['user/USERS_COLLECTION']),
	},
	methods: {
		changePage(page) {
			this.$router.replace({ query: { ...this.$route.query, page } });
		},

		...mapActions(['user/BROWSE_USERS']),
	},
	components: {
		Pagination,
		BrowseUserCard,
	},
	async mounted() {
		await this['user/BROWSE_USERS'](this.$route.query);
	},
};
</script>

<style>
.collection-wraper {
	display: flex;
	flex-direction: column;
	align-items: center;
	min-height: 64vh;
}
</style>
