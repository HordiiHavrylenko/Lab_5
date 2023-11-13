using Lab_5;

namespace TestProject1
{
    [TestClass]
    public class BasketballPlayerTest
    {
        [TestMethod]
        public void BasketballPlayerTest_Age_less_0()
        {
            //Arrange
            BasketballPlayer player = new BasketballPlayer();

            int age = -1;

            //Act + Assert
            Assert.ThrowsException<ArgumentException>(() => player.Age = age);
        }
        [TestMethod]
        public void BasketballPlayerTest_Age_more_99()
        {
            //Arrange
            BasketballPlayer player = new BasketballPlayer();

            int age = 100;

            //Act + Assert
            Assert.ThrowsException<ArgumentException>(() => player.Age = age);
        }

        [TestMethod]
        public void BasketballPlayerTest_Age_valid()
        {
            //Arrange
            BasketballPlayer player = new BasketballPlayer();
            int expectedAge = 25;

            //Act
            player.Age = expectedAge;

            //Assert

            Assert.AreEqual(expectedAge, player.Age);
        }

        [TestMethod]
        public void BasketballPlayerTest_Name_invalid()
        {
            //Arrange
            BasketballPlayer player = new BasketballPlayer();
            string name = "Jo";

            //Act+Assert
            Assert.ThrowsException<ArgumentException>(() => player.Name = name);
        }

        [TestMethod]
        public void BasketballPlayerTest_Name_valid()
        {
            //Arrange
            BasketballPlayer player = new BasketballPlayer();

            string name = "MichaelJordan";

            //Act
            player.Name = name;

            //Assert
            Assert.AreEqual(name, player.Name);
        }

        [TestMethod]
        public void BasketballPlayerTest_Height_invalid()
        {
            //Arrange
            BasketballPlayer player = new BasketballPlayer();
            double height = -100;

            //Act + Assert

            Assert.ThrowsException<ArgumentException>(() => player.Height = height);

        }

        [TestMethod]
        public void BasketballPlayerTest_Height_valid()
        {
            //Arrange
            BasketballPlayer player = new BasketballPlayer();
            double height = 200;

            //Act
            player.Height = height;

            //Assert

            Assert.AreEqual(height, player.Height);

        }

        [TestMethod]
        public void BasketballPlayerTest_Weight_invalid()
        {
            //Arrange
            BasketballPlayer player = new BasketballPlayer();
            double weight = -100;

            //Act + Assert

            Assert.ThrowsException<ArgumentException>(() => player.Weight = weight);

        }

        [TestMethod]
        public void BasketballPlayerTest_Weight_valid()
        {
            //Arrange
            BasketballPlayer player = new BasketballPlayer();
            double weight = 200;

            //Act
            player.Weight = weight;

            //Assert

            Assert.AreEqual(weight, player.Weight);

        }

        [TestMethod]

        public void Constructor_name_age_InitialisationCorrectly()
        {
            //Arrange
            string name = "James";
            int age = 23;

            //Act
            BasketballPlayer player = new(name, age);

            //Assert

            Assert.AreEqual(name, player.Name);
            Assert.AreEqual(age, player.Age);

        }

        [TestMethod]
        public void Constructor_Full_InitialisationCorrectly()
        {
            // Arrange
            string name = "LeBronJames";
            int age = 36;
            Position playerPosition = Position.PowerForward;
            double height = 2.06;
            double weight = 113.4;
            bool isInjured = false;
            int shirtNumber = 23;

            // Act
            BasketballPlayer player = new BasketballPlayer(name, age, playerPosition, height, weight, isInjured, shirtNumber);

            // Assert
            Assert.AreEqual(name, player.Name);
            Assert.AreEqual(age, player.Age);
            Assert.AreEqual(playerPosition, player.PlayerPosition);
            Assert.AreEqual(height, player.Height);
            Assert.AreEqual(weight, player.Weight);
            Assert.AreEqual(isInjured, player.IsInjured);
            Assert.AreEqual(shirtNumber, player.ShirtNumber);
        }

        [TestMethod]
        public void Constructor_name_age_InvalidName_ArgumentException()
        {

            //Arrange
            string invalidName = "Jo";
            int age = 23;

            //Act + Assert
            Assert.ThrowsException<ArgumentException>(() => new BasketballPlayer(invalidName, age));
        }

        [TestMethod]
        public void Constructor_name_age_InvalidAge_ArgumentException()
        {

            //Arrange
            string name = "Jordan";
            int invalidAge = -23;

            //Act + Assert
            Assert.ThrowsException<ArgumentException>(() => new BasketballPlayer(name, invalidAge));
        }

        [TestMethod]
        public void ToStringCorrectly()
        {
            // Arrange
            string name = "LeBronJames";
            int age = 36;
            Position playerPosition = Position.PowerForward;
            double height = 206;
            double weight = 113;
            bool isInjured = false;
            int shirtNumber = 23;
                       
            BasketballPlayer player = new BasketballPlayer(name, age, playerPosition, height, weight, isInjured, shirtNumber);

            // Act
            string result = player.ToString();

            //Assert
            string waiting = "Name: LeBronJames, Age: 36, Position: PowerForward, Height: 206, Weight: 113, IsInjured: False, ShirtNumber: 23";
            Assert.AreEqual(waiting, result);
        }


    }

}