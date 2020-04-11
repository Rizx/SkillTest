using System;

namespace SkillTest.WebApplication
{
    public class Envelope<T>
    {
        public T Result { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime TimeGenerated { get; set; }
    }
}