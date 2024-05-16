using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Blocks
{
    public class Level10aGoal : MonoBehaviour
    {
        public int numOfSecondsToSwitch = 3;
        bool switching;
        public CompareNumBlock compNumBlock;
        public BoolOutputBlock boolOutputBlock;
        public bool goalValue = true;
        public CompareNumBlock.CompType compType = CompareNumBlock.CompType.LT;

        void Update()
        {
            bool correctMode = compNumBlock.getMode() == compType;
            bool correctResult = boolOutputBlock.getVal() == goalValue;
            if (!switching && correctMode && correctResult)
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
