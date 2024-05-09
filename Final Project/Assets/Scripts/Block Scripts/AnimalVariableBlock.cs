using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Blocks
{
    struct Animal
    {
        public bool makesNoise;
        public int numOfLegs;
        public bool hasTail;
        public int numOfEyes;


        public Animal(bool makesNoise, int numOfLegs,
            bool hasTail, int numOfEyes)
        {
            this.makesNoise = makesNoise;
            this.numOfLegs = numOfLegs;
            this.hasTail = hasTail;
            this.numOfEyes = numOfEyes;
        }
    }

    public class AnimalVariableBlock : BuildingBlock<bool>
    {
        Animal[] animals = {
            new Animal(true, 4, true, 2), // Dog
            new Animal(false, 6, false, 2), // Ant
            new Animal(true, 6, false, 5) // Fly
        };

        public GameObject spriteObj;

        Sprite dogSprite;
        Sprite antSprite;
        Sprite flySprite;

        int currentIndex;

        void OnEnable()
        {
            dogSprite = Resources.Load("dog", typeof(Sprite)) as Sprite;
            antSprite = Resources.Load("ant", typeof(Sprite)) as Sprite;
            flySprite = Resources.Load("fly", typeof(Sprite)) as Sprite;
            initialise();
        }

        protected override void initialise()
        {
            currentIndex = 0;
            this.val = false;
        }

        public override void clicked()
        {
            if (currentIndex == 2)
            {
                currentIndex = 0;
            }
            else
            {
                currentIndex++;
            }
            switchImage();
            //Debug.Log("Current index: " + currentIndex);
        }

        public bool getNoise()
        {
            return this.animals[currentIndex].makesNoise;
        }

        public int getLegs()
        {
            return this.animals[currentIndex].numOfLegs;
        }

        public bool getTail()
        {
            return this.animals[currentIndex].hasTail;
        }

        public int getEyes()
        {
            return this.animals[currentIndex].numOfEyes;
        }

        void switchImage()
        {
            switch (this.currentIndex)
            {
                case 0:
                    spriteObj.GetComponent<SpriteRenderer>().sprite = dogSprite;
                    return;
                case 1:
                    spriteObj.GetComponent<SpriteRenderer>().sprite = antSprite;
                    return;
                default:
                    spriteObj.GetComponent<SpriteRenderer>().sprite = flySprite;
                    return;
            }
        }
    }


}
