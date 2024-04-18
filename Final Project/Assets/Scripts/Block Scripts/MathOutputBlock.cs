using TMPro;
using UnityEngine;
namespace Blocks
{


    public class MathOutputBlock : BuildingBlock<int>
    {
        public TextMeshPro textMeshPro;
        void OnEnable()
        {
            this.type = BuildingBlock<int>.Type.MATH_OUT;
            initialise();
            this.val = 0;
        }

        protected override void initialise()
        {
            Transform textMeshProTransform = transform.Find("MathOutText");
            textMeshPro = textMeshProTransform.GetComponent<TextMeshPro>();
        }

        void Update()
        {
            if (textMeshPro != null)
            {
                textMeshPro.text = this.val.ToString();
            }
            if (this.next != null)
            {
                this.val = this.next.getVal();
            }
        }

        public override void clicked()
        {
            // do nothing
        }

    }
}