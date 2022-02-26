using UnityEngine;

public class CheeseMode : MonoBehaviour
{
    bool cheeseModeActive = false;

    [SerializeField]
    Material cheeseMaterial;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1) && !cheeseModeActive) {
            MeshRenderer[] meshRenderers = GameObject.FindObjectsOfType<MeshRenderer>();

            foreach (MeshRenderer meshRenderer in meshRenderers)
            {
                if (meshRenderer.gameObject.transform.root.name.Contains("Player")) { continue; }

                var mats = new Material[meshRenderer.materials.Length];

                for (var j = 0; j < meshRenderer.materials.Length; j++)
                {
                    mats[j] = cheeseMaterial;
                }

                meshRenderer.materials = mats;
            }
            cheeseModeActive = true;
        }
    }
}
