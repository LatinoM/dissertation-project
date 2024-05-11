using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Blocks
{


    public class Level3aGoal : MonoBehaviour
    {
        public int numOfSecondsToSwitch = 2;

        public CompareNumBlock compareNumBlock;

        public BoolOutputBlock boolOutputBlock;

        private bool switching = false;

        public bool boolGoalValue = true;
        public CompareNumBlock.CompType compGoalValue = CompareNumBlock.CompType.LT;

        void Update()
        {
            bool boolCorrect = boolOutputBlock.getVal() == boolGoalValue;
            bool compCorrect = compareNumBlock.getMode() == compGoalValue;
            if (!switching && boolCorrect && compCorrect)
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
            if (!switching && boolCorrect && compCorrect)
            {
                StartCoroutine(IStartNextScene());
            }
        }

    }
}