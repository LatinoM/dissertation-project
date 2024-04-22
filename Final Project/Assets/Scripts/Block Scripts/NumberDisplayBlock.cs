using TMPro;
using UnityEngine;
namespace Blocks
{
    public class NumberDisplayBlock : BuildingBlock<int>
    {
        public TextMeshPro textMeshPro;


        void OnEnable()
        {
            this.type = BuildingBlock<int>.Type.NUM_OUT;
            initialise();
            this.val = 0;
        }

        protected override void initialise()
        {
            Transform textMeshProTransform = transform.Find("NumOutput");
            textMeshPro = textMeshProTransform.GetComponent<TextMeshPro>();
        }

        void Update()
        {
            if (textMeshPro != null)
            {
                textMeshPro.text = this.val.ToString();
            }
            this.val = this.next.getVal();
        }

        public override void clicked()
        {
            return;
        }
    }
}