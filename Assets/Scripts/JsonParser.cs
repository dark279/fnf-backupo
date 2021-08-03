using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class JsonParser : MonoBehaviour
{
    public string path;
    string jsonFile;
    public Transform[] strumLines;
    public GameObject leftNote,rightNote,upNote,downNote;
    GameObject[] leftNotes,rightNotes,upNotes,downNotes;
    void Start()
    {
        string pathAdded = Application.streamingAssetsPath + path;
        jsonFile = File.ReadAllText(pathAdded);
        NoteList list = JsonUtility.FromJson<NoteList>(jsonFile);
        foreach(Note note in list.notes) {
            list.offset = list.speed;
            note.offset = list.offset + note.y * list.offset * 2;
            note.y = note.offset;
            switch(note.type) {
                case "left":
                    GameObject daNote = Instantiate(leftNote, new Vector3(strumLines[0].position.x,note.y,5),Quaternion.identity);
                    daNote.transform.rotation = leftNote.transform.rotation;
                    daNote.GetComponent<Arrow>().speed = list.speed * 10;
                    break;
                case "right":
                    GameObject daNote2 = Instantiate(rightNote, new Vector3(strumLines[3].position.x,note.y,5),Quaternion.identity);
                    daNote2.transform.rotation = rightNote.transform.rotation;
                    daNote2.GetComponent<Arrow>().speed = list.speed * 10;
                    break;
                case "down":
                    GameObject daNote3 = Instantiate(downNote, new Vector3(strumLines[1].position.x,note.y,5),Quaternion.identity);
                    daNote3.transform.rotation = downNote.transform.rotation;
                    daNote3.GetComponent<Arrow>().speed = list.speed * 10;
                    break;
                case "up":
                    GameObject daNote4 = Instantiate(upNote, new Vector3(strumLines[2].position.x,note.y,5),Quaternion.identity);
                    daNote4.transform.rotation = upNote.transform.rotation;
                    daNote4.GetComponent<Arrow>().speed = list.speed * 10;
                    break;
            }
        }
    }
}
[System.Serializable]
public class Note{
    public float offset;
    public float y;
    public string type;
}
[System.Serializable]
public class NoteList{
    public List<Note> notes;
    public float speed;
    public float offset;
}