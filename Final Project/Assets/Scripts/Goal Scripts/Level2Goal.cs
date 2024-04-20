using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Blocks
{

    public class Level2Goal : MonoBehaviour
    {

        public int numOfSecondsToSwitch = 1;

        public BitNumberBlock bitNumberBlock;

        private bool switching = false;

        public int goalValue = 13;

        // Update is called once per frame
        void Update()
        {
            if (!switching && bitNumberBlock.getVal() == goalValue)
            {
                StartCoroutine(IStartNextScene());
            }
        }

        IEnumerator IStartNextScene()
        {
            switching = true;
            yield return new WaitForSeconds(numOfSecondsToSwitch);
            SceneManager.LoadScene("Level 1 - Bits");

        }
    }
}