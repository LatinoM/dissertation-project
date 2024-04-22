using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Blocks
{


    public class Level3Goal : MonoBehaviour
    {
        public int numOfSecondsToSwitch = 1;

        public BitNumberBlock bitNumberBlock;

        public CompareNumBlock compareNumBlock;

        public BoolOutputBlock boolOutputBlock;

        private bool switching = false;

        public bool boolGoalValue = true;
        public CompareNumBlock.CompType compGoalValue = CompareNumBlock.CompType.GT;
        public int numberGoalValue = 5;

        void Update()
        {
            bool boolCorrect = boolOutputBlock.getVal() == boolGoalValue;
            bool compCorrect = compareNumBlock.getMode() == compGoalValue;
            bool numberCorrect = bitNumberBlock.getVal() == numberGoalValue;
            if (!switching && boolCorrect && compCorrect && numberCorrect)
            {
                StartCoroutine(IIsStillCorrect());
            }
            //Debug.Log(boolCorrect);
        }

        IEnumerator IStartNextScene()
        {
            switching = true;
            yield return new WaitForSeconds(numOfSecondsToSwitch);
            SceneManager.LoadScene("Level 4 - Arithmetic");
        }

        IEnumerator IIsStillCorrect()
        {
            // Used to make sure the correct value is intentionally set
            yield return new WaitForSeconds(1);
            bool boolCorrect = boolOutputBlock.getVal() == boolGoalValue;
            bool compCorrect = compareNumBlock.getMode() == compGoalValue;
            bool numberCorrect = bitNumberBlock.getVal() == numberGoalValue;
            if (!switching && boolCorrect && compCorrect && numberCorrect)
            {
                StartCoroutine(IStartNextScene());
            }
        }

    }
}