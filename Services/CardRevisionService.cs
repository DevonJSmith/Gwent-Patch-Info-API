using gwent_patch_info.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace gwent_patch_info.Services;

public class CardRevisionService
{
  private readonly IMongoCollection<CardRevision> _cardRevisionCollection;
  public CardRevisionService(IOptions<CardDataSettings> cardDataSettings)
  {
    // replace password with environment secret in connection string
    var connectionString = cardDataSettings.Value.ConnectionString.Replace("<password>", Environment.GetEnvironmentVariable("mongoDbUser"));
    var mongoClient = new MongoClient(connectionString);
    var mongoDatabase = mongoClient.GetDatabase(cardDataSettings.Value.DatabaseName);
    _cardRevisionCollection = mongoDatabase.GetCollection<CardRevision>(cardDataSettings.Value.CardRevisionCollectionName);
  }

  public async Task<List<CardRevision>> GetAsync() => await _cardRevisionCollection.Find(_ => true).ToListAsync();

  public async Task <CardRevision?> GetAsync(string id) => await _cardRevisionCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

  public async Task CreateAsync (CardRevision newCardRevision) => await _cardRevisionCollection.InsertOneAsync(newCardRevision);

  public async Task UpdateAsync (string id, CardRevision updatedCardRevision) => await _cardRevisionCollection.ReplaceOneAsync(x => x.Id == id, updatedCardRevision);

  public async Task RemoveAsync (string id) => await _cardRevisionCollection.DeleteOneAsync(x => x.Id == id);
  
}