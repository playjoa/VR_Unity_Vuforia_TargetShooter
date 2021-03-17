using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TargetDaMesa : MonoBehaviour {
    #region PUBLIC_CONSTANTS

    public const float ZeroTimeScale = 0f;

    #endregion // PUBLIC_CONSTANTS

    #region PUBLIC_MEMBER_VARIABLES

    /// <summary>
    /// Pause the TimeScale when a ImageTarget's state is changed.
    /// </summary>
    public bool pauseTimeScale = true;

    #endregion // PUBLIC_MEMBER_VARIABLES

    #region PRIVATE_MEMBER_VARIABLES

    private TrackableBehaviour mTrackableBehaviour;
    private float originalTimeScale = 1f;

    #endregion // PRIVATE_MEMBER_VARIABLES



    #region UNTIY_MONOBEHAVIOUR_METHODS

    void Start()
    {
        // Setting the timeScale has to be the first statement to be excecuted.
        // Otherwise it may be set to 0.
        originalTimeScale = Time.timeScale;


        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
           //mTrackableBehaviour.RegisterTrackableEventHandler();
        }
    }

    #endregion // UNTIY_MONOBEHAVIOUR_METHODS



    #region PUBLIC_METHODS

    /// <summary>
    /// Implementation of the ITrackableEventHandler function called when the
    /// tracking state changes.
    /// </summary>
    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            OnTrackingFound();
        }
        else
        {
            OnTrackingLost();
        }
    }

    #endregion // PUBLIC_METHODS



   


    private void OnTrackingFound()
    {
        Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);

        // Enable rendering:
        foreach (Renderer component in rendererComponents)
        {
            component.enabled = true;
        }

        if (pauseTimeScale)
        {
            // Resume Timescale
            Time.timeScale = originalTimeScale;
            //Debug.Log("TimeScale: " + Time.timeScale);
        }

        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
    }

    private void OnTrackingLost()
    {
        Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);

        // Disable rendering:
        foreach (Renderer component in rendererComponents)
        {
            component.enabled = false;
        }

        if (pauseTimeScale)
        {
            // Pause Timescale
            Time.timeScale = ZeroTimeScale;
            //Debug.Log("TimeScale: " + Time.timeScale);
        }

        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
    }
    #region Desativado
    //private TrackableBehaviour mTrackableBehaviour;
    //void Start ()
    //{
    //    mTrackableBehaviour = GetComponent<TrackableBehaviour>();
    //    if (mTrackableBehaviour)
    //    {
    //    }
    //}

    //public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    //{
    //    if (newStatus == TrackableBehaviour.Status.DETECTED ||
    //        newStatus == TrackableBehaviour.Status.TRACKED ||
    //        newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
    //    {
    //        GameObject[] latas = GameObject.FindGameObjectsWithTag("Target");
    //        foreach (GameObject lata in latas)
    //            lata.GetComponent<Rigidbody>().isKinematic = false;
    //    }
    //    else
    //    {
    //        GameObject[] latas = GameObject.FindGameObjectsWithTag("Target");
    //        foreach (GameObject lata in latas)
    //            lata.GetComponent<Rigidbody>().isKinematic = true;

    //    }
    //}
    #endregion
}
