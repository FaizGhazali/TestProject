using FrontEnd.MVVM.Model;
using FrontEnd.MVVM.Services;
using Moq;

[TestFixture]
public class UserServiceTests
{
    private Mock<IUserRepository> _mockUserRepository;
    private UserService _userService;
    private List<User> _usersList; // Persistent list of users

    [SetUp]
    public void Setup()
    {
        _mockUserRepository = new Mock<IUserRepository>();
        _usersList = new List<User>
        {
            new User { Id = 1, Name = "Kamjat Ko" }  // Existing user
        };

        // Initial setup for GetUserById to return a user
        _mockUserRepository.Setup(repo => repo.GetUserById(It.IsAny<int>()))
          .Returns((int id) => _usersList.FirstOrDefault(u => u.Id == id));

        // Set up AddUser to add to the in-memory list of users
        _mockUserRepository.Setup(repo => repo.AddUser(It.IsAny<User>()))
           .Callback<User>((user) => _usersList.Add(user));  // Add user to the list

        _userService = new UserService(_mockUserRepository.Object);
    }

    [Test]
    public void UserService_should_return_correct_user()
    {
        // Act
        var user = _userService.GetUserById(1);

        // Assert
        Assert.That(user, Is.Not.Null);
        Assert.That(1, Is.EqualTo(user.Id));
        Assert.That("Kamjat Ko", Is.EqualTo(user.Name));
    }

    [Test]
    public void UserService_should_return_null_when_user_not_found()
    {
        // Act
        var user = _userService.GetUserById(2);

        // Assert
        Assert.That(user, Is.Null);
    }

    [Test]
    public void UserService_should_return_newly_created_user()
    {
        // Arrange
        User newUser = new User { Id = 999999, Name = "Faiz" };

        // Act
        _userService.AddUser(newUser);

        // Simulate fetching the newly added user
        _mockUserRepository.Setup(repo => repo.GetUserById(newUser.Id))
            .Returns(newUser);

        var user = _userService.GetUserById(newUser.Id);

        // Assert
        Assert.That(user, Is.Not.Null);
        Assert.That(user.Name, Is.EqualTo("Faiz"));
    }
}
