// https://www.youtube.com/watch?v=dhnsegiPXoo&list=PLLWMQd6PeGY3ob0Ga6vn1czFZfW6e-FLr&index=1

namespace DryDemoLibraryTest
{
    public class EmployeeProcessorTest
    {
        [Theory]
        // install xunit. Tests with real data. 
        [InlineData("Jake", "Willow", "JakWil")]
        public void GenerateemplyeeID(string firstName, string lastName, string expectedStart)
        {
            // Arrange
            EmployeeProcessor processor = new EmployeeProcessor();

            // Act
            string actualStart = processor.GenerateEmplyeeID(firstName, lastName);

            // Assert    
            Assert.Equal(expectedStart, actualStart);
        }
    }

    public class EmployeeProcessor
    {
        public string GenerateEmplyeeID(string firstName, string lastName)
        {
            return firstName.Substring(GetPartOfName(firstName),3)+lastName.Substring(GetPartOfName(lastName),3);
        }

        // prevention for names or surnames less then number of characters required
        private string GetPartOfName(string name, int characters)
        {
            if(name.Length >= characters)
                return name.Substring(0,characters);
        }
    }
}