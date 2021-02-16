using System.Collections.Generic;

public enum GuideConditionType
{

}

public interface IGuideCondition
{
    GuideConditionType conditionType { get; set; }
    object conditionParam { get; set; }

    bool Check();
}

public abstract class GuideConditionBase : IGuideCondition
{
    private GuideConditionType m_conditionType;
    private object m_conditionParam;
    public GuideConditionType conditionType { get => m_conditionType; set => m_conditionType = value; }
    public object conditionParam { get => m_conditionParam; set => m_conditionParam = value; }

    public abstract bool Check();
}

public interface IGuide
{
    int guideId { get; set; }
    List<GuideConditionBase> conditions { get; set; }

    bool Check();
    void Show();
}

public abstract class GuideBase : IGuide
{
    private int m_guideId;
    private List<GuideConditionBase> m_conditions;

    public int guideId { get => m_guideId; set => m_guideId = value; }
    public List<GuideConditionBase> conditions { get => m_conditions; set => m_conditions = value; }

    public virtual bool Check()
    {
        if(conditions == null)
        {
            return false;
        }

        foreach (GuideConditionBase condition in conditions)
        {
            if(!condition.Check())
            {
                return false;
            }
        }

        return true;
    }

    public virtual void Show()
    {

    }
}