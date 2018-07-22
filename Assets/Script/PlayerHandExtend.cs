using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandExtend : HandExtend {

    public GameObject arm;
    public GameObject hand;

    private Quaternion original_rotation;
    private Vector3 arm_org_pos;
    private Vector3 arm_org_scale;
    private Vector3 hand_org_pos;

    protected override void Record_beginning_value()
    {
        arm_org_pos = arm.transform.localPosition;
        arm_org_scale = arm.transform.localScale;
        hand_org_pos = hand.transform.localPosition;
    }

    protected override void Initialize_arm_and_hand()
    {
        arm.transform.localPosition = arm_org_pos;
        arm.transform.localScale = arm_org_scale;
        hand.transform.localPosition = hand_org_pos;
    }

    protected override void Extend_way(float speed)
    {
        Debug.Log(arm.transform.localScale);
        original_rotation = arm.transform.parent.transform.rotation;
        Set_target_rotation_to_0();
        arm.transform.localScale += Vector3.right / 10f * speed;
        Reset_arm_local_position();
        Reset_hand_position();
        Restore_original_rotation(original_rotation);
    }

    protected override void Restore_way(float speed)
    {
        original_rotation = arm.transform.parent.transform.rotation;
        Set_target_rotation_to_0();
        arm.transform.localScale -= Vector3.right / 10f * speed;
        Reset_arm_local_position();
        Reset_hand_position();
        Restore_original_rotation(original_rotation);
    }

    private void Set_target_rotation_to_0()
    {
        arm.transform.parent.transform.rotation = Quaternion.identity;
    }

    private void Reset_arm_local_position()
    {
        Vector3 arm_length = new Vector3(arm.GetComponent<Renderer>().bounds.size.x, 0f, 0f);
        arm.transform.localPosition = arm_org_pos - arm_length / 2;
    }

    private void Reset_hand_position()
    {
        float arm_length = arm.GetComponent<Renderer>().bounds.size.x;
        float hand_length = hand.GetComponent<Renderer>().bounds.size.x;
        float arm_pos = arm.transform.localPosition.x;
        hand.transform.localPosition = new Vector3(arm_pos - arm_length / 2 - hand_length / 2, hand_org_pos.y, hand_org_pos.z);
    }

    private void Restore_original_rotation(Quaternion original_rotation)
    {
        arm.transform.parent.transform.rotation = original_rotation;
    }
}
