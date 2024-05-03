using TMPro;
using UnityEngine;

namespace Blocks
{

    public class CompareNumBlock : BuildingBlock<bool>
    {
        public TextMeshPro textMeshPro;

        public BuildingBlock<int> left;
        public BuildingBlock<int> right;
        public enum CompType
        {
            EQUIV,
            INEQUIV,
            LT,
            LE,
            GT,
            GE
        }
        public bool preset;
        public CompType presetMode;
        private CompType mode;

        void OnEnable()
        {
            this.type = BuildingBlock<bool>.Type.COMP_NUM;
            initialise();
            this.val = false;
            if (preset)
            {
                this.mode = presetMode;
            }
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
            Transform textMeshProTransform = transform.Find("CompText");
            textMeshPro = textMeshProTransform.GetComponent<TextMeshPro>();
        }

        public CompType getMode()
        {
            return this.mode;
        }

        public override void clicked()
        {
            // when clicked, it should cycle mode and thus change its output
            if (!preset)
            {
                switch (this.mode)
                {
                    case CompType.EQUIV:
                        this.mode = CompType.INEQUIV;
                        break;
                    case CompType.INEQUIV:
                        this.mode = CompType.LT;
                        break;
                    case CompType.LT:
                        this.mode = CompType.LE;
                        break;
                    case CompType.LE:
                        this.mode = CompType.GT;
                        break;
                    case CompType.GT:
                        this.mode = CompType.GE;
                        break;
                    default:
                        this.mode = CompType.EQUIV;
                        break;
                }
            }
        }

        private bool calculate()
        {
            switch (this.mode)
            {
                case CompType.EQUIV:
                    return this.left.getVal() == this.right.getVal();
                case CompType.INEQUIV:
                    return this.left.getVal() != this.right.getVal();
                case CompType.LT:
                    return this.left.getVal() < this.right.getVal();
                case CompType.LE:
                    return this.left.getVal() <= this.right.getVal();
                case CompType.GT:
                    return this.left.getVal() > this.right.getVal();
                default:
                    return this.left.getVal() >= this.right.getVal();
            }
        }

        private string getSymbol()
        {
            switch (this.mode)
            {
                case CompType.EQUIV:
                    return "=";
                case CompType.INEQUIV:
                    return "!=";
                case CompType.LT:
                    return "<";
                case CompType.LE:
                    return "<=";
                case CompType.GT:
                    return ">";
                default:
                    return ">=";
            }
        }






    }
}
