using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnet_protobuf_api.Protos;
using System.IO;
using ProtoBuf;

namespace dotnet_protobuf_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProtobufsController : ControllerBase
    {
        [HttpGet("SimpleProtobuf")]
        public IActionResult Get()
        {
            return new ObjectResult(ProtobufSerilization.SimpleProtobuf());
        }
    }


    public class ProtobufSerilization
    {
        public static byte[] SimpleProtobuf()
        {
            SimpleProtoModel simplePB = new SimpleProtoModel();
            simplePB.String1 = "HELLO";
            simplePB.String2 = "WORLD";

            byte[] objToSerialize = TCSerialization(simplePB);

            return objToSerialize;
        }


        static byte[] TCSerialization(object obj)
        {
            if (obj == null) { return null; }
            try
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    Serializer.Serialize(stream, obj);
                    return stream.ToArray();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
