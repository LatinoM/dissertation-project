using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Blocks
{
    [System.Serializable]
    public class ArrayBlock : BuildingBlock<int>
    {
        public BuildingBlock<int>[] array;

        protected override void initialise()
        {
            return;
        }
        public override void clicked()
        {
            return;
        }

        public int getVal(int index)
        {
            if (index < 0 || index >= array.Length || array.Length == 0)
            {
                return -1;
            }
            return array[index].getVal();
        }
        public BuildingBlock<int>[] getVal()
        {
            return array;
        }

        public int getSize()
        {
            return array.Length;
        }
    }

}

