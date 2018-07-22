using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadFile : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private string[] Readfile(string path)
    {
        return File.ReadAllText(path).Split(new string[] { "/r/n", "/r", "/n" }, System.StringSplitOptions.RemoveEmptyEntries);
    }

    private void Write_file(string path, string content)
    {
        File.WriteAllText(path, content);
    }
}
