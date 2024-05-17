using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Blocks
{
    public class Level7bGoal : MonoBehaviour
    {
        public int numOfSecondsToSwitch = 3;
        public NumberDisplayBlock numberDisplayBlock;
        bool switching;

        public int goalValue = 1;
        void Update()
        {
            if (!switching && numberDisplayBlock.getVal() == goalValue)
            {
                StartCoroutine(IStillCorrect());
            }
        }

        IEnumerator IStartNextScene()
        {
            switching = true;
            yield return new WaitForSeconds(numOfSecondsToSwitch);
            SceneManager.LoadScene("Level 8 - Functions");
        }

        IEnumerator IStillCorrect()
        {
            yield return new WaitForSeconds(1.5f);
            if (numberDisplayBlock.getVal() == goalValue)
            {
                StartCoroutine(IStartNextScene());
            }
        }

    }
}
