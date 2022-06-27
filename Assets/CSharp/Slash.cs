using UnityEngine;
// using Photon.Pun;

public class Slash : MonoBehaviour
{
    [SerializeField] private float attackDamage;

    public void EndAttack()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("We have Hitted the Enemy!");
            
            other.gameObject.GetComponent<Enemy>().TakenDamage(attackDamage);
            
            #region 击退效果 反方向移动，从角色中心点「当前位置」向敌人位置方向「目标点」移动
            Vector2 difference = other.transform.position - transform.position;
            other.transform.position = new Vector2(other.transform.position.x + difference.x / 2,
                                                   other.transform.position.y + difference.y / 2);
            #endregion
        }
    }
}
