using UnityEngine;

public class Damageable : MonoBehaviour
{


   


    public float maxHealth;
    public float currentHealth;

    public float damage;

    Camera cam;


    public LayerMask pressable;

    void Start()
    {
        currentHealth = maxHealth;

        cam = Camera.main;
    }


    void Update()
    {


        if (Input.GetMouseButton(0))
        {

            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, pressable))
            {
                if (UnitSelectionManager.Instance.unitsSelected.Count > 0)
                {
                    
                }
            }

        }


    }
}
