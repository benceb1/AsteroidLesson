using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [Serializable]
    public class Packet
    {
        public List<string> Gdata;
        public Object dataObject;
        public string senderId;
        public PacketType packetType;

        public Packet(PacketType packetType, string senderId)
        {
            Gdata = new List<string>();
            this.senderId = senderId;
            this.packetType = packetType;
        }

        public byte[] ToBytes()
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, this);
                return ms.ToArray();
            }
        }

        public Packet(byte[] packetBytes)
        {
            BinaryFormatter bf = new BinaryFormatter();

            using (var ms = new MemoryStream(packetBytes))
            {
                Packet packet = (Packet)bf.Deserialize(ms);
                this.dataObject = packet.dataObject;
                this.Gdata = packet.Gdata;
                this.senderId = packet.senderId;
                this.packetType = packet.packetType;
            }
        }
    }
}
