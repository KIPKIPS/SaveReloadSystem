using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {
    private Vector3 firePos;
    private Vector3 tailPos;
    private Vector3 fireDir;//开火方向
    //竖直
    private float maxXRotationt = 80;
    private float minXRotationt = 0;
    //水平
    private float maxYRotationt = 120;
    private float minYRotationt = 0;

    //射击间隔
    private float shootTime = 0.2f;
    private float timer = 0;//计时器

    private GameObject bullet;

    private Animation anim;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start() {
        bullet = Resources.Load<GameObject>("Bullet");
        anim = GetComponent<Animation>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        if (GameManager.instance.canShoot) {
            firePos = GameObject.Find("FirePos").transform.position;
            tailPos = GameObject.Find("TailPos").transform.position;
            //xy位置与屏幕宽高的百分比
            float xPos = Input.mousePosition.x / Screen.width;
            float yPos = Input.mousePosition.y / Screen.height;
            float xAngle = -Mathf.Clamp(yPos * maxXRotationt, minXRotationt, maxXRotationt) + 20;//竖直方向的旋转角
            float yAngle = Mathf.Clamp(xPos * maxYRotationt, minYRotationt, maxYRotationt) - 60;//水平方向的旋转角
            //实现旋转
            transform.eulerAngles = new Vector3(xAngle, yAngle, 0);
        }
        timer += Time.deltaTime;
        if (timer>=shootTime) {
            //TODO:可以射击
            if (Input.GetMouseButtonDown(0)&&GameManager.instance.canShoot) {
                GameObject go = Instantiate(bullet, firePos, Quaternion.identity);
                fireDir = firePos - tailPos;
                //Debug.DrawLine(tailPos,firePos,Color.blue,5);
                go.GetComponent<Rigidbody>().AddForce(fireDir.normalized*5000);
                timer = 0;
                anim.Play("Grip|Fire");
                audioSource.Play();
            }
        }
        

    }
}
