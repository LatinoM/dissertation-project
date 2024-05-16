using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Blocks
{
    public class Level9aGoal : MonoBehaviour
    {
        public int numOfSecondsToSwitch = 3;
        bool switching;
        public NumberDisplayBlock numDisplayBlock;
        public int goalValue = 32;

        void Update()
        {
            if (!switching && numDisplayBlock.getVal() == goalValue)
            {
                StartCoroutine(IStartNextScene());
            }
        }

        IEnumerator IStartNextScene()
        {
            switching = true;
            yield return new WaitForSeconds(numOfSecondsToSwitch);
            SceneManager.LoadScene("Level 10 - Classes");
        }
    }
}
