using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public KeyCode upKey;
    public KeyCode downkey;
    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode attackKey;

    private Rigidbody2D rigidbody2D;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    #region 质量
    private float m_quality;
    public float Quality
    {
        get
        {
            return m_quality;
        }
    }
    #endregion

    #region 速度
    private float m_speed;
    public float Speed
    {
        get
        {
            return m_speed;
        }
    }
    #endregion

    #region 体积
    private float m_volume;
    public float Volume
    {
        get
        {
            return m_volume;
        }
    }
    #endregion

    // Use this for initialization
	void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
        m_quality = 5;
        m_speed = 5;
        m_volume = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(upKey))
        {
            rigidbody2D.velocity = new Vector2(0, Speed);
        }
        else if (Input.GetKey(downkey))
        {
            rigidbody2D.velocity = new Vector2(0, -Speed);
        }
        else if (Input.GetKey(leftKey))
        {
            rigidbody2D.velocity = new Vector2(-Speed, 0);
        }
        else if (Input.GetKey(rightKey))
        {
            rigidbody2D.velocity = new Vector2(Speed, 0);
        }
        else
        {
            rigidbody2D.velocity = new Vector2(0, 0);
        }

        if (Input.GetKeyDown(attackKey) && Volume >= 0.5f)
        {
            Fire();
        }

        CheckBoder();
        transform.localScale = new Vector3(Volume, Volume, Volume);
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Food")
        {
            Destroy(collider.gameObject);
            AddQuality();
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Player player = coll.gameObject.GetComponent<Player>();
            player.SetQuality((this.Quality + player.Quality) / 2);
        }
    }

    public void AddQuality(float amount = 1)
    {
        m_quality += amount;
        m_volume += amount/10.0f;
    }

    public void ReduceQuality(float amount = 1)
    {
        m_quality -= amount;
        m_volume -= amount / 10.0f;
    }

    public void SetQuality(float amount = 1)
    {
        m_quality = amount;
        m_volume = amount / 10.0f;
    }

    private void CheckBoder()
    {
        Vector3 PlayerPosition;
        if (transform.position.y > Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, Screen.height)).y)
        {
            PlayerPosition = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, 0));
            PlayerPosition.x = transform.position.x;
            PlayerPosition.z = 0;
            transform.position = PlayerPosition;
        }
        if (transform.position.y < Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, 0)).y)
        {
            PlayerPosition = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, Screen.height));
            PlayerPosition.x = transform.position.x;
            PlayerPosition.z = 0;
            transform.position = PlayerPosition;
        }
        if (transform.position.x > Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height / 2)).x)
        {
            PlayerPosition = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height / 2));
            PlayerPosition.y = transform.position.y;
            PlayerPosition.z = 0;
            transform.position = PlayerPosition;
        }
        if (transform.position.x < Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height / 2)).x)
        {
            PlayerPosition = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height / 2));
            PlayerPosition.y = transform.position.y;
            PlayerPosition.z = 0;
            transform.position = PlayerPosition;
        }
    }

    private void Fire(){
        ReduceQuality(2);
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation) as GameObject;
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);
        Destroy(bullet, 2);
    }

}
