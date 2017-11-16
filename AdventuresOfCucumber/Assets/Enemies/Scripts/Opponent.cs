using UnityEngine;

public class Opponent : MonoBehaviour {

    public int moveSpeed = 3;
    public float directoinTime = 2.0f;
    private float time;
    public bool position = true;
    public float bulletTime = 2.0f;
    private float bulletLife;
    public float bulletSpeed = 10;

    public GameObject enemy;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    // Use this for initialization
    void Start () {
        bulletLife = bulletTime;
        time = directoinTime;
    }
	
	// Update is called once per frame
	void Update () {
        if (position)
        {
            time -= Time.deltaTime;
            GetComponent<Transform>().Translate(new Vector3(-1 * moveSpeed, 0, 0) * Time.deltaTime);
            if (time < 0)
            {
                position = false;
                time = directoinTime;
            }
        }
        else
        {
            time -= Time.deltaTime;
            GetComponent<Transform>().Translate(new Vector3(moveSpeed, 0, 0) * Time.deltaTime);
            if (time < 0)
            {
                position = true;
                time = directoinTime;
            }
        }
        bulletLife -= Time.deltaTime;
        if (bulletLife < 0)
        {
            int directionFire;
            if (position)
                directionFire = -1;
            else
                directionFire = 1;
            GameObject bullet = CreateBullet();
            GameObject.Find("SoundInfo").GetComponent<SoundInfo>().enemyShot.Play();
            Destroy(bullet, 4.0f);
            bullet.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(bulletSpeed * directionFire, 0, 0));
            bulletLife = bulletTime;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Slice")
        {
            Destroy(enemy);
            GameObject.Find("LevelInfo").GetComponent<LevelInfo>().numberOfEnemies--;
        }

    }

    GameObject CreateBullet()
    {
        int directionFire;
        if (position)
            directionFire = -1;
        else
            directionFire = 1;
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position + new Vector3(4 * directionFire, 0, 0),
            bulletSpawn.rotation);


        return bullet;
    }

}
