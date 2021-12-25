<template>
	<v-container>
		<v-card max-width="600px" class="mt-5 mx-auto">
			<v-card-title class="justify-center">
				<h2 class="display-2">Make Playlist</h2>
			</v-card-title>
			<v-card-text>
				<v-form ref="form">
					<v-text-field
						label="Name"
						dense
						outlined
						:rules="[validationRules.isRequired]"
						v-model="playlistObj.name"
					/>
					<v-textarea
						label="Description"
						dense
						outlined
						:rules="[validationRules.isRequired]"
						v-model="playlistObj.description"
					/>
				</v-form>
			</v-card-text>
			<v-card-actions>
				<v-col>
					<v-row class="justify-center">
						<v-alert
							class="text-center"
							v-model="state.isThrowing"
							border="bottom"
							type="error"
						>
							{{ error.message }}
						</v-alert>
					</v-row>
					<v-row class="justify-center">
						<v-btn width="120" @click="createPlaylist" v-if="!state.isAwaiting">
							Submit
						</v-btn>
						<v-progress-circular indeterminate color="green" v-else />
					</v-row>
				</v-col>
			</v-card-actions>
		</v-card>
	</v-container>
</template>

<script>
import { mapActions } from 'vuex';

export default {
	data: () => ({
		playlistObj: {
			name: '',
			description: '',
		},
		error: {
			message: undefined,
		},
		state: {
			isAwaiting: false,
			isThrowing: false,
		},
		validationRules: {
			isRequired: (v) => !!v || 'This field is required',
		},
	}),
	methods: {
		async createPlaylist() {
			if (this.$refs.form.validate()) {
				this.await();
				await this['playlist/CREATE_PLAYLIST'](this.playlistObj);
				this.$router.push(this.$route.query.redirect || '*');
			}
			return;
		},
		await() {
			this.state.isAwaiting = true;
			this.state.isThrowing = false;
		},
		throw() {
			this.state.isAwaiting = false;
			this.state.isThrowing = true;
		},

		...mapActions(['playlist/CREATE_PLAYLIST']),
	},
	errorCaptured(err) {
		this.error.message = err.message || 'Error has occured';
		this.throw();
	},
};
</script>

<style></style>
