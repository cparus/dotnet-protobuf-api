# Intro
This is research project is using protobufs in C# and dotnet core WebAPI. The project is using a library called protobuf-net that follows the typical .NET patterns.
 https://github.com/mgravell/protobuf-net

# Set up environment
Download .NET Core SDK 
https://dotnet.microsoft.com/download


# Running Project
Run API and point client to 'http://localhost:5000/api/Protobufs/SimpleProtobuf'. This will return a serialized version in a base64 string of a simple object. See: ./Protos/Proto. To decode this and to see the original object, client must follow the same schema defined in ./Protos/Proto and deserialize.
