using Microsoft.AspNet.Identity;
using Moq;
using NUnit.Framework;
using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.Domain.Services.AuthenticationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.Domain.Tests.Services.AuthenticationServices
{
    [TestFixture]
    public class AuthenticationServiceTest
    {
        private AuthenticationService _authenticationService;
        private Mock<IAccountService> _mockAccountService;
        private Mock<IPasswordHasher> _mockPasswordHasher;

        [SetUp]
        public void Setup()
        {
            _mockAccountService = new Mock<IAccountService>();
            _mockPasswordHasher = new Mock<IPasswordHasher>();
            _authenticationService = new AuthenticationService(_mockAccountService.Object, _mockPasswordHasher.Object);
        }

        [Test]
        public async Task Login_WithTheCorrectPasswordForExistingUserName_ReturnsAccountForCorrectUserName()
        {
            string expectedUserName = "user1";
            string password = "password";
            _mockAccountService.Setup(s => s.GetByUserName(expectedUserName)).ReturnsAsync(new Account { AccountHolder = new User { UserName = expectedUserName } });
            _mockPasswordHasher.Setup(s => s.VerifyHashedPassword(It.IsAny<string>(), password)).Returns(PasswordVerificationResult.Success);

            Account account = await _authenticationService.Login(expectedUserName, password);

            string actualName = account.AccountHolder.UserName;
            Assert.AreEqual(expectedUserName, actualName);
        }

        [Test]
        public void Login_WithTheIncorrectPasswordForExistingUserName_ThrowsInvalidPasswordException()
        {
            string expectedUserName = "user1";
            string password = "password";
            _mockAccountService.Setup(s => s.GetByUserName(expectedUserName)).ReturnsAsync(new Account { AccountHolder = new User { UserName = expectedUserName } });
            _mockPasswordHasher.Setup(s => s.VerifyHashedPassword(It.IsAny<string>(), password)).Returns(PasswordVerificationResult.Failed);

            InvalidPasswordException ex = Assert.ThrowsAsync<InvalidPasswordException>(() => _authenticationService.Login(expectedUserName, password));

            string actualName = ex.UserName;
            Assert.AreEqual(expectedUserName, actualName);
        }

        [Test]
        public void Login_WithNonExistingUserName_ThrowsUserNotFoundException()
        {
            string expectedUserName = "user1";
            string password = "password";
            _mockPasswordHasher.Setup(s => s.VerifyHashedPassword(It.IsAny<string>(), password)).Returns(PasswordVerificationResult.Failed);

            UserNotFoundException ex = Assert.ThrowsAsync<UserNotFoundException>(() => _authenticationService.Login(expectedUserName, password));

            string actualName = ex.UserName;
            Assert.AreEqual(expectedUserName, actualName);
        }


    }
}