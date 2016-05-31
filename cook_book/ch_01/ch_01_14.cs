using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//类函数的申明和实现分开
namespace cook_book.ch_01
{
    class ch_01_14
    {
        public static void Test()
        {
            Console.WriteLine("Start entity work");
            GeneratedEntity entity = new GeneratedEntity("FirstEntity");
            entity.FirstName = "Bob";
            entity.State = "NH";

            GeneratedEntity secondEntity = new GeneratedEntity("SecondEntity");
            secondEntity.FirstName = "Jay";
            secondEntity.State = "MA";
            entity.FirstName = "Barry";
        }
    }

    public partial class GeneratedEntity
    {
        public GeneratedEntity(string entityName)
        {
            this.EntityName = entityName;
        }

        partial void ChangingProperty(string name, string originalValue, string newValue);

        public string EntityName { get; }
        private string _FirstName;

        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                ChangingProperty("FirstName", _FirstName, value);
                _FirstName = value;
            }
        }

        private string _State;

        public string State
        {
            get { return _State; }
            set
            {
                ChangingProperty("State", _State, value);
                _State = value;
            }
        }
    }

    public partial class GeneratedEntity
    {
        partial void ChangingProperty(string name, string originalValue, string newValue)
        {
            Console.WriteLine($"Changed property ({name}) for entity " +
                              $"{this.EntityName} from " +
                              $"{originalValue} to {newValue}");
        }
    }
}