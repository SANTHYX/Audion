<template>
	<v-menu offset-y auto open-on-hover>
		<template v-slot:activator="{ on, attrs }">
			<v-btn plain v-bind="attrs" v-on="on">
				<span>Hi {{ userName }}</span>
				<v-icon>mdi-menu-down</v-icon>
			</v-btn>
		</template>
		<v-list>
			<v-list-item
				v-for="route in dropdownRoutes"
				:key="route.label"
				class="pointer"
				:to="{ name: route.routeName }"
			>
				<v-list-item-icon>
					<v-icon>{{ route.icon }}</v-icon>
				</v-list-item-icon>
				<v-list-item-title>{{ route.label }}</v-list-item-title>
			</v-list-item>
			<v-list-item class="pointer" @click="logout">
				<v-list-item-icon>
					<v-icon>mdi-logout</v-icon>
				</v-list-item-icon>
				<v-list-item-title>Logout</v-list-item-title>
			</v-list-item>
		</v-list>
	</v-menu>
</template>

<script>
export default {
	name: 'DropMenu',
	props: {
		userName: {
			type: String,
			required: true,
		},
		dropdownRoutes: {
			type: Array,
			required: true,
		},
	},
	methods: {
		logout() {
			this.$emit('handle');
		},
	},
};
</script>
