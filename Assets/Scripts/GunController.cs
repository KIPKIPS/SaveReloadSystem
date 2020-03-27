using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {
    //竖直
    private float maxXRotationt = 80;
    private float minXRotationt = 0;
    //水平
    private float maxYRotationt = 120;
    private float minYRotationt = 0;

    //射击间隔
    private float shootTime = 1;
    private float timer = 0;//计时器
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        timer += Time.deltaTime;
        if (timer>=shootTime) {
            //TODO:可以射击

        }
        //xy位置与屏幕宽高的百分比
        float xPos = Input.mousePosition.x/Screen.width;
        float yPos= Input.mousePosition.y / Screen.height;
        float xAngle = -Mathf.Clamp(yPos * maxXRotationt, minXRotationt, maxXRotationt)+20;//竖直方向的旋转角
        float yAngle = Mathf.Clamp(xPos * maxYRotationt, minYRotationt, maxYRotationt)-60;//水平方向的旋转角

        //实现旋转
        transform.eulerAngles=new Vector3(xAngle,yAngle,0);

    }
}
