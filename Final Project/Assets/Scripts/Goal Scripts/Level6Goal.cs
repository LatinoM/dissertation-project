using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Blocks
{
    public class Level6Goal : MonoBehaviour
    {
        public int numOfSecondsToSwitch = 3;
        public NumberDisplayBlock numDisplayBlock;
        bool switching;
        public int goalValue = 3;

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
            SceneManager.LoadScene("Level 6a");
        }
    }
}