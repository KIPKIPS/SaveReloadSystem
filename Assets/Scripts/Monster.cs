using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {
    private Animation anim;

    private bool die;
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
            anim.Play(name + "_die");
            die = true;
        }
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
