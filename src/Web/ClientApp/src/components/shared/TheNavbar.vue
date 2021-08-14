<template>
	<div id="navbar"></div>
</template>

<script>
export default {
	name: 'Navbar',
	props: {
		authStatus: {
			type: Boolean,
			required: true,
		},
	},
	data: () => ({
		menuItems: {
			auth: [],
			default: [],
		},
	}),
};
</script>

<style></style>
