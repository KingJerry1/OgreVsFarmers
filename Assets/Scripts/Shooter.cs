using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, shootingPoint;
    AttackerSpawner myLaneSpawner;
    Animator animator;
    public void Fire() {
        Instantiate(projectile, shootingPoint.transform.position, transform.rotation);
    }

    public void Update() {
        if(IsAttackerInLane()) {
            animator.SetBool("isAttacking", true);
        }
        else {
            animator.SetBool("isAttacking", false);
        }
    }

    private void Start() {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
    }

    private void SetLaneSpawner() {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach(AttackerSpawner spawner in spawners) {
            bool IsCloseEnought = (Mathf.Abs(spawner.transform.position.y - transform.position.y) < Mathf.Epsilon);
            if(IsCloseEnought) {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane() {
        if(myLaneSpawner.transform.childCount <= 0) {
            return false;
        }
        else {
            return true;
        }
    }
}
