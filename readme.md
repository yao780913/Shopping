https://github.com/launchany/align-define-design-examples

### gRPC
https://www.youtube.com/watch?v=V-FCYGW0IuM
#### How to create new service
1. Create a new proto file `{yourfile}` in the `proto` directory.
2. open file `.csproj`
3. Add the following code to the file
    ```xml
    <ItemGroup>
        <Protobuf Include="proto\{yourfile}.proto" GrpcServices="Client" />
    </ItemGroup>
    ```
#### How to generate client in other project
1. copy the `proto` directory to the other project
2. open file `.csproj`
3. install packages
   - `Grpc.Tools`
   - `Google.Protobuf`
   - `Grpc.Net.ClientFactory`
4. Add the following code to the file
    ```xml
    <ItemGroup>
        <Protobuf Include="proto\{yourfile}.proto" GrpcServices="Client" />
    </ItemGroup>
    ```
5. initialize the client
   ```csharp
   var channel = GrpcChannel.ForAddress("https://localhost:5001");
   var client = new Greeter.GreeterClient(channel);
   ```
   
6. call the service
   ```csharp
   var reply = await client.SayHelloAsync(new HelloRequest { Name = "GreeterClient" });
   Console.WriteLine("Greeting: " + reply.Message);
   ```
   
#### Register gRPC clients
[microsoft docs](https://learn.microsoft.com/en-us/aspnet/core/grpc/clientfactory?view=aspnetcore-8.0#register-grpc-clients)

```csharp
builder.Services.AddGrpcClient<Greeter.GreeterClient>(o =>
{
    o.Address = new Uri("https://localhost:5001");
});
```