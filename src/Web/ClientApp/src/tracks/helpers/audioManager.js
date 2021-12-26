let audio = new Audio('');

const audioManager = {
    loadAudio: (url) => { audio = new Audio(url) },

    getAudio: () => audio
}

export default audioManager;