using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDefenseEnemy : MonoBehaviour
{
    private float health;

    private bool canBeStruck = true;

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    public void LightningStrike(float strikeNum, float strikeRadius)
    {
        canBeStruck = false;

        Collider[] colliders = Physics.OverlapSphere(transform.position, strikeRadius);
        foreach (Collider hit in colliders)
        {
            BaseDefenseEnemy enemy = hit.GetComponent<BaseDefenseEnemy>();

            if (enemy != null && enemy.CanBeStruckByLightning())
            {
                DrawLine(transform.position, enemy.transform.position, Color.yellow, 0.2f, strikeNum * 0.2f);
                enemy.TakeDamage(strikeNum);

                if(strikeNum > 1f)
                {
                    enemy.LightningStrike(strikeNum - 1f, strikeRadius);
                }

                break;
            }
        }
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

    public bool CanBeStruckByLightning()
    {
        return canBeStruck;
    }
}
