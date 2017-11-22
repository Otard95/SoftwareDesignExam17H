namespace Bot_B
{
    class FeatureDecoratorFurry : ItemDecorator{

    private Iitem _original_item;

    public FeatureDecoratorFurry(Iitem original_item)
    {
        _original_item = original_item;
    }

    public override string GetDesc()
    {
        string seperator = "";
        if (!_original_item.GetDesc().EndsWith(" "))
        {
            seperator = " and ";
        }
        return _original_item.GetDesc() + seperator+ "with Super-duper soft furry";
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