using UnityEngine;
using UnityEngine.UI;

// This script is a simple example of how an interactive item can
// be used to change things on gameobjects by handling events.
[RequireComponent(typeof(VRInteractiveItem))]
public class ColourChangeOver : MonoBehaviour {
    [SerializeField]
    private Material m_NormalMaterial;
    [SerializeField]
    private Material m_OverMaterial;
    [SerializeField]
    private Image disableReticle;


    private VRInteractiveItem m_InteractiveItem;
    private Renderer m_Renderer;


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
    }


    private void OnDisable() {
        m_InteractiveItem.OnOver -= HandleOver;
        m_InteractiveItem.OnOut -= HandleOut;
        m_InteractiveItem.OnClick -= HandleClick;
        m_InteractiveItem.OnDoubleClick -= HandleDoubleClick;
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
    }


    //Handle the Click event
    private void HandleClick() {
        Debug.Log("Show click state");
    }


    //Handle the DoubleClick event
    private void HandleDoubleClick() {
        Debug.Log("Show double click");
    }
}
