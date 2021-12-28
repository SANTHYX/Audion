<template>
	<v-card min-height="200px" width="1300px">
		<v-card-title>
			<v-row justify="center">
				<v-col>
					<v-img
						dark
						gradient="to top right, rgba(100,115,201,.33), rgba(25,32,72,.7)"
						aspect-ratio="1.2"
						max-width="200px"
						height="200px"
					/>
					<h2 class="mt-2 ml-6">UserName</h2>
				</v-col>
				<v-col>
					<v-card-text>
						<p>
							Lorem ipsum dolor sit amet, consectetur adipisicing elit. Rerum
							adipisci neque nulla amet! Voluptates nemo ex temporibus ratione
							repudiandae! Enim, unde minus. Eos quae cum vel incidunt
							consectetur! Dolore, molestias earum amet repellendus nobis
							assumenda magnam, nostrum suscipit quibusdam est obcaecati?
							Repudiandae explicabo enim sequi exercitationem qui necessitatibus
							quasi impedit!Lorem ipsum dolor sit amet, consectetur adipisicing
							elit. Rerum adipisci neque nulla amet! Voluptates nemo ex
							temporibus ratione repudiandae! Enim, unde minus. Eos quae cum vel
							incidunt consectetur! Dolore, molestias earum amet repellendus
							nobis assumenda magnam, nostrum suscipit quibusdam est obcaecati?
							Repudiandae explicabo enim sequi exercitationem qui necessitatibus
							quasi impedit!
						</p>
					</v-card-text>
				</v-col>
			</v-row>
		</v-card-title>
	</v-card>
</template>

<script>
export default {
	name: 'InfoDisplayer',
	props: {
		details: {
			type: Object,
			required: true,
		},
	},
};
</script>

<style></style>
