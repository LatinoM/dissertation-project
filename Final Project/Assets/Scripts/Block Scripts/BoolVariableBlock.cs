using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Blocks
{


    public class BoolVariableBlock : BuildingBlock<bool>
    {
        // acts like a bit num block but doesn't show value, just 
        // used to represent a variable
        public Transform decorTransform;
        void OnEnable()
        {
            this.type = BuildingBlock<bool>.Type.VAR;
            initialise();
        }

        protected override void initialise()
        {

            if (this.next != null && this.next.type == this.type)
            {
                decorTransform.rotation = Quaternion.Euler(0, 0, 45);
            }
            else
            {
                decorTransform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }

        void Update()
        {
            this.val = this.next.getVal();
        }

        public override void clicked()
        {
            return;
        }
    }
}