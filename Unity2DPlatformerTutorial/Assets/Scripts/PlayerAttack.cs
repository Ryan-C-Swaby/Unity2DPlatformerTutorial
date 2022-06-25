using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    private MovePlayer movePlayer;
    public float AttackCoolDown;
    private float CooldownTimer = Mathf.Infinity;
    public Transform FirePoint;
    public GameObject[] Fireballs;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        movePlayer = GetComponent<MovePlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && CooldownTimer > AttackCoolDown && movePlayer.CanAttack())
        {
            Attack();
        }

        CooldownTimer += Time.deltaTime;
    }

    void Attack()
    {
        CooldownTimer = 0;
        animator.SetTrigger("Attack");

        Fireballs[0].transform.position = FirePoint.position;
        Fireballs[0].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
}
