using System.Collections.Generic;
using ProtoBuf;
using System;

namespace dotnet_protobuf_api.Protos
{
    [ProtoContract]
    public class SimpleProtoModel
    {
        [ProtoMember(1)]
        public string String1 { get; set; }

        [ProtoMember(2)]
        public string String2 { get; set; }
    }

}

