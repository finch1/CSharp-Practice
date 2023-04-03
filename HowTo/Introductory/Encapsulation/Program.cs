namespace HelloWorld
{
    class Program
    {
        // ENCAPSULATION
        // Define fields as private
        // Provide get set methods as public
        // Classes are ment for behaviours, so we hide what ever doesn't need to show.

        static void Main(string[] args)
        {
            var student = new Student();
            student.birthdate = new DateTime(2019, 01, 25);
        }
    }

    class Student
    {
        // private to the class
        private DateTime _birthdate; //camel Case ( first letter is lowercase) and underscore = private

        public DateTime birthdate
        { 
            get{return _birthdate; }
            set{
                if(birthdate != null)
                    _birthdate = birthdate;
                } 
        }
        
    }
}