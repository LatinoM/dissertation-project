using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Blocks
{
    public class Level4aGoal : MonoBehaviour
    {
        public int numOfSecondsToSwitch = 2;
        public MathBlock mathBlock;

        public NumberDisplayBlock numberDisplayBlock;

        private bool switching = false;
        public MathBlock.OperatorType operatorGoalValue = MathBlock.OperatorType.MULT;

        public int finalGoalValue = 14;

        void Update()
        {
            bool operatorCorrect = mathBlock.getOperator() == operatorGoalValue;
            bool valueCorrect = numberDisplayBlock.getVal() == finalGoalValue;
            if (!switching && operatorCorrect && valueCorrect)
            {
                StartCoroutine(IIsStillCorrect());
            }
        }

        IEnumerator IStartNextScene()
        {
            switching = true;
            yield return new WaitForSeconds(numOfSecondsToSwitch);
            SceneManager.LoadScene("Level 5 - Variables");
        }

        IEnumerator IIsStillCorrect()
        {
            // Used to make sure the correct value is intentionally set
            yield return new WaitForSeconds(1);
            bool operatorCorrect = mathBlock.getOperator() == operatorGoalValue;
            bool valueCorrect = numberDisplayBlock.getVal() == finalGoalValue;
            if (!switching && operatorCorrect && valueCorrect)
            {
                StartCoroutine(IStartNextScene());
            }
        }
    }
}
