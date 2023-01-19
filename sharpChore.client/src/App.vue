<template>
  <header>
    <Navbar />
  </header>
  <main class="bg-vfx">
    <router-view />
  </main>

</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'

export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root {
  --main-height: calc(100vh - 32px - 64px);
}

.bg-vfx {
  background-image: url("https://ecommerce-platforms.com/wp-content/uploads/2013/12/15-icon-patterns-1549495017.jpg");
}

footer {
  display: grid;
  place-content: center;
  height: 32px;
}
</style>
