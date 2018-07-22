using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ControllerGrabObject : MonoBehaviour {

    public HandController hand_controller;

    private GameObject collidingObject;
    private GameObject objectInHand;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void Grab_the_object()
    {
        if (collidingObject)
            GrabObject();
    }

    public void Release_the_object(Vector3 velocity, Vector3 angularVelocity)
    {
        if (objectInHand)
            ReleaseObject(velocity, angularVelocity);
    }

    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
        if (other.tag == "gear" || other.tag == "wood" || other.tag == "screw" || other.tag == "iron" || other.tag == "glass" || other.tag == "oil")
            hand_controller.Vibrate();
    }

    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }

    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
            return;
        collidingObject = null;
    }

    private void GrabObject()
    {
        objectInHand = collidingObject;
        collidingObject = null;

        var joint = addFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
    }

    private FixedJoint addFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    private void ReleaseObject(Vector3 velocity, Vector3 angularVelocity)
    {
        if (GetComponent<FixedJoint>())
        {
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());

            //objectInHand.GetComponent<Rigidbody>().velocity = velocity;
            //objectInHand.GetComponent<Rigidbody>().angularVelocity = angularVelocity;
            objectInHand.GetComponent<Rigidbody>().useGravity = true;
        }
        objectInHand = null;
    }

    private void SetCollidingObject(Collider col)
    {
        if (collidingObject || !col.GetComponent<Rigidbody>())
            return;
        collidingObject = col.gameObject;
    }
}
