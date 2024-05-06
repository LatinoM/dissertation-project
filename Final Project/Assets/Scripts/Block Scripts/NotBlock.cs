using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Blocks
{
    public class NotBlock : BuildingBlock<bool>
    {
        void OnEnable()
        {
            this.type = BuildingBlock<bool>.Type.NOT;
            this.val = true;
        }

        protected override void initialise()
        {
            return;
        }

        void Update()
        {
            if (this.next != null)
            {
                this.val = !this.next.getVal();
            }
        }

        public override void clicked()
        {
            return;
        }
    }
}
