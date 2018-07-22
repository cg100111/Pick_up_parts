using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhiteboardController : MonoBehaviour {

    public GameObject description;
    public GameObject target;
    public Text timer;
    public Text number_of_completed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Change_to_explain_game()
    {
        target.SetActive(false);
        description.SetActive(true);
        description.GetComponent<Text>().text = "一分間で手を伸ばすによって、周りから材料を赤い場所に集めてください。\n\n手を伸ばす方法：まずはひじを曲げて、そして伸ばす。\n\n物を掴みたい時はコントローラーの後ろにあるボタンを押してください。\n一人称の時、赤い場所に立たなければ物を掴まない。";
    }

    public void Change_to_explain_adjustment()
    {
        target.SetActive(false);
        description.SetActive(true);
        description.GetComponent<Text>().text = "";
    }

    public void Change_to_target()
    {
        target.SetActive(true);
        description.SetActive(false);
    }

    public void Change_to_display_result(string count)
    {
        target.SetActive(false);
        description.SetActive(true);
        description.GetComponent<Text>().text = "おめでとうございます。"+count+"個を完成しました。";
    }

    public void Update_time(string time)
    {
        timer.text = "残る時間 : " + time;
    }

    public void Update_number_of_completed(string number)
    {
        number_of_completed.text = "完成の数 : " + number;
    }
}
