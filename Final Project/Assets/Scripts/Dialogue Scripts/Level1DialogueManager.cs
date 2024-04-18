using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1DialogueManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<DialogueTrigger>().TriggerDialogue();
    }

}
