using DataStructure.DoubleLinkedLists;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataStructure.DoubleLinkedLists
{
    public class ListRandom : DoubleLinkedList
    {
        public override Node AddByIndex(int index, int value)
        {
            Node node = base.AddByIndex(index, value);
            node.Random = GetNodeByIndex(new Random().Next(0, Length));
            return node;
        }
        public void Serialize(Stream s)
        {
            var sb = new StringBuilder();
            Node tmp = _root;
            sb.Append("{ \"items\": [ ");
            for(int i = 0; i < Length; i++)
            {
                sb.Append("{ \"Value\" : " + tmp.Value);
                sb.Append(" \"Previous\": " + (i - 1));
                sb.Append(" \"Next\": " + (i + 1));
                sb.Append(" \"Random\": " + GetIndexByNode(tmp.Random) + " }, ");
            }
            sb.Remove(sb.Length, 1);
            sb.Append("] }");
            var sw = new StreamWriter(s);
            sw.Write(sb.ToString());
        }

        public void Deserialize(Stream s)
        {
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
