using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace gwent_patch_info.Models;

public class CardRevision 
{
  [BsonId]
  [BsonRepresentation(BsonType.ObjectId)]
  public string? Id {get; set;}
  public string? InGameId {get;set;}
  
}