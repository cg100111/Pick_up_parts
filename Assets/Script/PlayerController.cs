using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public UIController ui_controller;
    public GameObject robot;
    public GameObject robot_hand_sample;
    public GameObject components;

    private int height;

    private const float HEIGHT_SAMPLE = 163;
    private const float ROBOT_HEIGHT = 110;

    private string path;
    private List<List<float>> height_database;

    // Use this for initialization
    void Start () {
        Camera_position_init();
        Initialize();
        path = Application.streamingAssetsPath + "/Resources/height_database.txt";
        height_database = new List<List<float>>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
            Add_height();
        if (Input.GetKeyDown(KeyCode.D))
            Reduce_height();
	}

    public void Add_height()
    {
        height++;
        Update_height();
        Height_convert_to_robot_height();
    }

    public void Reduce_height()
    {
        height--;
        Update_height();
        Height_convert_to_robot_height();
    }

    private void Initialize()
    {
        height = (int)HEIGHT_SAMPLE;
        Height_convert_to_robot_height();
        Update_height();
    }

    private void Add_data_in_height_database()
    {
        for(int row = 0; row < height_database.Count; row++)
        {
            if (height < height_database[row][0])
            {
                height_database.Insert(row, new List<float>());
                height_database[row].Add(height);
                break;
            }
        }
    }

    private string Produce_new_content_by_database()
    {
        string new_content = "";
        foreach (List<float> section in height_database)
            new_content += section[0].ToString() + " " + section[1] + "/n";
        return new_content;
    }

    private void Transform(string[] original)
    {
        string[] remove = new string[] { " " ,"　"};
        foreach(string section in original)
        {
            height_database.Add(new List<float>());
            string[] part = section.Split(remove, System.StringSplitOptions.RemoveEmptyEntries);
            height_database[height_database.Count - 1].Add(float.Parse(part[0]));
            height_database[height_database.Count - 1].Add(float.Parse(part[1]));
        }
    }

    private float Compare_with_height_database()
    {
        foreach(List<float> section in height_database)
        {
            if (section[0].Equals(height))
                return section[1];
        }
        return -1;
    }

    private void Update_height()
    {
        ui_controller.Update_height(height.ToString());
        Update_components_height();
    }

    private void Update_components_height()
    {
        components.transform.position = new Vector3(0f, robot_hand_sample.transform.position.y, 0f);
    }

    private void Height_convert_to_robot_height()
    {
        float new_height = height / HEIGHT_SAMPLE * ROBOT_HEIGHT;
        robot.transform.localScale = new Vector3(new_height, new_height, new_height);
    }

    private void Camera_position_init()
    {
        SteamVR.instance.hmd.ResetSeatedZeroPose();
    }
}
