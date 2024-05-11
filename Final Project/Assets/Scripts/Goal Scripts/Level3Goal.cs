using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Blocks
{


    public class Level3Goal : MonoBehaviour
    {
        public int numOfSecondsToSwitch = 3;
        public CompareNumBlock compareNumBlock;
        private bool switching = false;
        public CompareNumBlock.CompType compGoalValue = CompareNumBlock.CompType.GT;

        void Update()
        {
            bool compCorrect = compareNumBlock.getMode() == compGoalValue;
            if (!switching && compCorrect)
            {
                StartCoroutine(IStartNextScene());
            }
            //Debug.Log(boolCorrect);
        }

        IEnumerator IStartNextScene()
        {
            switching = true;
            yield return new WaitForSeconds(numOfSecondsToSwitch);
            SceneManager.LoadScene("Level 3a");
        }



    }
}