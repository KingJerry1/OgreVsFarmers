﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 5f)] float currentSpeed = 1f;
    GameObject currentTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();
    }

    private void Awake() {
        FindObjectOfType<LevelController>().AttackerSpawden();
    }

    private void OnDestroy() {
        FindObjectOfType<LevelController>().AttackerKilled();
    }

    private void UpdateAnimationState() {
        if(!currentTarget) {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }

    public void SetMovementSpeed(float speed) {
        currentSpeed = speed;
    }

    public void Attack(GameObject target) {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage) {
        if (!currentTarget) {
            return;
        }
        Health health = currentTarget.GetComponent<Health>();
        if (health) {
            health.DealDamage(damage);
        }
    }
}
