using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destroy : MonoBehaviour
{

    public Text text;
    public GameObject player;
    public GameObject platformPrefab;
    public GameObject springPrefab;
    public GameObject myPlat;

    private int distance = 9;
    private bool createNewObject = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Object[] allObjects = GameObject.FindObjectsOfType(typeof(MonoBehaviour)); //returns Object[]
        if(allObjects.Length <= 6)
        {
            createNewObject = true;
        } else {
            createNewObject = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name.StartsWith("Platform"))
        {
            if (Random.Range(1, 7) == 1)
            {
                Destroy(collision.gameObject);
                if(createNewObject == true){
                Instantiate(springPrefab, new Vector2(Random.Range(-4.5f, 4.5f), player.transform.position.y + (distance + Random.Range(0.2f, 1.0f))), Quaternion.identity);}
            } else
            {   
                if(createNewObject == true){
                collision.gameObject.transform.position = new Vector2(Random.Range(-4.5f, 4.5f), player.transform.position.y + (distance + Random.Range(0.2f, 1.0f)));}
            }
        } else if(collision.gameObject.name.StartsWith("Bounce")) {
            if (Random.Range(1, 7) == 1)
            {
                if(createNewObject == true){
                collision.gameObject.transform.position = new Vector2(Random.Range(-4.5f, 4.5f), player.transform.position.y + (distance + Random.Range(0.2f, 1.0f)));}
            }
            else
            {
                
                Destroy(collision.gameObject);
                if(createNewObject == true){
                Instantiate(platformPrefab, new Vector2(Random.Range(-4.5f, 4.5f), player.transform.position.y + (distance + Random.Range(0.2f, 1.0f))), Quaternion.identity);}
            }
        }
    }
}
