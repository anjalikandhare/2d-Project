using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {
    public TMP_Text _name;
    string sentence;
    public TMP_Text Conversation;
    private Queue<string> sentences;
    public Spawner spawner;
    public Player player;

    bool trig = true;
    bool cinea = false;

    void Start() {
        sentences = new Queue<string>();
    }
    void Update() {
        Debug.Log(sentences.Count);

        if (spawner.cine == true && trig == true) {
            
            cinea = true;
            FindObjectOfType<DialogueTrigger>().TriggerDialouge();
            trig = false;

        }

        if (spawner.cine == true) {
            if (Input.GetKeyDown(KeyCode.Z)) {
                DisplayNextSentence();
            }
        } else {
            player.cinematics = false;
            player.runSpeed = player.runSpeedBak;
            FindObjectOfType<Canvas>().enabled = false;
            cinea = false;
        }

        if (cinea) {
            player.cinematics = true;
            player.runSpeed = 0;
            Vector3 Temp = player.transform.localScale;
            Temp.x = -4;
            player.transform.localScale = Temp;
            FindObjectOfType<Canvas>().enabled = true;
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
        if (sentences.Count == 0) {
            EndDialogue();
            return;
        }
        sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        
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