using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Blocks
{
    public class Level7aGoal : MonoBehaviour
    {
        public int numOfSecondsToSwitch = 3;
        public NumberDisplayBlock numberDisplayBlock;
        bool switching;

        public int goalValue = 6;
        void Update()
        {
            if (!switching && numberDisplayBlock.getVal() == goalValue)
            {
                StartCoroutine(IStartNextScene());
            }
        }

        IEnumerator IStartNextScene()
        {
            switching = true;
            yield return new WaitForSeconds(numOfSecondsToSwitch);
            SceneManager.LoadScene("Level 7b");
        }

    }
}
