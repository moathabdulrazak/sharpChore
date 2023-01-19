namespace sharpChore.Services;

public class ChoreService
{

  private readonly ChoreRepository _repo;

  public ChoreService(ChoreRepository repo)
  {
    _repo = repo;
  }

  internal List<Chore> Get(string id)
  {
    List<Chore> chores = _repo.Get();
    List<Chore> filtered = chores.FindAll(c => c.Completed == false || c.CreatorId == id);
    return filtered;
  }

  internal Chore GetOne(int id, string userId)
  {
    Chore chore = _repo.GetOne(id);
    if (chore == null)
    {
      throw new Exception("no chore at dis id bruh");
    }
    if (chore.Completed == true && chore.CreatorId != userId)
    {
      throw new Exception("no own bruh");
    }
    return chore;
  }

  internal Chore Create(Chore choreData)
  {
    Chore chore = _repo.Create(choreData);

    return chore;
  }

  internal string Remove(int id, string userId)
  {
    Chore original = GetOne(id, userId);
    if (original.CreatorId != userId)
    {
      throw new Exception("not your chore");
    }

    // original.Completed = !original.Completed;
    // _repo.Update(original);
    // return $"{original.Title} has been {(original.Completed ? "archived" : "unearthed")}";


    _repo.Remove(id);

    return $"{original.Title} has been completed";
  }

}
