using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class 阿苇 : MonoBehaviourPun
{
    #region 组件
    private Rigidbody2D rb;
    #endregion

    #region 参数
    [Header("移动")]
    public float moveSpeed = 3.5f;//人物移动速度
    
    [Header("跳跃")]
    public float JumpUpGraivity;
    public float FallDownGraivity;
    public float jumpForce;//跳跃力
    public float jumpholdforce;
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

    [Header("杂项")]
    public int mCollisionObjectCount = 0;
    public ParticleSystem playerPS;
    //public int damage;

    #endregion

    #region 预制件
    public GameObject ghostObject;
    public int ghostNum = 5;
    float ghostTime;
    #endregion

    public void Start(){
        rb = GetComponent<Rigidbody2D>();
        //rb.gravityScale = 4;
        jumpForce = 4.5f;
        jumpholdforce = 0.35f;
        JumpUpGraivity = 1.5f;
        FallDownGraivity = 3;
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

    public void Update(){
        if (!photonView.IsMine && PhotonNetwork.IsConnected)
            return;

        //移动
        //float moveX = Input.GetAxis("Horizontal");
        //rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);
        var moveX = Input.GetAxis("Horizontal");
        //rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);
        
        //跳跃
        isGroud = rb.IsTouchingLayers(ground);
        if (Input.GetKeyDown(KeyCode.Space) && isGroud){
            //PPS();
            //rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpTime = Time.time + 0.05f;
            //anima.SetBool("isJumping", true);
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.Space) && !isGroud  && Time.time < jumpTime){
            //PPS();
            rb.AddForce(new Vector2(0, jumpholdforce), ForceMode2D.Impulse);
        }


        
        //冲刺
        if (Input.GetKeyDown("left shift")){
            isDash = true;
            resumeTime = Time.time + dashTime;
            rb.velocity = new Vector2(moveX * dashForce, 0);
            rb.gravityScale = 0;
        }

        
        //移动
        if (!isDash){
            //PPSD();
            rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);
            rb.angularVelocity = rb.velocity.x / 0.5f * Mathf.Rad2Deg;
            anima.SetFloat("isRunning", Mathf.Abs(moveX));
        }
        if (Time.time > resumeTime){
            isDash = false;
            rb.gravityScale = 4;
        }
        if (isDash && Time.time > ghostTime){
            Instantiate(ghostObject, transform.position, Quaternion.identity);
            ghostTime = Time.time + dashTime / ghostNum;
        }

        
        //冲刺
        //
        //if (Input.GetKey("left shift") && mCollisionObjectCount > 0){
        //    moveSpeed = 7.5f;
        //    if (Time.time > ghostTime){
        //        Instantiate(gameObject, transform.position, Quaternion.identity);
        //        ghostTime = Time.time + dashTime / ghostNum;
        //    }
        //}else{
        //    moveSpeed = 3.5f;
        //}

        //if (Input.GetAxisRaw("Horizontal") != 0){
        //    direction = Input.GetAxisRaw("Horizontal");
        //}
        //if (Input.GetKeyDown("left shift")){
        //    resumeTime = Time.time + dashTime;
        //    rb.velocity = new Vector2(direction * dashForce, 0);
        //    rb.gravityScale = 0;
        //}


        //转身
        if (moveX > 0){
            //PPS();
            transform.localScale = new Vector3(1, 1, 1);
            //这里不再使用 localSacle 的原因是我在 BV1qt4y1U7aS 中得知使用角度旋转的话，自身坐标系也会跟着转。
            //transform.eulerAngles = new Vector3(0, 0, 0);
        } else{
            if (moveX < 0){
                //PPS();
                transform.localScale = new Vector3(-1, 1, 1);
                //transform.eulerAngles = new Vector3(0, 180, 0);
            } 
        } 
        
        //重力控制
        if (rb.velocity.y > 0){
            rb.gravityScale = JumpUpGraivity;//跳跃时的重力
        } else{
            rb.gravityScale = FallDownGraivity;//下落时的重力
        }
        
        //死亡回归
        if (transform.position.y < deadLiney){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (transform.position.y < deadLiney){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (transform.position.y < deadLiney){
            GetComponent<AudioSource>().enabled = false;
            Invoke("Restart", 2f);
        }

    }
    //void PPS(){
    //    playerPS.Play();
    //}
    //void PPSD(){
    //    playerPS.Pause();
    //}
}