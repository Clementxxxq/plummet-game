
/*using MongoDB.Driver;
using MongoDB.Bson;

const string connectionUri = "mongodb+srv://xiaquan666666:<rRqWRQ2fjCapt988>@player.mygtm.mongodb.net/?retryWrites=true&w=majority&appName=Player";

var settings = MongoClientSettings.FromConnectionString(connectionUri);

// Set the ServerApi field of the settings object to set the version of the Stable API on the client
settings.ServerApi = new ServerApi(ServerApiVersion.V1);

// Create a new client and connect to the server
var client = new MongoClient(settings);

// Send a ping to confirm a successful connection
try
{
    var result = client.GetDatabase("admin").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
    Console.WriteLine("Pinged your deployment. You successfully connected to MongoDB!");
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}*/
