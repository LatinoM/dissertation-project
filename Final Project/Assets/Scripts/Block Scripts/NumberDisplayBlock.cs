using TMPro;
using UnityEngine;
namespace Blocks
{
    public class NumberDisplayBlock : BuildingBlock<int>
    {
        public TextMeshPro textMeshPro;
        public bool preset;
        public int presetValue;


        void OnEnable()
        {
            this.type = BuildingBlock<int>.Type.NUM_OUT;
            initialise();
            if (preset)
            {
                this.val = presetValue;
            }

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
            if (!preset)
            {
                this.val = this.next.getVal();
            }

        }

        public override void clicked()
        {
            return;
        }
    }
}