using UnityEngine;
// using Photon.Pun;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Transform target;
    [SerializeField] private float maxHp;
    public float hp;

    [Header("Hurt")]
    private SpriteRenderer sp;
    public float hurtLength;//MARKER 效果持续多久
    private float hurtCounter;//MARKER 相当于计数器

    private void Start()
    {
        if(!GameObject.FindGameObjectWithTag("Player")) return;
        hp = maxHp;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        sp = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // FollowPlayer();

        hurtCounter -= Time.deltaTime;
        // if (hurtCounter <= 0)
        //     sp.material.SetFloat("_FlashAmount", 0);
    }

    // private void FollowPlayer()
    // {
    //     transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    // }

    public void TakenDamage(float _amount)
    {
        hp -= _amount;
        // HurtShader();
        if (hp <= 0)
            Destroy(gameObject);
    }

    // private void HurtShader()
    // {
    //     sp.material.SetFloat("_FlashAmount", 1);
    //     hurtCounter = hurtLength;
    // }

}
