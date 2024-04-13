using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System.Linq;

public class TextEffect : MonoBehaviour
{
    public enum EffectType{
        Wobble,
        Stretch, 
        Fade
    }

    public EffectType[] effects;
    TMP_Text textMesh;
    Mesh mesh;
    Vector3[] verts;
    
    private void Start() 
    {
        textMesh = GetComponent<TMP_Text>();
    }

    private void Update() 
    {
        textMesh.ForceMeshUpdate();
        mesh = textMesh.mesh;
        verts = mesh.vertices;
        Color[] colors = mesh.colors;

        for (int i = 0; i < verts.Length; i++)
        {
            Vector2 offset = Vector3.zero;

            if (effects.Contains(EffectType.Wobble)) {
                offset += Wobble(Time.time + i);    
            }

            if (effects.Contains(EffectType.Stretch)) {
                offset += Stretch(1000, i);
            }

            
            if (effects.Contains(EffectType.Fade)) {                
                colors[i].a = FluctuateFade(Time.time);                
            }
            
             
            verts[i] = verts[i] + new Vector3(offset.x, offset.y, 0);
        }        

        mesh.vertices = verts;
        mesh.colors = colors;
        textMesh.canvasRenderer.SetMesh(mesh);
    }

    private Vector2 Wobble(float time) 
    {
        return new Vector2(Mathf.Sin(time*3.3f), Mathf.Cos(time*2.5f));
    }

    int Mod(int a, int n) => (a % n + n) % n;

    private Vector2 Stretch(float length, int index) 
    {
        Vector2 offset = new Vector2(length, 0);
        offset *= (Mod(index, 4) < 2) ? -1 : 1;
        return offset;
    }

    private float FluctuateFade(float time)
    {
        return (Mathf.Sin(time) * 0.05f) + 0.1f;
    }
}
