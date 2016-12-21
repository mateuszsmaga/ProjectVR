using UnityEngine;
using System.Collections;

public class NightMaker : MonoBehaviour {

    [SerializeField]
    private Material dayMaterial;
    [SerializeField]
    private Material nightMaterial;
    [SerializeField]
    private GameObject headLamp;

    VRCameraFade fade;
    bool dayTimeBool;

	// Use this for initialization
	void Start () {
        dayTimeBool = false;
        fade = gameObject.GetComponent(typeof(VRCameraFade)) as VRCameraFade;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp(KeyCode.Z)) {
            if (dayTimeBool) {
                dayTime();
                dayTimeBool = false;
            }
            else {
                nightTime();
                dayTimeBool = true;
            }
            
        }

    }

    void dayTime() {
        GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("lamp");
        fade.FadeIn(false);
        foreach (GameObject go in gameObjectArray) {
            go.GetComponent<Renderer>().material = dayMaterial;
            go.transform.FindChild("Point light").gameObject.SetActive(true);
        }
        headLamp.SetActive(false);
        fade.FadeOut(false);
    }

    void nightTime() {
        GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("lamp");
        fade.FadeIn(false);
        foreach (GameObject go in gameObjectArray) {
            go.GetComponent<Renderer>().material = nightMaterial;
            go.transform.FindChild("Point light").gameObject.SetActive(false);
        }
        headLamp.SetActive(true);
        fade.FadeOut(false);
    }

}
