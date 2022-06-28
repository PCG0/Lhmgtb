using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class 阿苇 : MonoBehaviourPun
{
    #region 组件
        private Rigidbody2D rb;
        // private SpriteRenderer sr;
    #endregion

    #region 参数
        [Header("移动")]
            public float moveSpeed = 3.5f;//人物移动速度
            Vector2 move;
            public float linearDrag=40f;// 减速
            public float targetSpeed=3.5f;// 最大速度
            public float acceleration=50f;// 加速度
        
        [Header("跳跃")]
            public float JumpUpGraivity;
            public float FallDownGraivity;
            public float jumpForce=4f;//跳跃力
            public float jumpholdforce;
            public float fallMultiplier=2.5f;
            public float lowJumpMultiplier=2f;
            float jumpTime;
            bool isGroud;
            public LayerMask ground;
    
        [Header("冲刺")]
            public float dashForce;
            bool isDash;
            float resumeTime;
            float direction;
            public float dashTime;
        
    
        [Header("死亡")]
            private float deadLiney = -25f;
    
        [Header("动画")]
            public Animator anima;
    
        // [Header("杂项")]
            // public int mCollisionObjectCount = 0;
            // public ParticleSystem playerPS;
            //public int damage;
    #endregion

    #region 预制件
        public GameObject ghostObject;
        public int ghostNum = 5;
        float ghostTime;
    #endregion

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // sr = GetComponent<SpriteRenderer>();
        //rb.gravityScale = 4; 
        // jumpForce = 4.5f;
        // jumpholdforce = 0.35f;
        // JumpUpGraivity = 1.5f;
        // FallDownGraivity = 3;
    }

    
    //private void OnTriggerEnter2D(Collider2D other){
    //    if (other.gameObject.CompareTag("Enemy")){
    //        other.gameObject.GetComponent<Enemy>().TakeDamage(damage);
    //    }
    //}

    //private void FollowMouseRotate()
    //{
    //    //获取鼠标的坐标，鼠标是屏幕坐标，Z轴为0，这里不做转换  
    //    Vector3 mouse = Input.mousePosition;
    //    //获取物体坐标，物体坐标是世界坐标，将其转换成屏幕坐标，和鼠标一直  
    //    Vector3 obj = Camera.main.WorldToScreenPoint(_turret.position);
    //    //屏幕坐标向量相减，得到指向鼠标点的目标向量，即黄色线段  
    //    Vector3 direction = mouse - obj;
    //    //将Z轴置0,保持在2D平面内  
    //    direction.z = 0f;
    //    //将目标向量长度变成1，即单位向量，这里的目的是只使用向量的方向，不需要长度，所以变成1  
    //    direction = direction.normalized;
    //    //物体自身的Y轴和目标向量保持一直，这个过程XY轴都会变化数值  
    //    //枪口.up = direction;
    //}

    // private Vector2 GetInput()
    // {
    //     return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vetical"));
    // }
    public void FixedUpdate()
    {
        var moveX = Input.GetAxis("Horizontal");
        // rb.gravityScale = 2f;
        rb.AddForce(new Vector2(moveX, 0) * acceleration);
        if(Mathf.Abs(rb.velocity.x) > targetSpeed)
        {
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * targetSpeed, rb.velocity.y);// 限制速度
            rb.gravityScale = 2f;
        }
        if(Mathf.Abs(moveX) < 0.4f)
        {
            rb.drag = linearDrag;
            rb.gravityScale = 2f;
        }
        else
        {
            rb.drag = 0f;
            rb.gravityScale = 2f;
        }
        if(Input.GetKeyUp("A") && Input.GetKeyUp("D"))
            rb.gravityScale = 2f;

        // isGroud = rb.IsTouchingLayers(ground);
        // if (Input.GetKeyDown(KeyCode.Space) && isGroud){
        //     //PPS();
        //     //rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        //     jumpTime = Time.time + 0.05f;
        //     //anima.SetBool("isJumping", true);
        //     rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        // }

        // if (Input.GetKey(KeyCode.Space) && !isGroud  && Time.time < jumpTime){
        //     //PPS();
        //     rb.AddForce(new Vector2(0, jumpholdforce), ForceMode2D.Impulse);
        // }
        // if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space)) 
        //     rb.gravityScale = JumpUpGraivity;//跳跃时的重力
        // else 
        //     rb.gravityScale = FallDownGraivity;//下落时的重力
    }


    public void Update()
    {
        var moveX = Input.GetAxis("Horizontal");

        // move = GetInput();
        if (!photonView.IsMine && PhotonNetwork.IsConnected) return;

        //float moveX = Input.GetAxis("Horizontal");
        //rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);
        
        //rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);
        
            //跳跃
        
        // if (Input.GetKeyDown(KeyCode.Space) && isGroud){
        //     //PPS();
        //     //rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        //     jumpTime = Time.time + 0.05f;
        //     //anima.SetBool("isJumping", true);
        //     rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        // }

        // if (Input.GetKey(KeyCode.Space) && !isGroud  && Time.time < jumpTime){
        //     //PPS();
        //     rb.AddForce(new Vector2(0, jumpholdforce), ForceMode2D.Impulse);
        // }
        isGroud = rb.IsTouchingLayers(ground);
        if(Input.GetKeyDown(KeyCode.Space) && isGroud)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
        }
        // if(rb.velocity.y < 0)
        //     rb.gravityScale = jumpholdforce;
        // else if(rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        //     rb.gravityScale = FallDownGraivity;
        // else rb.gravityScale = jumpForce;
        else rb.gravityScale = 2f;

        if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space)) 
            rb.gravityScale = JumpUpGraivity;//跳跃时的重力
        else 
            rb.gravityScale = 2f;//下落时的重力
        

        
        // //移动
        // var moveX = Input.GetAxis("Horizontal");
        // if (!isDash){
        //     //PPSD();
        //     rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);
        //     rb.angularVelocity = rb.velocity.x / 0.5f * Mathf.Rad2Deg;
        //     // anima.SetFloat("isRunning", Mathf.Abs(moveX));
        // }
        // if (Time.time > resumeTime){
        //     isDash = false;
        //     rb.gravityScale = 4;
        // }
        // if (isDash && Time.time > ghostTime){
        //     Instantiate(ghostObject, transform.position, Quaternion.identity);
        //     ghostTime = Time.time + dashTime / ghostNum;
        // }
        
        //转身
        // if (moveX > 0)
        // {
        //     // PPS();
        //     // transform.localScale = new Vector3(1, 1, 1);
        //     // 这里不再使用 localSacle 的原因是我在 BV1qt4y1U7aS 中得知使用角度旋转的话，自身坐标系也会跟着转。
        //     transform.eulerAngles = new Vector3(0, 0, 0);
        //     // sr.flipX = false;
        // }

        // if (moveX < 0)
        // {
        //         //PPS();
        //         // transform.localScale = new Vector3(-1, 1, 1);
        //         transform.eulerAngles = new Vector3(0, 180, 0);
        //         // sr.flipX = true;
        // } 
        
        if (transform.position.x < Camera.main.ScreenToWorldPoint(Input.mousePosition).x) 
            // transform.eulerAngles = new Vector3(0, 0, 0);
            transform.GetChild(0).eulerAngles = new Vector3(0, 0, 0);
        if (transform.position.x > Camera.main.ScreenToWorldPoint(Input.mousePosition).x)
            // transform.localScale = new Vector3(-1, 1, 1);
            transform.GetChild(0).eulerAngles = new Vector3(0, 180, 0);
        
        

        
            //冲刺
        // if (Input.GetKeyDown("left shift"))
        // {
        //     isDash = true;
        //     resumeTime = Time.time + dashTime;
        //     rb.velocity = new Vector2(moveX * dashForce, 0);
        //     rb.gravityScale = 0;
        // }
        // if(resumeTime >= Time.time)
        // {
        //     isDash = false;
        //     resumeTime = 0;
        // } 
        
        //死亡回归
        if (transform.position.y < deadLiney)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (transform.position.y < deadLiney)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (transform.position.y < deadLiney)
        {
            GetComponent<AudioSource>().enabled = false;
            Invoke("Restart", 2f);
            if (!photonView.IsMine && PhotonNetwork.IsConnected) return;
        }
    }

    //void PPS(){
    //    playerPS.Play();
    //}
    //void PPSD(){
    //    playerPS.Pause();
    //}
}