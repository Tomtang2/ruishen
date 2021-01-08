using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.ComponentModel;
using System.Threading;


namespace ruishen.序列化和反序列化
{
    class Serialization
    {
        #region 序列化和反序列化

        #region 序列化
        public static byte[] SerializationObject(object doubleArray) {
            System.IO.MemoryStream _memory = new System.IO.MemoryStream();
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter Bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            Bformatter.Serialize(_memory,doubleArray);
            byte [] tableBT=_memory.ToArray();
            _memory.Close();
            _memory.Dispose();
            return tableBT;
        }
        #endregion

        #region 反序列化
        public static object DeserializeObject(byte[] pbyte) {
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter Bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            System.IO.MemoryStream _memory = new System.IO.MemoryStream(pbyte);
            _memory.Position = 0;
            object ObjArray = Bformatter.Deserialize(_memory);
            _memory.Close();
            _memory.Dispose();
            return ObjArray;
        }
        #endregion
        #endregion
    }
}
