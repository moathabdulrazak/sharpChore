
namespace sharpChore.Models;

public class Chore
{
  public int Id { get; set; }
  public string Title { get; set; }
  public string Description { get; set; }

  public string CreatorId { get; set; }
  public bool Completed { get; set; }
  public Account Creator { get; set; }
}
