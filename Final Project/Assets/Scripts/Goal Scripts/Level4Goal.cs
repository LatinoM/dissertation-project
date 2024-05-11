using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Blocks
{
    public class Level4Goal : MonoBehaviour
    {
        public int numOfSecondsToSwitch = 5;
        public MathBlock mathBlock;

        private bool switching = false;
        public MathBlock.OperatorType operatorGoalValue = MathBlock.OperatorType.MULT;


        void Update()
        {
            bool operatorCorrect = mathBlock.getOperator() == operatorGoalValue;
            if (!switching && operatorCorrect)
            {
                StartCoroutine(IStartNextScene());
            }
        }

        IEnumerator IStartNextScene()
        {
            switching = true;
            yield return new WaitForSeconds(numOfSecondsToSwitch);
            SceneManager.LoadScene("Level 4a");
        }
    }
}
