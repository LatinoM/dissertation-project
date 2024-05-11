using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Blocks
{
    public class Level6aGoal : MonoBehaviour
    {
        public int numOfSecondsToSwitch = 3;
        public NumberDisplayBlock numDisplayBlock;
        bool switching;
        public int goalValue = 35;

        void Update()
        {
            if (!switching && numDisplayBlock.getVal() == goalValue)
            {
                StartCoroutine(IIsStillCorrect());
            }
        }
        IEnumerator IStartNextScene()
        {
            switching = true;
            yield return new WaitForSeconds(numOfSecondsToSwitch);
            SceneManager.LoadScene("Level 7 - Conditions");
        }

        IEnumerator IIsStillCorrect()
        {
            // Used to make sure the correct value is intentionally set
            yield return new WaitForSeconds(1);
            if (!switching && numDisplayBlock.getVal() == goalValue)
            {
                StartCoroutine(IStartNextScene());
            }
        }
    }
}