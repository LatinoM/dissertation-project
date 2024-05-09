using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace Blocks
{
    public class AnimalValueBlock : BuildingBlock<int>
    {
        public TextMeshPro textMeshPro;
        public AnimalAttributeBlock attributeBlock;

        void OnEnable()
        {
            initialise();
        }

        protected override void initialise()
        {
            Transform textMeshProTransform = transform.Find("ValueOutput");
            textMeshPro = textMeshProTransform.GetComponent<TextMeshPro>();
        }

        void Update()
        {
            if (this.attributeBlock.numVal > -1)
            {
                textMeshPro.text = this.attributeBlock.numVal.ToString();
                textMeshPro.color = Color.black;
                this.val = this.attributeBlock.numVal;
                return;
            }
            if (this.attributeBlock.boolVal)
            {
                textMeshPro.text = "T";
                textMeshPro.color = Color.green;
                this.val = 0;
                return;
            }
            textMeshPro.text = "F";
            textMeshPro.color = Color.red;

        }

        public override void clicked() { return; }

    }
}
