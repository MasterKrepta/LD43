using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{

    [SerializeField] Transform sword;

    [SerializeField] float attackRate = .45f;
    [SerializeField]bool canAtack = true;
    Animator anim;

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
        sword.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (!GameManager.IsPaused && GameManager.SwordIsEnabled) {
            if (Input.GetMouseButtonDown(1) && canAtack) {
                //if (Input.GetKey(KeyCode.L) && canAtack) {
                canAtack = false;
                sword.gameObject.SetActive(true);
                anim.Play("SwordAttack");
                StartCoroutine(Resetfire());
            }
        }
    }

    IEnumerator Resetfire() {
        yield return new WaitForSeconds(attackRate);
        sword.gameObject.SetActive(false);
        canAtack = true;
        anim.Play("SwordIdle");
    }
}
