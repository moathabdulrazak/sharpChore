<template>
  <button type="button" class="btn fs-5 mdi m-auto mdi-plus plus-vfx col-12 text-light " data-bs-toggle="modal"
    data-bs-target="#exampleModal">
    <h6>add duty</h6>
  </button>

  <ChoreForm />
  <div class="row container-fluid justify-content-end pt-5 gap-2 pb-5 ">
    <div v-for="c in chore">
      <ChoreCard :chore="c" />
      <button v-if="(c.creatorId == account.id)" @click="removeChore(c.id)" title="delete"
        class="btn btn-danger delete-btn rounded-pill"><i class="  px-2 mdi mdi-delete-forever"></i></button>
    </div>
  </div>
</template>

<script>
import { onMounted, computed } from "vue";
import { AppState } from "../AppState.js";
import ChoreCard from "../components/ChoreCard.vue";
import ChoreForm from "../components/ChoreForm.vue";
import { choreService } from "../services/ChoreService.js";
import Pop from "../utils/Pop.js";
import { useRoute } from "vue-router";
export default {
  setup() {
    const route = useRoute();
    async function getChores() {
      try {
        await choreService.getChores();
      }
      catch (error) {
        Pop.error();
      }
    }
    onMounted(() => {
      getChores();
    });
    return {
      chore: computed(() => AppState.chores),
      account: computed(() => AppState.account),

      async removeChore(choreId) {
        try {
          await choreService.removeChore(choreId, route.params.id)
        } catch (error) {
          Pop.error(error)
        }
      },


    };
  },
  components: { ChoreCard, ChoreForm }
}
</script>

<style scoped lang="scss">
.plus-vfx {}

.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;

  .home-card {
    width: 50vw;

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }


  }
}
</style>
