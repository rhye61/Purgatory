using System;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    public int health;
    public float speed;

    public GameObject BloodEffect;

    public bool FindPlayer;

    public Animator enemyAnim;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (health <= 0)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        Instantiate(BloodEffect, transform.position, Quaternion.identity);
        health -= damage;
        Debug.Log("Damage Taken");
    }

    void GiveDamage()
    {
        if (FindPlayer)
        {
            if (GameObject.FindGameObjectWithTag("Player"))
            {
                GetComponent<Health>().Damaged();
            }
        }
    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "Player")//or tag
        {
            collision.GetComponent<Health>().Damaged();
        }
    }
}
