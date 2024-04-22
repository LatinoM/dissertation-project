using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Blocks
{
    public class Level4Goal : MonoBehaviour
    {
        public int numOfSecondsToSwitch = 1;
        public BitNumberBlock bitNumberBlockTop;
        public BitNumberBlock bitNumberBlockBottom;
        public MathBlock mathBlock;

        public NumberDisplayBlock numberDisplayBlock;

        private bool switching = false;
        public int operandGoalValue = 2;
        public MathBlock.OperatorType operatorGoalValue = MathBlock.OperatorType.MULT;

        public int finalGoalValue = 14;

        void Update()
        {
            bool operandCorrect = bitNumberBlockTop.getVal() == operandGoalValue || bitNumberBlockBottom.getVal() == operandGoalValue;
            bool operatorCorrect = mathBlock.getOperator() == operatorGoalValue;
            bool valueCorrect = numberDisplayBlock.getVal() == finalGoalValue;
            if (!switching && operandCorrect && operatorCorrect && valueCorrect)
            {
                StartCoroutine(IIsStillCorrect());
            }
        }

        IEnumerator IStartNextScene()
        {
            switching = true;
            yield return new WaitForSeconds(numOfSecondsToSwitch);
            SceneManager.LoadScene("Level 1 - Bits");
        }

        IEnumerator IIsStillCorrect()
        {
            // Used to make sure the correct value is intentionally set
            yield return new WaitForSeconds(1);
            bool operandCorrect = bitNumberBlockTop.getVal() == operandGoalValue || bitNumberBlockBottom.getVal() == operandGoalValue;
            bool operatorCorrect = mathBlock.getOperator() == operatorGoalValue;
            bool valueCorrect = numberDisplayBlock.getVal() == finalGoalValue;
            if (!switching && operandCorrect && operatorCorrect && valueCorrect)
            {
                StartCoroutine(IStartNextScene());
            }
        }
    }
}
