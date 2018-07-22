using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HandExtend : MonoBehaviour {

    private const int MAX_TIME = 10;

    private Coroutine now_coroutine;
    private Vector3 start_pos;
    private Vector3 end_pos;
    private float time;
    private float speed;
    private bool start_count = false;
    private bool is_extended = false;
    private int time_of_extend;

    // Use this for initialization
    void Start () {
        Record_beginning_value();
        Initialize_parameter();
    }
	
	// Update is called once per frame
	void Update () {
        if (start_count)
            time += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.A))
            Extend();
    }

    public void Restore()
    {
        if (now_coroutine != null)
        {
            StopCoroutine(now_coroutine);
            now_coroutine = null;
            StartCoroutine(Restore_hand());
        }
    }

    public void Record_first_pos(Vector3 pos)
    {
        start_pos = pos;
        time = 0;
        start_count = true;
    }

    public void Record_second_pos(Vector3 pos)
    {
        if (start_count)
        {
            end_pos = pos;
            start_count = false;
            Calulation_velocity(time);
        }
    }

    private void Initialize()
    {
        Initialize_parameter();
        Initialize_arm_and_hand();
    }

    //前に手を伸ばす
    private IEnumerator Extend_hand()
    {
        //手を伸ばす
        for (; time_of_extend < MAX_TIME; time_of_extend++)
        {
            Extend_way(speed);
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(0.4f);

        //手を引く
        for (;time_of_extend >= 0 ; time_of_extend--)
        {
            Restore_way(speed);
            yield return new WaitForSeconds(0.1f);
        }

        Initialize();
    }

    private IEnumerator Restore_hand()
    {
        //手を引く
        for (; time_of_extend >= 0; time_of_extend--)
        {
            Restore_way(speed);
            yield return new WaitForSeconds(0.1f);
        }
        Initialize();
    }

    protected abstract void Record_beginning_value();

    private void Initialize_parameter()
    {
        time = 0;
        speed = 0;
        time_of_extend = 0;
        is_extended = false;
    }

    protected abstract void Initialize_arm_and_hand();

    private void Calulation_velocity(float time)
    {
        speed = Vector3.Distance(start_pos, end_pos) / time;
        Debug.Log("speed : " + speed);
        Extend();
    }
    
    private void Extend()
    {
        is_extended = true;
        now_coroutine = StartCoroutine(Extend_hand());
    }

    protected abstract void Extend_way(float speed);

    protected abstract void Restore_way(float speed);

    public bool is_extend
    {
        get
        {
            return is_extended;
        }
    }
}
