using UnityEngine;
using System.Collections;



public class ButtonClick : MonoBehaviour
{
    public Material material;
    public GameObject hookObject;
    void Update()
    {
       
        if (Input.GetKeyUp(KeyCode.Space)){
            print("space key was pressed");
            //GameObject instance = Instantiate(Resources.Load("model", typeof(GameObject))) as GameObject;
            ObjImporter importer = new ObjImporter();
            Mesh meshHello = importer.ImportFile("G:\\Dropbox\\Blender\\baseball.obj");
            //to get this mesh in the scene, we need an object
            GameObject myMesh = new GameObject("MyMesh");
            myMesh.transform.position = hookObject.transform.position;
            //add mesh fileter to this GameObject
            MeshFilter mf = myMesh.AddComponent<MeshFilter>();
            //set the mesh filter's mesh to our mesh
            mf.mesh = meshHello;
            //to see it, we have to add a renderer
            MeshRenderer mr = myMesh.AddComponent<MeshRenderer>();
            mr.material = material;


            //Rigidbody gameObjectsRigidBody = myMesh.AddComponent<Rigidbody>(); // Add the rigidbody.
            //gameObjectsRigidBody.mass = 5; // Set the GO's mass to 5 via the Rigidbody.

            //Collider gameObjectsCollider = myMesh.AddComponent<Collider>();
        }
    }
}
