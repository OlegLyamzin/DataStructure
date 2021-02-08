using DataStructure.DoubleLinkedLists;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataStructure.DoubleLinkedLists
{
    public class ListRandom : DoubleLinkedList
    {
        private Random _random;

        public ListRandom() : base()
        {
            _random = new Random();
        }

        public override Node AddByIndex(int index, int value)
        {
            Node node = base.AddByIndex(index, value);
            node.Random = GetNodeByIndex(_random.Next(0, Length));
            return node;
        }


        public override Node Add(int value)
        {
            Node node = base.Add(value);
            node.Random = GetNodeByIndex(_random.Next(0, Length));
            return node;
        }

        public void Serialize(Stream s)
        {
            if (s.CanWrite)
            {
                var sw = new StreamWriter(s);
                sw.Write(ToJSON());
                sw.Flush();
            }
        }

        public void Deserialize(Stream s)
        {
            if (s.CanRead)
            {
                var sr = new StreamReader(s);
                string json = sr.ReadToEnd();
                var DTOs = GetNodeDTOsByJSON(json);

                _root = null;
                Length = 0;
                foreach(var DTO in DTOs)
                {
                    Add(DTO.Value);
                }

                Node tmp = _root;
                foreach(var DTO in DTOs)
                {
                    tmp.Random = GetNodeByIndex(DTO.Random);
                    tmp = tmp.Next;
                }
            }
        }
        
        public string ToJSON()
        {
            var sb = new StringBuilder();
            Node tmp = _root;
            sb.Append("[");
            for (int i = 0; i < Length; i++)
            {
                sb.Append("{\"Value\":" + tmp.Value);
                sb.Append(",\"Previous\":" + (i - 1));
                sb.Append(",\"Next\":" + (i + 1));
                sb.Append(",\"Random\":" + GetIndexByNode(tmp.Random) + "},");
                tmp = tmp.Next;
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append("]");
            return sb.ToString();
        }

        private NodeDTO[] GetNodeDTOsByJSON(string json)
        {
            json = json.Trim('[',']');
            json = json.Replace("\"","");
            var jObjs = json.Split("},");
            var DTOs = new NodeDTO[jObjs.Length];

            for(int i = 0; i < jObjs.Length; i++)
            {
                var properties = jObjs[i].Trim('{', '}').Split(',');
                NodeDTO node = new NodeDTO();
                foreach(var property in properties)
                {
                    switch (property.Split(':')[0])
                    {
                        case "Value":
                            node.Value = Convert.ToInt32(property.Split(':')[1]);
                            break;
                        case "Random":
                            node.Random = Convert.ToInt32(property.Split(':')[1]);
                            break;
                    }
                }
                DTOs[i] = node;
            }
            return DTOs;
        }

        private int? GetIndexByNode(Node node)
        {
            Node tmp = _root;
            for (int i = 0; i < Length; i++)
            {
                if(node == tmp)
                {
                    return i;
                }
                tmp = tmp.Next;
            }
            return null;
        }

    }
}
