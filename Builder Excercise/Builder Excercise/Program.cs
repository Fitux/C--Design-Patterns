using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Excercise
{
    public class CodeClass
    {
        public string ClassName;
        public List<Tuple<string, string>> ClassFields = new List<Tuple<string, string>>();

        public CodeClass(string className)
        {
            ClassName = className ?? throw new ArgumentNullException();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"public class {ClassName}");
            sb.AppendLine("{");

            foreach (var field in ClassFields)
            {
                sb.AppendLine($"  public {field.Item2} {field.Item1};");
            }

            sb.AppendLine("}");

            return sb.ToString();
        }
    }

    public class CodeBuilder
    {
        private readonly string ClassName;
        protected CodeClass BaseCodeClass;

        public CodeBuilder(string className)
        {
            ClassName = className ?? throw new ArgumentNullException();
            BaseCodeClass = new CodeClass(className);
        }

        public CodeBuilder AddField(string fieldName, string fieldType)
        {
            BaseCodeClass.ClassFields.Add(new Tuple<string,string>(fieldName, fieldType));
            return this;
        }

        public override string ToString()
        {
            return BaseCodeClass.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
            Console.WriteLine(cb);
        }
    }
}
