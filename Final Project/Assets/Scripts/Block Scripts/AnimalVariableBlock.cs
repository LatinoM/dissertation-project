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

        int currentIndex;

        void OnEnable()
        {
            initialise();
        }

        protected override void initialise()
        {
            currentIndex = 0;
            this.val = false;
        }

        public override void clicked()
        {
            if (currentIndex++ >= 3)
            {
                currentIndex = 0;
            }
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
    }


}
