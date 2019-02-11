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

        [HttpGet("ProtobufList")]
        public Task ProtobufList()
        {
            bool asJSON = false;
            var byteArr = ProtobufSerilization.GetList(asJSON) as byte[];
            Response.ContentType = "application/octet-stream";
            return Response.Body.WriteAsync(byteArr, 0, byteArr.Length);
        }

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

        //returning data in binary cuts payload size almost in half
        public static object GetList(bool asJSON)
        {
            var objectList = new List<ProtoModel>();
            ProtoModel protoModel = new ProtoModel();
            for (int i = 0; i < 100000; i++)
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
                //size: 8.49MB
                return objectList;
            }
            else
            {
                //size: 3.3MB
                return TCSerializationList(objectList);
            }
        }

        // TODO combine serializtions methods into one method
        public static byte[] TCSerializationList(List<ProtoModel> list)
        {
            try
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    Serializer.Serialize<List<ProtoModel>>(stream, list);
                    return stream.ToArray();
                }
            }
            catch
            {
                throw;
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
