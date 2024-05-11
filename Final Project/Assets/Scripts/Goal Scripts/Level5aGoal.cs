using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Blocks
{
    public class Level5aGoal : MonoBehaviour
    {
        public int numOfSecondsToSwitch = 3;
        public BitNumberBlock bitNumBlock;


        private bool switching = false;
        public int goalValue = 5;

        void Update()
        {

            if (!switching && bitNumBlock.getVal() == goalValue)
            {
                StartCoroutine(IIsStillCorrect());
            }
        }

        IEnumerator IStartNextScene()
        {
            switching = true;
            yield return new WaitForSeconds(numOfSecondsToSwitch);
            SceneManager.LoadScene("Level 6 - Arrays");
        }
        IEnumerator IIsStillCorrect()
        {
            // Used to make sure the correct value is intentionally set
            yield return new WaitForSeconds(1);
            if (!switching && bitNumBlock.getVal() == goalValue)
            {
                StartCoroutine(IStartNextScene());
            }
        }
    }
}