using System;
using UnityEngine;

public class MonitorStatus : MonoBehaviour
{
    public GameObject groundCheckObject;

    private void OnEnable()
    {
        GetComponentInParent<GroundCheck>()?.onEnterGround.AddListener(OnEnterGround);
        GetComponentInParent<GroundCheck>()?.onExitGround.AddListener(OnExitGround);
    }

    private void OnDisable()
    {
        GetComponentInParent<GroundCheck>()?.onEnterGround.RemoveListener(OnEnterGround);
        GetComponentInParent<GroundCheck>()?.onExitGround.RemoveListener(OnExitGround);
    }

    private void OnEnterGround(GameObject gameObject)
    {
        groundCheckObject?.SetActive(true);
    }

    private void OnExitGround(GameObject gameObject)
    {
        groundCheckObject?.SetActive(false);
    }
}
