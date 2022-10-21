using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDefenseEnemy : MonoBehaviour
{
    [SerializeField] private float health;
    private bool canBeStruckByLightning = true;

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    public void LightningStrike()
    {
        canBeStruckByLightning = false;
        StartCoroutine(LightningStrikeTimer());
    }

    public bool CheckifCanBeStruck()
    {
        return canBeStruckByLightning;
    }

    private IEnumerator LightningStrikeTimer()
    {
        yield return new WaitForSeconds(1f);
        canBeStruckByLightning = true;
    }


    void DrawLine(Vector3 start, Vector3 end, Color color, float duration, float lineWidth)
    {
        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.startColor = color;
        lr.endColor = color;
        lr.startWidth = lineWidth;
        lr.endWidth = lineWidth;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        GameObject.Destroy(myLine, duration);
    }
}
