using System;
using System.Collections.Generic;


//红点提示类型
public enum PromptType
{

}

public interface IPrompt
{
    int GetCount();
}

public abstract class PromptBase : IPrompt
{
    public abstract int GetCount();
}



//红点模块
public partial class PromptModule : Singleton<PromptModule>
{
    private static Dictionary<PromptType, Func<object, PromptBase>> m_promptFuncDict = new Dictionary<PromptType, Func<object, PromptBase>>();

}
