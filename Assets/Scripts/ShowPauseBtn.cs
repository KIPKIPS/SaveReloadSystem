using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPauseBtn : MonoBehaviour {
    public GameObject pauseBtn;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    public void ShowBtn() {
        pauseBtn.SetActive(true);
        Time.timeScale = 1;
    }

    public void Pause() {
        Time.timeScale = 0;
    }
}
