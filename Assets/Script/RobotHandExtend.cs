using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotHandExtend : HandExtend {

    private Vector3 hand_org_pos;

    protected override void Record_beginning_value()
    {
        hand_org_pos = this.transform.localPosition;
    }

    protected override void Initialize_arm_and_hand()
    {
        this.transform.localPosition = hand_org_pos;
    }

    protected override void Extend_way(float speed)
    {
        this.transform.localPosition -= Vector3.right / 2000f * speed;
    }

    protected override void Restore_way(float speed)
    {
        this.transform.localPosition += Vector3.right / 2000f * speed;
    }
}
