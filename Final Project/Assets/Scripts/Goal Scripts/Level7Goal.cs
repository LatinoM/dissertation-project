using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Blocks
{
    public class Level7Goal : MonoBehaviour
    {
        public int numOfSecondsToSwitch = 3;
        public BoolOutputBlock boolOutputBlock;
        bool switching;

        public bool goalValue = false;
        void Update()
        {
            if (!switching && boolOutputBlock.getVal() == goalValue)
            {
                StartCoroutine(IStartNextScene());
            }
        }

        IEnumerator IStartNextScene()
        {
            switching = true;
            yield return new WaitForSeconds(numOfSecondsToSwitch);
            SceneManager.LoadScene("Level 7a");
        }

    }
}
