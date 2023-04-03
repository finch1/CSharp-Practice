using HelloAspnetcore;

// Notes:
// https://www.youtube.com/watch?v=xWNVoVug4G8&list=PLhGL9p3BWHwtlclHZ4KMuJGtiI5hj7dWG&index=2
// F1 -> Restart Omni
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.MapGet("/", () => { 
    return "Hello World!";
    });

app.MapGet("/ping", () => "pong");
app.MapGet("/flip", GetFlipName);
app.MapGet("/tarzan", MyHandlers.GetTarzanName);
app.MapGet("/hello", (string name) => $"Hello {name}");

app.MapGet("/customers/{id}", (int id) => $"Customer {id}");
app.MapPost("/customers", () => "I shall create a customer for you");
app.MapPost("/customer", (Customer c) => $"I shall create customer record {c.Name} for you");
app.MapGet("/orders/{id}", (int id, string options) => $"Cutomer {id} ordered {options}");
app.MapGet("/products/{id}", (int id) => Results.Ok(new Product("brush", 69)));
app.MapGet("/customers/{cid}/orders/{oid}/products/{pid}", 
                (int cid, int oid, int pid) => $"Customer {cid} ordered {oid} having product {pid}");

app.MapGet("/iamhappy", () => Results.Ok());
app.MapGet("/iamhappy2", ReturnOK);
app.MapGet("/iamnothappy", () => Results.BadRequest());
app.MapPost("/iamnothappybecause", () => Results.BadRequest("It is not easy"));

app.Run();

//helper functions
IResult ReturnOK()
{
    return Results.Ok();
}

string GetFlipName(){
    return "flop";
}

// records
record Customer(string Name, string Company, int Age);
record Product(string Item, int quantity);