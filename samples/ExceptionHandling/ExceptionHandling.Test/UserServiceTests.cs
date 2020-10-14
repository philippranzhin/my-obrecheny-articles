using System;
using ExceptionHandlingSamples.Classic;
using ExceptionHandlingSamples.Model;
using Maybe;
using MaybeService = ExceptionHandlingSamples.Maybe.UserService;
using ClassicService = ExceptionHandlingSamples.Classic.UserService;
using SomeOrDefaultService = ExceptionHandlingSamples.SomeOrDefault.UserService;
using TryPatternService = ExceptionHandlingSamples.TryPattern.UserService;
using NUnit.Framework;

namespace ExceptionHandling.Test
{
    public class Tests {
        private const string ExistingId = "0";
        private const string NotExistingId = "1";
        
        [Test]
        public void MaybeShouldFind() {
            var service = new MaybeService();

            var result = service.GetUser(ExistingId);

            switch (result) {
                case Failure<User> failure:
                    Assert.Fail();
                    break;
                case Success<User> success:
                    Assert.Pass();
                    break;
            }
        }
        
        [Test]
        public void MaybeShouldNotFind() {
            var service = new MaybeService();

            var result = service.GetUser(NotExistingId);

            switch (result) {
                case Failure<User> failure:
                    Assert.Pass();
                    break;
                case Success<User> success:
                    Assert.Fail();
                    break;
            }
        }
        
        [Test]
        public void ClassicShouldFind() {
            var service = new ClassicService();

            try {
                var user = service.GetUser(ExistingId);
                Assert.Pass();
            }
            catch (UserNotFoundException e) {
                Assert.Fail();
            }
        }
        
        [Test]
        public void ClassicShouldNotFind() {
            var service = new ClassicService();

            try {
                var user = service.GetUser(NotExistingId);
                Assert.Fail();
            }
            catch (UserNotFoundException e) {
                Assert.Pass();
            }
        }
               
        [Test]
        public void SomeOrDefaultShouldFind() {
            var service = new SomeOrDefaultService();

            var user = service.GetUserOrDefault(ExistingId);

            if (user != null) {
                Assert.Pass();
            }

            if (user == null) {
                Assert.Fail();
            }
        }
        
        [Test]
        public void SomeOrDefaultShouldNotFind() {
            var service = new SomeOrDefaultService();

            var user = service.GetUserOrDefault(NotExistingId);

            if (user != null) {
                Assert.Fail();
            }

            if (user == null) {
                Assert.Pass();
            }
        }
        
        [Test]
        public void TryPatternShouldFind() {
            var service = new TryPatternService();

            if (service.TryGetUser(ExistingId, out var user)) {
                Assert.Pass();
            }
            
            Assert.Fail();
        }
        
        [Test]
        public void TryPatternShouldNotFind() {
            var service = new TryPatternService();

            if (service.TryGetUser(NotExistingId, out var user)) {
                Assert.Fail();
            }
            
            Assert.Pass();
        }
    }
}