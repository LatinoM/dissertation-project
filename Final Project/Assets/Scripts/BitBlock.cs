using TMPro;
using UnityEngine;
namespace Blocks
{
    public class BitBlock : BuildingBlock<int>
    {
        public TextMeshPro textMeshPro;

        void OnEnable()
        {
            this.val = 0;
            this.type = "bit";
            initialise();
        }

        protected override void initialise()
        {
            Transform textMeshProTransform = transform.Find("BitText");
            textMeshPro = textMeshProTransform.GetComponent<TextMeshPro>();
        }

        void Update()
        {
            if (textMeshPro != null)
            {
                textMeshPro.text = this.val.ToString();
            }
        }

        void OnMouseDown()
        {
            //Debug.Log("Bit Block has been clicked!");
            if (this.val == 0)
                this.val = 1;
            else
                this.val = 0;
        }

    }
}