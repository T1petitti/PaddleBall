using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject Static_ObjB;
    public GameObject Dynamic_ObjA;
    public LineRenderer line;
    int mass = 1;
    int ks = 3;
    int kd = 2;
    int lr = 4;
    private float lc;
    float r = 0.7f;
    Vector3 velocity;
    Vector3 acceleration;
    Vector3 position;
    Vector3 old_vel;
    Vector3 old_acc;
    Vector3 old_pos;
    float delta_time = 0.000011f;
    // Start is called before the first frame update
    void Start()
    {
        Dynamic_ObjA.transform.position = new Vector3(0,0,0);
        Static_ObjB.transform.position = new Vector3(0,6,0);

        velocity = new Vector3(0,0,0);
        acceleration = new Vector3(0,0,0);        
        position = Dynamic_ObjA.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        old_vel = velocity;
        old_acc = acceleration;
        old_pos = position;

        line.SetPosition(1, Static_ObjB.transform.position);
        line.SetPosition(0, Dynamic_ObjA.transform.position);

        Vector3 vector_subtraction = Dynamic_ObjA.transform.position - Static_ObjB.transform.position;
        float vector_distance = Vector3.Distance(Static_ObjB.transform.position, Dynamic_ObjA.transform.position);
        Vector3 direction = vector_subtraction/vector_distance;

        lc = vector_distance;

        Vector3 Fs = (-ks*(lc - lr))*(direction);
        Vector3 Fd = (-kd*(velocity));
        Vector3 Fg = new Vector3(0, (mass*-10), 0);
        Vector3 Fr = (-r*(velocity));

        Vector3 Force = Fs + Fd + Fg + Fr;

        acceleration = Force/mass;
        velocity = old_acc*(delta_time) + old_vel;
        position = velocity + old_pos;
        
        Dynamic_ObjA.transform.position = position;

    }
}
