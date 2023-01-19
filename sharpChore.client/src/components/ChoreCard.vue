<template>
  <div class="col-12 gap-5 elevation-2 card-vfx">
    <h2 class="text-center text-light">{{ chore.title }}- {{ chore.description }}</h2>
    <img class="img-fluid img-vfx rounded p-1" :src="chore.creator?.picture" alt="">
    <h4>{{ chore.creator?.name }}</h4>

  </div>

</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
export default {
  props: {
    chore: { type: Object, required: true }
  },
  setup() {
    return {}
  }
};
</script>



<style lang="scss" scoped>
.img-vfx {
  height: 50px;
  width: 50px;
}

.card-vfx {
  background-color: rgb(51 27 61 / 14%);
  backdrop-filter: blur(40px);
}
</style>