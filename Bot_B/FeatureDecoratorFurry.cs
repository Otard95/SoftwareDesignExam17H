﻿namespace Bot_B
{
    class FeatureDecoratorFurry : ItemDecorator{

    private Iitem _original_item;

    public FeatureDecoratorFurry(Iitem original_item)
    {
        _original_item = original_item;
    }

    public override string GetDesc()
    {
        return _original_item.GetDesc() + " Feature: With Super-duper soft Furry ";
    }

    public override string GetName()
    {
        return _original_item.GetName();

    }

    public override double GetPrice()
    {
        return _original_item.GetPrice() + 2.5;
    }
    }
}