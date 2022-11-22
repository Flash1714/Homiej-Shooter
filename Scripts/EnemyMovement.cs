using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public float moveSpeed;
    public float hp;
    public int collisionDamage;
    public GameObject bulletParticle;
    public GameObject collideParticle;
    public GameObject bulletHitSound;
    public GameObject playerHitSound;
    private Transform target;

    private void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null) return;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().health -= collisionDamage;
            Instantiate(collideParticle, transform.position, Quaternion.identity);
            Instantiate(playerHitSound, transform.position,Quaternion.identity);
            Destroy(gameObject);
            if (collision.GetComponent<Player>().health <= 0)
            {
                if (gameObject.CompareTag("Abd"))
                {
                    SceneManager.LoadScene("AbdRestart");
                }
                else if (gameObject.CompareTag("Bangi"))
                {
                    SceneManager.LoadScene("BangiRestart");
                }
                else if (gameObject.CompareTag("Mota"))
                {
                    SceneManager.LoadScene("MotaRestart");
                }
                else
                {
                    SceneManager.LoadScene("PintuRestart");
                }
            }
        }
        else if (collision.CompareTag("Bullet"))
        {
            Instantiate(bulletParticle,transform.position, Quaternion.identity);
            Instantiate(bulletHitSound, transform.position, Quaternion.identity);
            hp -= 1;
            
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
        if(hp <= 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().score += 1 ;
            Destroy(gameObject);
        }
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }

}
