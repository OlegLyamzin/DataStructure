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

        }

        public void Deserialize(Stream s)
        {
        }
    }
}
