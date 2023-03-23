namespace gwent_patch_info.Models;
public class CardDataSettings
{
  public string ConnectionString {get;set;} = null!;
  public string DatabaseName {get;set;} = null!;
  public string CardRevisionCollectionName {get;set;} = null!;
  public string PatchCollectionName {get;set;} = null!;
}