using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Player player;
    public float offset;
    public float smoothing;
    private Vector3 playerPosition;
    
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;
    // Update is called once per frame


    void Awake(){
        player = FindObjectOfType<Player>();
    }
    void FixedUpdate()
    {

        if (player == null)
            player = FindObjectOfType<Player>();

        if (player.transform.position.x <= minX && player.transform.position.y <= minY){
            playerPosition = new Vector3(minX, minY, -10f);
        }else if(player.transform.position.x >= maxX && player.transform.position.y >= maxY){
            playerPosition = new Vector3(maxX, maxY, -10f);
        }else if(player.transform.position.x <= minX && player.transform.position.y >= maxY){
            playerPosition = new Vector3(minX, maxY, -10f);
        }else if(player.transform.position.x >= maxX && player.transform.position.y <= minY){
            playerPosition = new Vector3(maxX, minY, -10f);
        }else if (player.transform.position.x <= minX){
            playerPosition = new Vector3(minX, player.transform.position.y, -10f);
        }else if (player.transform.position.x >= maxX){
            playerPosition = new Vector3(maxX, player.transform.position.y, -10f);
        }else if (player.transform.position.y <= minY){
            playerPosition = new Vector3(player.transform.position.x, minY, -10f);
        }else if (player.transform.position.y >= maxY){
            playerPosition = new Vector3(player.transform.position.x, maxY, -10f);
        }else{
            playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, -10f);
        }

        transform.position = Vector3.Lerp(transform.position, playerPosition, smoothing * Time.deltaTime);

    }
}
