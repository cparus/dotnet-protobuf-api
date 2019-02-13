# Intro
This is research project is using protobufs in C# and .NET Core WebAPI. The project is using a library called protobuf-net that follows the typical .NET patterns.
 https://github.com/mgravell/protobuf-net

# Install .NET
Download .NET Core SDK 
https://dotnet.microsoft.com/download


# Running Project
Run project with 'dotnet run' command.

# Routes
'http://localhost:5000/api/Protobufs/SimpleProtobuf' - returns byte array. Client must decode the Uint8 and mirror the schema found in ./Protos/SimpleProto.

'http://localhost:5000/api/Protobufs/ProtobufList' - returns byte array. When this is decoded properly it will contain a list of about 180,000 records. On client side the schema found in ./Protos/ProtoModel should be wrapped in another message to decode the list. 

message ProtoModel {
  int32 Id = 1;
  string FirstName = 2;
  string LastName = 3;
  string Address = 4;
  int32 TestNum = 5;
}

message ProtoModelList {
  repeated ProtoModel ProtoModels = 1;
}


'http://localhost:5000/api/Protobufs/JSONList' - returns JSON representation of the data returned in ProtobufList. Compare this route with /ProtobufList to see optimization achieved with protobufs.

