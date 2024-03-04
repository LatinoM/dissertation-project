using TMPro;
using UnityEngine;
namespace Blocks
{


    public class BoolOutputBlock : BuildingBlock<bool>
    {
        public TextMeshPro textMeshPro;
        void OnEnable()
        {
            this.type = BuildingBlock<bool>.Type.BOOL_OUT;
            initialise();
            this.val = false;
        }

        protected override void initialise()
        {
            Transform textMeshProTransform = transform.Find("BoolOutText");
            textMeshPro = textMeshProTransform.GetComponent<TextMeshPro>();
        }

        void Update()
        {
            if (textMeshPro != null)
            {
                if (this.val)
                {
                    textMeshPro.text = "T";
                    textMeshPro.color = Color.green;
                }
                else
                {
                    textMeshPro.text = "F";
                    textMeshPro.color = Color.red;
                }
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