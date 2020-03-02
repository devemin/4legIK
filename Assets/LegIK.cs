using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegIK : MonoBehaviour
{
    public Transform p1, p2, p3, p4;
    public Transform Tp;

    float l1len, l2len, l3len;

    // Start is called before the first frame update
    void Start()
    {
        l1len = Vector3.Distance(p1.position, p2.position);
        l2len = Vector3.Distance(p2.position, p3.position);
        l3len = Vector3.Distance(p3.position, p4.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {




        //①まずｚ軸方向へ見たp1-p2-Tp三角形の角度を求める

        Debug.Log("l1len distance: " + l1len.ToString());

        float p1toTpxAxis = Vector3.Distance(p1.position, new Vector3(Tp.position.x, Tp.position.y, p1.position.z));
        Debug.Log("p1toTpxAxis distance: " + p1toTpxAxis.ToString());

        float p2toTpxAxis = Mathf.Sqrt(Mathf.Pow(p1toTpxAxis, 2.0f) - Mathf.Pow(l1len, 2.0f));
        Debug.Log("p2toTpxAxis distance: " + p2toTpxAxis.ToString());

        float cosp1tri = (Mathf.Pow(l1len, 2.0f) + Mathf.Pow(p1toTpxAxis, 2.0f) - Mathf.Pow(p2toTpxAxis, 2.0f)) / (2.0f * l1len * p1toTpxAxis);
        float p1triangle = Mathf.Acos(cosp1tri) * 180.0f / Mathf.PI;
        Debug.Log("p1 angle: " + p1triangle.ToString());

        //次に　②p1-Tpベクトルをその角度だけ回転したベクトルを求める
        //http://www.geisya.or.jp/~mwm48961/kou2/linear_image3.html
        float p1toTpx = Tp.position.x - p1.position.x;
        float p1toTpy = Tp.position.y - p1.position.y;
        float rotx = p1toTpx * Mathf.Cos(p1triangle / 180.0f * Mathf.PI) - p1toTpy * Mathf.Sin(p1triangle / 180.0f * Mathf.PI);
        float roty = p1toTpx * Mathf.Sin(p1triangle / 180.0f * Mathf.PI) + p1toTpy * Mathf.Cos(p1triangle / 180.0f * Mathf.PI);

        Debug.Log("(p1toTpx, p1toTpy) = (" + p1toTpx.ToString() + ", " + p1toTpy.ToString() + ")");
        Debug.Log("(rotx, roty) = (" + rotx.ToString() + ", " + roty.ToString() + ")");

        //③　②とX軸のなす角度を求める
        //https://study-line.com/sankakuhi-nasukaku/
        float p1angle = Mathf.Atan2(roty, rotx) * 180.0f / Mathf.PI;
        Debug.Log("p1angle: " + p1angle.ToString());

        p1.localEulerAngles = new Vector3(0, 0, p1angle);


        //④2軸目、3軸目を求める
        //p2の3D座標を求める
        float p2x = l1len;
        float p2y = 0f;
        float rotp2x = p2x * Mathf.Cos(p1angle / 180.0f * Mathf.PI) - p2y * Mathf.Sin(p1angle / 180.0f * Mathf.PI) + 4f;
        float rotp2y = p2x * Mathf.Sin(p1angle / 180.0f * Mathf.PI) + p2y * Mathf.Cos(p1angle / 180.0f * Mathf.PI) + 1f;
        float rotp2z = 0f + 4f;

        Debug.Log("p2: (" + p2.position.x.ToString() + ", " + p2.position.y.ToString() + ", " + p2.position.z.ToString() + ", " + ")");
        Debug.Log("rotp2: (" + rotp2x.ToString() + ", " + rotp2y.ToString() + ", " + rotp2z.ToString() + ", " + ")");


        float p2toTp3D = Vector3.Distance(new Vector3(rotp2x, rotp2y, rotp2z), Tp.position);
        Debug.Log("p2toTp3D distance: " + p2toTp3D.ToString());

        
        float cosp2tri = (Mathf.Pow(l2len, 2.0f) + Mathf.Pow(p2toTp3D, 2.0f) - Mathf.Pow(l3len, 2.0f)) / (2.0f * l2len * p2toTp3D);
        float p2angle = Mathf.Acos(cosp2tri) * 180.0f / Mathf.PI;
        Debug.Log("p2 angle: " + p2angle.ToString());

        float cosp3tri = (Mathf.Pow(l2len, 2.0f) + Mathf.Pow(l3len, 2.0f) - Mathf.Pow(p2toTp3D, 2.0f)) / (2.0f * l2len * l3len);
        float p3angle = Mathf.Acos(cosp3tri) * 180.0f / Mathf.PI;
        Debug.Log("p3 angle: " + p3angle.ToString());



        //p2toTpとY軸のなす角度を求める
        float p2rot = (Mathf.Pow(p2toTpxAxis, 2.0f) + Mathf.Pow(p2toTp3D, 2.0f) - Mathf.Pow((Tp.position.z - p1.position.z), 2.0f)) / (2.0f * p2toTpxAxis * p2toTp3D);
        float p2rottriangle = Mathf.Acos(p2rot) * 180.0f / Mathf.PI;
        Debug.Log("p2rottriangle: " + p2rottriangle.ToString());

        float p2sang = 0.0f;
        if (Tp.position.z >= p1.position.z)
        {
            p2sang  = - p2angle - p2rottriangle;
        }
        else
        {
            p2sang = -p2angle + p2rottriangle;
        }

        p2.localEulerAngles = new Vector3(p2sang, 0, 0);
        p3.localEulerAngles = new Vector3(180-p3angle, 0, 0);

    }
}
