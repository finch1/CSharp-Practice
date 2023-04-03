using System.Collections.Concurrent;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

/*
API Routes:

GET /jokes -> Return a list of all jokes
GET /jokes/{id} -> Return the details of a single joke
PUT /jokes/{id} -> Update details of a single joke
POST /jokes -> Insert a new joke. ID created on server side
DELETE /jokes/{id} -> Delete a joke by ID

Structre:

ID
Joke - Joke text
FunLevel - 0...5
*/

// DECLARE LOCAL VARIABLES
int nextJokeID = 0;

// We know how many items we want to insert into the ConcurrentDictionary.
// So set the initial capacity to some prime number above that, to ensure that
// the ConcurrentDictionary does not need to be resized while initializing it.
int initialCapacity = 101;

// The higher the concurrencyLevel, the higher the theoretical number of operations
// that could be performed concurrently on the ConcurrentDictionary.  However, global
// operations like resizing the dictionary take longer as the concurrencyLevel rises.
// For the purposes of this example, we'll compromise at numCores * 2.
int numProcs = Environment.ProcessorCount;
int concurrencyLevel = numProcs * 2;

// Construct the dictionary with the desired concurrencyLevel and initialCapacity
ConcurrentDictionary<int, Joke> jokeDict = new ConcurrentDictionary<int, Joke>(concurrencyLevel, initialCapacity);



// API
app.MapGet("/jokes", () => jokeDict.Values);
app.MapGet("/jokes/{id}", (int id) => {
        if(jokeDict.TryGetValue(id, out Joke? joke)) { return Results.Ok(joke); }
        return Results.NoContent();
    });

app.MapPost("/jokes", (CreateUpdateJokeDTO dto) => {
        // Create a new ID for the new joke. A thread safe way to increment the ID is by:
        int newID = Interlocked.Increment(ref nextJokeID);

        // take the DTO we received as an input parameter and convert to joke object, because we store jokes as objects internally
        Joke jokeToAdd = new Joke{
            Id = newID,
            JokeText = dto.JokeText,
            FunLevel = dto.FunLevel,
        };

        // convert DT to persist joke to dict
        if (!jokeDict.TryAdd(newID, jokeToAdd)) {             
            return Results.StatusCode(StatusCodes.Status500InternalServerError);
        }

        // Return Created (201) by confirming back the final data in the response
        return Results.Created($"/jokes/{newID}", jokeToAdd);
});

app.MapPut("/jokes/{id}", (int id, CreateUpdateJokeDTO dto) => {
        
        //Joke currentJoke = null;

        if(!jokeDict.TryGetValue(id, out Joke? currentJoke)){
            return Results.NotFound();
        }

        // The below is in code concurrency
        Joke jokeToUpdate = new Joke{
                                    Id = currentJoke.Id,
                                    JokeText = dto.JokeText,
                                    FunLevel = dto.FunLevel,
                                };

        if(!jokeDict.TryUpdate(id, jokeToUpdate, currentJoke)){
            return Results.StatusCode(StatusCodes.Status500InternalServerError);
        }

        // Return Created (202) by confirming back the final data in the response
        return Results.Accepted($"/jokes/{id}", jokeToUpdate);
});

app.MapDelete("/jokes/{id}", (int id) => {

        if (!jokeDict.TryRemove(id, out Joke? jokeToRemove))
        {
            return Results.StatusCode(StatusCodes.Status500InternalServerError);
        }

        // Return Created (202) by confirming back the final data in the response
        return Results.Accepted($"/jokes/{id}", jokeToRemove);
});

app.Run();


class Joke // multable object to be stored
{
    public int Id { get; set; }

    public string? JokeText { get; set; } // the joke might have a text or not
    
    private byte _FunLevel;
    public byte FunLevel { 
        get{
            return _FunLevel;
        }
        set{
            if(value > (byte)5 | value < (byte)0){
                    throw new ArgumentOutOfRangeException("FunLevel not within range 0...5");
                }
            _FunLevel = value;
        } }
   
}

// we cannot use the class object to create a new joke so we create a DTO, without an ID varibale
record CreateUpdateJokeDTO(string JokeText, byte FunLevel);