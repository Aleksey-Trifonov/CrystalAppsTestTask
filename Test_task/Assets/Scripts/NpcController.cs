using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    [SerializeField]
    private GameObject dialogueMark = null;

    private Animator animator = null;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var playerController = other.GetComponent<PlayerController>();
        if (playerController)
        {
            playerController.StartDialogue();
            StartDialogue();
        }
    }

    private void StartDialogue()
    {
        dialogueMark.SetActive(false);
        animator.SetTrigger("Begin_dialogue");
    }
}
