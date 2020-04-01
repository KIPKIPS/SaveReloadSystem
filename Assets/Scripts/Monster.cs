using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {
    private Animation anim;
    public bool die;
    public int type;
    // Start is called before the first frame update
    void Start() {
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter(Collider other) {
        if (other.tag=="Bullet") {
            StartCoroutine(AnimateChange());
        }
    }
    IEnumerator AnimateChange() {
        if (die == false) {
            GameManager.instance.score += 1;
            anim.Play(name + "_die");
            die = true;
            SendMessageUpwards("DieMusicPlay");
        }
        yield return new WaitForSeconds(1f);
        GetComponent<BoxCollider>().enabled = false;
        this.gameObject.SetActive(false);
    }

    
}
