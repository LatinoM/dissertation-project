using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace Blocks
{


    public class IfElseBlock : BuildingBlock<int>
    {
        public TextMeshPro textMeshPro;

        public BuildingBlock<int> leftChoice;
        public BuildingBlock<int> rightChoice;

        public BuildingBlock<bool> condition;

        void OnEnable()
        {
            this.type = BuildingBlock<int>.Type.IFELSE;
            initialise();
            this.val = 0;
        }

        void Update()
        {
            if (textMeshPro != null)
            {
                if (this.condition.getVal())
                {
                    textMeshPro.text = "->";
                    this.val = this.rightChoice.getVal();
                }
                else
                {
                    textMeshPro.text = "<-";
                    this.val = this.leftChoice.getVal();
                }

            }
        }

        protected override void initialise()
        {
            Transform textMeshProTransform = transform.Find("IfElseText");
            textMeshPro = textMeshProTransform.GetComponent<TextMeshPro>();
        }

        public override void clicked()
        {
            return;
        }
    }
}
