using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instance : MonoBehaviour
{
    public GameObject Prefab;
    private int Previous_nbprefab = 0;
    private Vector3Int Previous_InitilaPosition=new Vector3Int(0,0,0);
    private int Previous_Radius = 0;
    
    private Object [] Listesphere=new Object[10];
    [SerializeField] private int Nbprefab=10;
    [SerializeField] private Vector3Int PositionInit;
    [SerializeField] private int Radius=1;
    // Start is called before the first frame update
    void Start()
    {
        Previous_Radius = Radius;
        Previous_nbprefab = Nbprefab;
        Previous_InitilaPosition = PositionInit;
        for (int i = 0; i < Nbprefab; i++)
        {
            
            Listesphere[i]=Instantiate(Prefab, new Vector3(PositionInit.x+Radius*Mathf.Cos(Mathf.PI*2*i/Nbprefab), 
                PositionInit.y+Radius*Mathf.Sin(Mathf.PI*2*i/Nbprefab), 
                PositionInit.z), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((Previous_nbprefab != Nbprefab)||(Previous_InitilaPosition!=PositionInit)||(Radius!=Previous_Radius))
        {
            for (int i = 0; i < Previous_nbprefab; i++)
            {
                Destroy(Listesphere[i]);
            }

            Listesphere = new Object [Nbprefab];
            for (int i = 0; i < Nbprefab; i++)
            {
            
                Listesphere[i]=Instantiate(Prefab, new Vector3(PositionInit.x+Radius*Mathf.Cos(Mathf.PI*2*i/Nbprefab), 
                    PositionInit.y+Radius*Mathf.Sin(Mathf.PI*2*i/Nbprefab), 
                    PositionInit.z), Quaternion.identity);
            }
            
        }

        Previous_nbprefab = Nbprefab;
        Previous_Radius = Radius;
        Previous_InitilaPosition = PositionInit;

    }
}
