using UnityEngine;
using UnityEngine.UI;
// This script is a simple example of how an interactive item can
// be used to change things on gameobjects by handling events.
[RequireComponent(typeof(VRInteractiveItem))]
[RequireComponent(typeof(Rigidbody))]
public class GrabInteraction : MonoBehaviour {

    public float scaleXYZ = 1.0f;


    [SerializeField]
    private Material m_NormalMaterial;
    [SerializeField]
    private Material m_OverMaterial;


    private GameObject m_Hook;
    private Image disableReticle;


    private Rigidbody rigBody;
    private VRInteractiveItem m_InteractiveItem;
    private Renderer m_Renderer;
    
    private bool canGrab = true;


    private void Awake() {
        m_InteractiveItem = gameObject.GetComponent<VRInteractiveItem>();
        m_Renderer = gameObject.GetComponent<Renderer>();
        m_Renderer.material = m_NormalMaterial;
        m_Hook = GameObject.Find("TestCameraRay/hook");
        GameObject reticle = GameObject.Find("TestCameraRay/VRUI/Reticle");
        disableReticle = reticle.GetComponent(typeof(Image)) as Image;
        rigBody = GetComponent<Rigidbody>();
    }



    private void OnEnable() {
        m_InteractiveItem.OnOver += HandleOver;
        m_InteractiveItem.OnOut += HandleOut;
        m_InteractiveItem.OnClick += HandleClick;
        m_InteractiveItem.OnDoubleClick += HandleDoubleClick;
        m_InteractiveItem.OnSpacePress += HandleSpacePress;
    }


    private void OnDisable() {
        m_InteractiveItem.OnOver -= HandleOver;
        m_InteractiveItem.OnOut -= HandleOut;
        m_InteractiveItem.OnClick -= HandleClick;
        m_InteractiveItem.OnDoubleClick -= HandleDoubleClick;
        m_InteractiveItem.OnSpacePress -= HandleSpacePress;
    }


    //Handle the Over event
    private void HandleOver() {
        Debug.Log("Show over state");
        m_Renderer.material = m_OverMaterial;
        disableReticle.enabled = false;
    }


    //Handle the Out event
    private void HandleOut() {
        Debug.Log("Show out state");
        m_Renderer.material = m_NormalMaterial;
        disableReticle.enabled = true;
        rigBody.useGravity = true;
        canGrab = true;
        gameObject.transform.parent = null;
    }


    //Handle the Click event
    private void HandleClick() {
        Debug.Log("Show click state");
    }



    private void HandleSpacePress() {
        Debug.Log("Space pressed");
        if (canGrab) {
            gameObject.transform.parent = m_Hook.transform;
            rigBody.useGravity = false;
            canGrab = false;
        }else {
            gameObject.transform.parent = null;
            rigBody.useGravity = true;
            canGrab = true;
        }
        
    }

    //Handle the DoubleClick event
    private void HandleDoubleClick() {
        Debug.Log("Show double click");
    }
}
