import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";


class ChoreService {




  async getChores() {
    const res = await api.get('api/chores')
    logger.log(res.data)
    AppState.chores = res.data
  }


  async createChore(body) {
    const res = await api.post('api/chores', body)
    logger.log(res.data)
    AppState.chores.push(res.data)
    return res.data
  }
  async removeChore(choreId) {
    const res = await api.delete('api/chores/' + choreId)
    AppState.chores = res.data
  }

}




export const choreService = new ChoreService();
