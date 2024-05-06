using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Blocks
{
    public class LoopBlock : BuildingBlock<int>
    {
        public BuildingBlock<int> initial;
        public MathBlock oper;
        public BuildingBlock<int> iterationCount;

        void Update()
        {
            int init = this.initial.getVal();
            MathBlock.OperatorType mode = oper.getOperator();
            int repeatedValue = oper.right.getVal();
            for (int i = 0; i < iterationCount.getVal(); i++)
            {
                init = performOperation(init, repeatedValue, mode);
            }
            this.val = init;
        }

        int performOperation(int num1, int num2, MathBlock.OperatorType mode)
        {
            switch (mode)
            {
                case MathBlock.OperatorType.ADD:
                    return num1 + num2;
                case MathBlock.OperatorType.SUB:
                    return num1 - num2;
                case MathBlock.OperatorType.MULT:
                    return num1 * num2;
                case MathBlock.OperatorType.FLOOR_DIV:
                    return (int)num1 / num2;
                default:
                    return num1 % num2;
            }
        }

        protected override void initialise() { return; }
        public override void clicked() { return; }
    }

}
