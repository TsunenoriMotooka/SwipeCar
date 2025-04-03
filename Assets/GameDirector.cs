using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public CarController carController;
    public Transform car;
    public Transform flag;
    //public GameObject distance;
    public TextMeshProUGUI distance;
    
    // Start is called before the first frame update
    void Start()
    {
        //this.car = GameObject.Find("car");
        //this.flag = GameObject.Find("flag");
        //this.distance = GameObject.Find("distance");        
        this.Init();
    }

    // Update is called once per frame
    void Update()
    {
        //float length = this.flag.Transform.position.x - this.car.Transform.position.x - 1.62f;
        if (this.carController.hasSwiped && !this.carController.hasStopped) {
            float length = this.flag.position.x - this.car.position.x - 1.62f;
            string text = "距離：" + length.ToString("F2") + "m";
            //this.distance.GetComponent<TextMeshProUGUI>().text = text;                
            this.distance.text = text;
        }
        if (this.carController.hasStopped) {
            float length = this.flag.position.x - this.car.position.x - 1.62f;
            if (length <=0 && length > -2.2f) {
                this.distance.text = "ゲームクリア！！\nクリックでリトライ";
            } else {
                this.distance.text = "ゲームオーバー！\nクリックでリトライ";
            }
            if (Input.GetMouseButtonDown(0)) {
                this.Init();
            }
        }
    }

    void Init()
    {
        this.carController.Init();
        this.distance.text = "右スワイプで発進！";
    }
}
