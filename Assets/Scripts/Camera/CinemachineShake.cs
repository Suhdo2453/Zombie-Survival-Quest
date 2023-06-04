using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Ultilites;
using UnityEngine;

public class CinemachineShake : Singleton<CinemachineShake>
{
    private CinemachineVirtualCamera camera;
    private CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin;
    private float shakeTimer;
    private float shakeTimeTotal;
    private float startingIntensity;

    protected override void Awake()
    {
        base.Awake();
        camera = GetComponent<CinemachineVirtualCamera>();
        cinemachineBasicMultiChannelPerlin =
            camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0)
            {
                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain =
                    Mathf.Lerp(startingIntensity, 0f, 1 - (shakeTimer / shakeTimeTotal));
            }
        }
    }

    public void ShakeCamera(float intensity, float time)
    {
        shakeTimer = time;
        shakeTimeTotal = time;
        startingIntensity = intensity;
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
    }
}