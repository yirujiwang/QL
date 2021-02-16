public abstract class Singleton<T> where T : new()
{
    private static T m_ins;
    public static T Ins
    {
        get
        {
            if (m_ins == null)
            {
                m_ins = new T();
            }
            return m_ins;
        }
    }
}