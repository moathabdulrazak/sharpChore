<template>




  <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="exampleModalLabel">duty</h5>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body modal-vfx">
          <form @submit.prevent="createChore()">
            <div class="mb-3">
              <label for="title" class="form-label">title</label>
              <input v-model="editable.title" type="text" class="form-control" id="title" aria-describedby="title">
            </div>
            <div class="mb-3">
              <label for="description" class="form-label">description</label>
              <input v-model="editable.description" type="description" class="form-control" id="description">
            </div>
            <button type="submit" class="btn btn-primary">Submit</button>
          </form>
        </div>

      </div>
    </div>
  </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted, ref } from 'vue';
import Pop from "../utils/Pop.js";
import { choreService } from "../services/ChoreService.js";
import { Modal } from "bootstrap";
export default {
  setup() {
    const editable = ref({})
    return {
      editable,
      async createChore() {
        try {
          await choreService.createChore(editable.value)
          editable.value = {}
          Modal.getOrCreateInstance('#exampleModal').hide()
        } catch (error) {
          Pop.error(error)
        }
      }
    }
  }
};
</script>


<style lang="scss" scoped>
.modal-vfx {
  background-color: rgb(51 27 61 / 14%);
  backdrop-filter: blur(40px);
}
</style>