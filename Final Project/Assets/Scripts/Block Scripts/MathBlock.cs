using TMPro;
using UnityEngine;
using System;
namespace Blocks
{
    public class MathBlock : BuildingBlock<int>
    {
        public TextMeshPro textMeshPro;

        public BuildingBlock<int> left;
        public BuildingBlock<int> right;
        public enum OperatorType
        {
            ADD,
            SUB,
            MULT,
            FLOOR_DIV,
            MODULUS
        }

        private OperatorType mode = OperatorType.ADD;

        void OnEnable()
        {
            this.type = BuildingBlock<int>.Type.MATH;
            initialise();
            this.val = 0;
        }

        void Update()
        {
            if (textMeshPro != null)
            {
                textMeshPro.text = this.getSymbol();
            }
            if (left != null && right != null)
            {
                this.val = calculate();
            }
        }


        protected override void initialise()
        {
            Transform textMeshProTransform = transform.Find("MathText");
            textMeshPro = textMeshProTransform.GetComponent<TextMeshPro>();
        }

        public override void clicked()
        {
            // when clicked, it should cycle mode and thus change its output
            switch (this.mode)
            {
                case OperatorType.ADD:
                    this.mode = OperatorType.SUB;
                    break;
                case OperatorType.SUB:
                    this.mode = OperatorType.MULT;
                    break;
                case OperatorType.MULT:
                    this.mode = OperatorType.FLOOR_DIV;
                    break;
                case OperatorType.FLOOR_DIV:
                    this.mode = OperatorType.MODULUS;
                    break;
                default:
                    this.mode = OperatorType.ADD;
                    break;
            }
        }

        private int calculate()
        {
            switch (this.mode)
            {
                case OperatorType.ADD:
                    return this.left.getVal() + this.right.getVal();
                case OperatorType.SUB:
                    return this.left.getVal() - this.right.getVal();
                case OperatorType.MULT:
                    return this.left.getVal() * this.right.getVal();
                case OperatorType.FLOOR_DIV:
                    return (int)(this.left.getVal() / this.right.getVal());
                default:
                    return this.left.getVal() % this.right.getVal();
            }
        }

        private string getSymbol()
        {
            switch (this.mode)
            {
                case OperatorType.ADD:
                    return "+";
                case OperatorType.SUB:
                    return "-";
                case OperatorType.MULT:
                    return "*";
                case OperatorType.FLOOR_DIV:
                    return "//";
                default:
                    return "%";
            }
        }

        public OperatorType getOperator()
        {
            return this.mode;
        }
    }
}
