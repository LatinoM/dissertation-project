using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Blocks
{
    public class ArrayIndexerBlock : BuildingBlock<int>
    {
        public TextMeshPro textMeshPro;
        int arraySize;
        public ArrayBlock arrayBlock;
        int index = 0;

        void OnEnable()
        {
            arraySize = this.arrayBlock.getSize();
            initialise();
        }

        void Update()
        {
            if (textMeshPro != null)
            {
                textMeshPro.text = this.index.ToString();
            }
            this.val = this.arrayBlock.getVal(index);
        }

        protected override void initialise()
        {
            Transform textMeshProTransform = transform.Find("BitNumText");
            textMeshPro = textMeshProTransform.GetComponent<TextMeshPro>();
        }

        public override void clicked()
        {
            index++;
            if (index >= arraySize)
            { index = 0; }
        }
    }
}