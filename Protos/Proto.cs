using System.Collections.Generic;
using ProtoBuf;
using System;

namespace dotnet_protobuf_api.Protos
{
    [ProtoContract]
    public class ProtoModel
    {
        [ProtoMember(1)]
        public int Id { get; set; }

        [ProtoMember(2)]
        public string FirstName { get; set; }
        
        [ProtoMember(3)]
        public string LastName { get; set; }
        [ProtoMember(4)]
        public string Address { get; set; }

        [ProtoMember(5)]
        public int TestNum { get; set; }
    }

    public class JSONModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public int TestNum { get; set; }
    }

}

