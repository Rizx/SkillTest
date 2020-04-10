namespace SkillTest.Core
{
    public interface IConnectionStings
    {
        string Value {get;}
    }
    public class ConnectionStrings
    {
        public string Value {get;}
        public ConnectionStrings(string value)
        {
            Value = value;
        }
    }
}