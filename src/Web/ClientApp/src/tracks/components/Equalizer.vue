<template>
	<v-card height="200px" width="1300px">
		<v-card-title> </v-card-title>
	</v-card>
</template>

<script>
export default {
	name: 'Equalizer',
	data: () => ({
		frequencies: {
			lowPass: {
				subBass: 0,
				lowBandPass: 0,
				highLowBandPass: 0,
			},
			midPass: {
				lowMidBandPass: 0,
				midBandPass: 0,
				highMidBandPass: 0,
			},
			highPass: {
				lowHighBandPass: 0,
				highBandPass: 0,
				trebble: 0,
			},
		},
		active: false,
	}),
	methods: {},
};
</script>

<style></style>
