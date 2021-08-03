using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 5;
    public Transform[] strumLines;
    Vector3 pos;
    // Update is called once per frame
    void Start(){
        pos = transform.position;

    }
    void Update()
    {
        //daNote.y = (strumLine.y - (Conductor.songPosition - daNote.strumTime) * (0.45 * FlxMath.roundDecimal(FlxG.save.data.scrollSpeed == 1 ? SONG.speed : FlxG.save.data.scrollSpeed, 2)));
        transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        if(returnStuff(0,KeyCode.D))
            Destroy(gameObject);
        if(returnStuff(1,KeyCode.F))
            Destroy(gameObject);
        if(returnStuff(2,KeyCode.J))
            Destroy(gameObject);
        if(returnStuff(3,KeyCode.K))
            Destroy(gameObject);
    }
    bool returnStuff(int thing,KeyCode key) {
    if(transform.position.x == strumLines[thing].position.x && Input.GetKeyDown(key) && (Mathf.Abs(transform.position.y - strumLines[thing].position.y) <= 2f)) {
        return true;
    }
    else
        return false;
    }
}
