﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public void TriggerDialouge() {
       FindObjectOfType<GameManager>().StartDialogue(dialogue);
   }
}
