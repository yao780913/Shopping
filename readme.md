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
