using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class HandController : MonoBehaviour {

    public RobotHandExtend hand_extend;
    public ControllerGrabObject grab_hand;

    private SteamVR_TrackedObject trackedObj;

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (controller.GetHairTriggerUp())
            grab_hand.Release_the_object(controller.velocity, controller.angularVelocity);
        if (controller.GetHairTriggerDown())
        {
            grab_hand.Grab_the_object();
            if (hand_extend.is_extend)
                hand_extend.Restore();
        }
	}

    public void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "body")
        {
            hand_extend.Record_first_pos(this.transform.position);
        }
        else if (col.gameObject.tag == "wall")
        {
            hand_extend.Record_second_pos(this.transform.position);
        }
    }

    public void Vibrate()
    {
        controller.TriggerHapticPulse(3000);
    }

    private SteamVR_Controller.Device controller
    {
        get
        {
            return SteamVR_Controller.Input((int)trackedObj.index);
        }
    }
}
