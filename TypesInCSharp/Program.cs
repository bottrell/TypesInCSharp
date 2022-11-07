namespace TypesInCSharp {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello, world!");

            myClassName hello = new myClassName("Jordan");
            // To call the Deconstrctor, set a variable to eat the object
            var n = hello;

            // The C# discard symbol lets you discard variables
            myClassName mine = new myClassName("with discard operator");
            var _ = mine;


            myClassName test = new myClassName("asdf"){ InitSetter = "bleep bloop" };
        }
    }

    // Creating a class
    class myClassName {
        List<string> classModifiers = new List<string> {
            "public",
            "internal",
            "abstract",
            "sealed",
            "static",
            "unsafe",
            "partial"
        };

        string _myField = "This is a field";
        readonly string _myReadOnlyField = "This can't be modified after construction";

        // Declaring multiple variables in one statement
        static readonly int legs = 2,
                            arms = 2;

        // Const values must be declared;
        public const string Message = "Hello, World!";

        // An Expression - bodied method
        // => takes the place of the return and the braces
        int Double (int x) => (2 * x);

        // Expression-bodied functions can also have a void return type:
        void SaySomething (string something) => Console.WriteLine(something);

        // Types can overload methods, but they need to have differing signatures to avoid ambiguity
        void SaySomething () => Console.WriteLine("something");

        // Parameter reference also matters to the signatures. This is valid
        void SaySomething (ref string something) => Console.WriteLine(something);
        //   SaySomething (out string something) => Console.WriteLine(something); --- Invalid

        string _name;
        // -- Constructors -- //
        // can be public, internal, private, or protected
        public myClassName (string n, string Message) {
            _name = n;
        }
        // Can be written as expression-bodied members
        public myClassName (string n) => _name = n;

        public myClassName (string n, int x) : this (n) { x = Double(x); }


        // Properties are declared like fields but with a get/set block added
        public string Name {
            get {return _name; }
            set { _name = value; }
        }  // Properties give you full control of behavior when you read and write from a variable

        // There are a ton of different property modifiers e.g. static, public, internal, private, etc.

        // Example of an expression-bodied computed readonly property
        public string myName => _name + "is my name!";

        // Set expressions can also be expression-bodied
        public string sayMyName {
            get => _name + " is my name!";
            set => _name = value;
        }

        // automatic properties 
        public string FullName {get; set;} = "Jordan" + "Bottrell";

        public string InitSetter {get; init;} = "asdf";
        // These can be set via an initializer
        // var test = new myTestClass {initSetter = "fdsa"}

        // -- Deconstructors -- approximate opposite to a constructor
        // must be called Deconstruct and must have out parameters
        public void Deconstruct(out string n) {
            n = _name;
        }

    }
}