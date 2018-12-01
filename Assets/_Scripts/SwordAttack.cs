using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{

    [SerializeField] Transform sword;

    [SerializeField] float attackRate = .5f;
    [SerializeField]bool canAtack = true;
    Animator anim;

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.L) && canAtack) {
            canAtack = false;
            anim.Play("SwordAttack");
            StartCoroutine(Resetfire());
        }
    }

    IEnumerator Resetfire() {
        yield return new WaitForSeconds(attackRate);
        canAtack = true;
        anim.Play("SwordIdle");
    }
}
