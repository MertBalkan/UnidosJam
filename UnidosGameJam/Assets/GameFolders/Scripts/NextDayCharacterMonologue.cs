using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnidosJam
{
    public class NextDayCharacterMonologue : MonoBehaviour
    {
        [SerializeField] private GameObject monologueBox;
        [SerializeField] private DialogueController dialogue;
        [SerializeField] private MonologScriptableObject[] monologScriptableObjects;


        private float _nothingToDoSec = 999;
        private float _currentTimeNothingToDo;
        
        private float _shouldReplySec = 1;
        private float _currentShouldReply;

        private void Start()
        {
            monologueBox.gameObject.SetActive(false);
        }

        private void Update()
        {
            _currentTimeNothingToDo += Time.deltaTime;
            _currentShouldReply += Time.deltaTime;

            Debug.Log(_currentTimeNothingToDo);
            
            if (_currentTimeNothingToDo >= _nothingToDoSec) _currentTimeNothingToDo = _nothingToDoSec;
            if (_currentShouldReply >= _shouldReplySec) _currentShouldReply = _shouldReplySec;
            
        }

        public void NothingToDoMonologue()
        {
            monologueBox.gameObject.SetActive(true);
            dialogue.StartDialogue(monologScriptableObjects[0].monologData.monologTexts.ToArray());
              
            if (_currentTimeNothingToDo >= _nothingToDoSec)
            {
                monologueBox.gameObject.SetActive(false);
                _currentTimeNothingToDo = 0;
            } 
        }
        
        
        public void ShouldReplyMonologue()
        {
            monologueBox.gameObject.SetActive(true);
            dialogue.StartDialogue(monologScriptableObjects[1].monologData.monologTexts.ToArray());
              
            if (_currentShouldReply >= _shouldReplySec)
            {
                monologueBox.gameObject.SetActive(false);
                _currentShouldReply = 0;
            } 
        }
    }   
}