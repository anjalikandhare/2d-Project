using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {
    public TMP_Text _name;
    public TMP_Text Conversation;
    private Queue<string> sentences;
    public Spawner spawner;
    public Player player;

    void Start() {
        sentences = new Queue<string>();
    }
    void Update() {

        if (spawner.cine == true) {

            player.cinematics = true;
            player.runSpeed = 0;
            Vector3 Temp = player.transform.localScale;
            Temp.x = -4;
            player.transform.localScale = Temp;
            FindObjectOfType<DialogueTrigger>().TriggerDialouge();
            FindObjectOfType<Canvas>().enabled = true;

            if (Input.GetKeyDown(KeyCode.Z)) {
                DisplayNextSentence();
            }

        } else {

            player.cinematics = false;
            player.runSpeed = player.runSpeedBak;
            FindObjectOfType<Canvas>().enabled = false;

        }
    }

    public void StartDialogue (Dialogue dialogue) {
        sentences.Clear();

        _name.SetText(dialogue.name);

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
    }

    public void DisplayNextSentence() {
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        if (sentences.Count == 0) {
            EndDialogue();
            return;
        }
    }

    IEnumerator TypeSentence (string sentence) {
        Conversation.SetText("");
        foreach (char letter in sentence.ToCharArray())
        {
            Conversation.text += letter;
            yield return null;
        }
    }

    void EndDialogue() {

        Debug.Log("End Of Coversation");

    }

}