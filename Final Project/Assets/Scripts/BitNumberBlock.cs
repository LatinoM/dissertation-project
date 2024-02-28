using UnityEngine;
using TMPro;

namespace Blocks
{
    public class BitNumberBlock : BuildingBlock<int>
    {
        public TextMeshPro textMeshPro;
        public int bitLength;

        public BuildingBlock<int> currentBlock; // remove me

        void OnEnable()
        {

            this.bitLength = 0;
            this.type = BuildingBlock<int>.Type.BIT_NUM;
            initialise();
            this.bitLength = getBitLength();
            this.val = 0;
        }

        protected override void initialise()
        {
            Transform textMeshProTransform = transform.Find("BitNumText");
            textMeshPro = textMeshProTransform.GetComponent<TextMeshPro>();
        }

        void Update()
        {
            if (textMeshPro != null)
            {
                textMeshPro.text = this.val.ToString();
            }
            this.val = getBitNumValue();
        }

        int getBitLength()
        {
            Debug.Log("Finding bit length!");
            Debug.Log("Next Block type is: " + this.next.type);
            if (this.next.type == BuildingBlock<int>.Type.BIT)
            {
                Debug.Log("It's a bit!");
                BitBlock nextBit = (BitBlock)this.next;
                Debug.Log(nextBit + " is the next bit");
                return nextBit.getBitLength();
            }
            Debug.Log("No Bit Blocks connected");
            return 0;

        }

        int getBitNumValue()
        {
            int bitLength = getBitLength();
            if (bitLength == 0)
                return 0;
            BitBlock firstBit = (BitBlock)this.next;
            return firstBit.getBitNumValue(bitLength - 1);
        }

        public override void clicked()
        {
            return; // clicking doesn't change anything, this is purely a way of getting the number value from bit blocks
        }


    }
}

