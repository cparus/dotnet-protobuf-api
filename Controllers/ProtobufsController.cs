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
        public IActionResult SimpleProtobuf()
        {
            return new ObjectResult(ProtobufSerilization.SimpleProtobuf());
        }

        //size 6.01 MB
        [HttpGet("ProtobufList")]
        public Task ProtobufList()
        {
            bool asJSON = false;
            var byteArr = ProtobufSerilization.GetList(asJSON) as byte[];
            Response.ContentType = "application/octet-stream";
            return Response.Body.WriteAsync(byteArr, 0, byteArr.Length);
        }

        //size 15.28 MB
        [HttpGet("JSONList")]
        public IActionResult JSONList()
        {
            bool asJSON = true;
            return new ObjectResult(ProtobufSerilization.GetList(asJSON));
        }
    }

    public class ProtobufSerilization
    {
        public static byte[] SimpleProtobuf()
        {
            SimpleProtoModel simplePB = new SimpleProtoModel();
            simplePB.String1 = "HELLO";
            simplePB.String2 = "WORLD";

            return TCSerialization(simplePB);
        }

        public static object GetList(bool asJSON)
        {
            var objectList = new List<TestModel>();
            TestModel protoModel = new TestModel();
            for (int i = 0; i < 180000; i++)
            {
                protoModel.Address = "1111111 Uh YUH";
                protoModel.FirstName = "GUY";
                protoModel.LastName = "HANDS";
                protoModel.Id = 33;
                protoModel.TestNum = 5434;
                objectList.Add(protoModel);
            }
            if (asJSON)
            {
                return objectList;
            }
            else
            {
                return TCSerialization(objectList);
            }
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
