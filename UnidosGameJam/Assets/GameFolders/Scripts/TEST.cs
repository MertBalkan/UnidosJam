using System;
using System.Collections;
using System.Collections.Generic;
using UnidosJam;
using UnidosJam.Animations;
using UnityEditor.Rendering;
using UnityEngine;

public class TEST : MonoBehaviour
{
    [SerializeField] private DialogueController dialogue;
    
    private string[] text = new string[2];
    private DialogueAnimation _dialogueAnim;

    private void Awake()
    {
        _dialogueAnim = FindObjectOfType<DialogueAnimation>();
    }

    private void Start()
    {
        text[0] = "SEZOOOOOO";
        text[1] = "BIZ BU JAMI YAPICAZZZ <3";
        
        dialogue.StartDialogue(text);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _dialogueAnim.PlayAnimation();
            dialogue.ShowNextDialogue();
        }
    }
}
