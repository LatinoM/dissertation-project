using TMPro;
using UnityEngine;
using System;
namespace Blocks
{
    public class BitBlock : BuildingBlock<int>
    {
        public TextMeshPro textMeshPro;

        void OnEnable()
        {
            this.val = 0;
            this.type = BuildingBlock<int>.Type.BIT;
            initialise();
        }

        protected override void initialise()
        {
            Transform textMeshProTransform = transform.Find("BitText");
            textMeshPro = textMeshProTransform.GetComponent<TextMeshPro>();
        }

        void Update()
        {
            if (textMeshPro != null)
            {
                textMeshPro.text = this.val.ToString();
            }
        }

        public int getBitLength()
        {
            if (this.next == null)
                return 1;
            if (this.next.type == BuildingBlock<int>.Type.BIT)
            {
                //Debug.Log("This next block is a bit!");
                BitBlock nextBit = (BitBlock)this.next;
                //Debug.Log(nextBit + " is the next bit");
                return nextBit.getBitLength() + 1;
            }
            return 1;
        }

        public int getBitNumValue(int unitIndex)
        {
            if (unitIndex == 0)
                return this.val;
            BitBlock nextBit = (BitBlock)this.next;
            return ((int)Math.Pow(2, unitIndex)) * this.val + nextBit.getBitNumValue(unitIndex - 1);
        }

        public override void clicked()
        {
            if (this.val == 0)
                this.val = 1;
            else
                this.val = 0;
        }


    }
}