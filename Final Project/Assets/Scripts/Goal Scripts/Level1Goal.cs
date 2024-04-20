using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Blocks
{
    public class Level1Goal : MonoBehaviour
    {

        public int numOfSecondsToSwitch = 5;
        public BitBlock bitBlock;

        private bool switching = false;

        public int goalValue = 1;

        // Update is called once per frame
        void Update()
        {
            if (!switching && bitBlock.getVal() == goalValue)
            {
                StartCoroutine(IStartNextScene());
            }
        }

        IEnumerator IStartNextScene()
        {
            switching = true;
            yield return new WaitForSeconds(numOfSecondsToSwitch);
            SceneManager.LoadScene("Level 2 - Numbers");

        }
    }
}