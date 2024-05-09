using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Blocks
{
    public class AnimalAttributeBlock : BuildingBlock<int>
    {
        enum Attribute
        {
            NOISE,
            LEGS,
            TAIL,
            EYES
        }

        public int numVal;
        public bool boolVal;
        Attribute mode;
        public AnimalVariableBlock animalVariable;

        Sprite noiseSprite;
        Sprite legSprite;
        Sprite tailSprite;
        Sprite eyeSprite;

        public GameObject spriteObj;

        void OnEnable()
        {
            // Load Images
            noiseSprite = Resources.Load("noise", typeof(Sprite)) as Sprite;
            legSprite = Resources.Load("legs", typeof(Sprite)) as Sprite;
            tailSprite = Resources.Load("tail", typeof(Sprite)) as Sprite;
            eyeSprite = Resources.Load("eye", typeof(Sprite)) as Sprite;

            initialise();


        }

        protected override void initialise()
        {
            mode = Attribute.NOISE;
            this.numVal = -1;
            this.numVal = -1;
            this.boolVal = animalVariable.getNoise();


        }

        void Update()
        {
            switch (mode)
            {
                case Attribute.NOISE:
                    this.val = -1;
                    this.numVal = -1;
                    this.boolVal = animalVariable.getNoise();
                    break;
                case Attribute.LEGS:
                    this.numVal = animalVariable.getLegs();
                    this.val = numVal;
                    this.boolVal = false;
                    break;
                case Attribute.TAIL:
                    this.numVal = -1;
                    this.val = -1;
                    this.boolVal = animalVariable.getTail();
                    break;
                case Attribute.EYES:
                    this.numVal = animalVariable.getEyes();
                    this.val = numVal;
                    this.boolVal = false;
                    break;
            }
        }

        public override void clicked()
        {
            switch (mode)
            {
                case Attribute.NOISE:
                    mode = Attribute.LEGS;
                    this.numVal = animalVariable.getLegs();
                    this.boolVal = false;
                    break;
                case Attribute.LEGS:
                    mode = Attribute.TAIL;
                    this.numVal = -1;
                    this.boolVal = animalVariable.getTail();
                    break;
                case Attribute.TAIL:
                    mode = Attribute.EYES;
                    this.numVal = animalVariable.getEyes();
                    this.boolVal = false;
                    break;
                case Attribute.EYES:
                    mode = Attribute.NOISE;
                    this.numVal = -1;
                    this.boolVal = animalVariable.getNoise();
                    break;
            }
            switchImage(mode);
        }

        void switchImage(Attribute mode)
        {

            switch (mode)
            {
                case Attribute.NOISE:
                    spriteObj.GetComponent<SpriteRenderer>().sprite = noiseSprite;
                    return;
                case Attribute.LEGS:
                    spriteObj.GetComponent<SpriteRenderer>().sprite = legSprite;
                    return;
                case Attribute.TAIL:
                    spriteObj.GetComponent<SpriteRenderer>().sprite = tailSprite;
                    return;
                case Attribute.EYES:
                    spriteObj.GetComponent<SpriteRenderer>().sprite = eyeSprite;
                    return;
            }
        }




    }
}
