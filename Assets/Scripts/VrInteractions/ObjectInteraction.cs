using UnityEngine;

// This script is a simple example of how an interactive item can
// be used to change things on gameobjects by handling events.
[RequireComponent(typeof(VRInteractiveItem))]
public class ObjectInteraction : MonoBehaviour {

    public float scaleXYZ = 1.0f;


    [SerializeField]
    private Material m_NormalMaterial;
    [SerializeField]
    private Material m_OverMaterial;
    [SerializeField]
    private GameObject m_Hook;
    [SerializeField]
    private GameObject m_loadedObject;


    private VRInteractiveItem m_InteractiveItem;
    private Renderer m_Renderer;

    private bool canLoad = true;


    private void Awake() {
        m_InteractiveItem = gameObject.GetComponent<VRInteractiveItem>();
        m_Renderer = gameObject.GetComponent<Renderer>();
        m_Renderer.material = m_NormalMaterial;
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
    }


    //Handle the Out event
    private void HandleOut() {
        Debug.Log("Show out state");
        m_Renderer.material = m_NormalMaterial;
    }


    //Handle the Click event
    private void HandleClick() {
        Debug.Log("Show click state");

        if (canLoad) {
            GameObject childObject = Instantiate(m_loadedObject) as GameObject;
            childObject.transform.position = m_Hook.transform.position;
            childObject.transform.localScale = new Vector3(scaleXYZ, scaleXYZ, scaleXYZ);
            canLoad = false;
        }

    }


    
    private void HandleSpacePress() {
        Debug.Log("Space pressed");
        if (canLoad) {
            GameObject childObject = Instantiate(m_loadedObject) as GameObject;
            childObject.transform.position = m_Hook.transform.position;
            childObject.transform.localScale = new Vector3(scaleXYZ, scaleXYZ, scaleXYZ);
            canLoad = false;
        }
    }

    //Handle the DoubleClick event
    private void HandleDoubleClick() {
        Debug.Log("Show double click");
    }
}
