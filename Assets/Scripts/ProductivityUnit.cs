using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityUnit : Unit 
{

    private ResourcePile m_CurrentPile = null;
    public float ProductivityMultiplier = 2;

    protected override void BuildingInRange()
    {
         if (m_CurrentPile == null)
        {
            ResourcePile pile = m_Target as ResourcePile;

            if (pile != null)
            {
                m_CurrentPile = pile;
                m_CurrentPile.ProductionSpeed *=  ProductivityMultiplier;
            }
        }
    }

    public override void GoTo(Building target)
    {
        ResetProductivity(); // call your new method
        base.GoTo(target); // run method from base class
    }


    public override void GoTo(Vector3 position)
    {
        ResetProductivity();
        base.GoTo(position);
    }

    void ResetProductivity()
    {
        if (m_CurrentPile != null)
        {
            m_CurrentPile.ProductionSpeed /= ProductivityMultiplier;
            m_CurrentPile = null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
