﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_SoundComponent : MonoBehaviour
{
    private bool m_bPlayOnStart = false;

    [SerializeField]
    private float m_fSoundRadius;

    [SerializeField]
    private LayerMask m_GuardAlertMask;

    [SerializeField]
    [FMODUnity.EventRef]
    private string m_sSoundToPlay;

    // Use this for initialization
    private void Start()
    {
        CS_SoundManager.PlaySoundOnObjectWER(transform, m_sSoundToPlay);
        Collider[] cTargetsInViewRadius = Physics.OverlapSphere(transform.position, m_fSoundRadius, m_GuardAlertMask);

        foreach (Collider cCurrentTarget in cTargetsInViewRadius)
        {
            CS_GuardHearing cGuardRef = cCurrentTarget.GetComponent<CS_GuardHearing>();
            if (cGuardRef != null)
            {
                cGuardRef.AlertHearSound(transform);
            }
        }
        Destroy(gameObject, 20f);
    }

    // Update is called once per frame
    private void Update()
    {
    }
}