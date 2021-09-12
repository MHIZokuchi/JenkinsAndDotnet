using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netCoreMVCCRUD
{
    public class Tests
    {
        public interface ITestRepository
        {
            List<string> GetNames();
        }

        public class TestRepository : ITestRepository
        {
            public List<string> GetNames()
            {
                return new List<string>
        {
            "John",
            "Bob",
            "Wade"
        };
            }
        }

        public interface ITestService
        {
            List<string> GetNamesExceptJohn();
        }

        public class TestService : ITestService
        {
            private List<string> repo;

            public TestService()
            {
                repo = new List<string> { "John", "Bob", "Wade" };
            }

            public List<string> GetNamesExceptJohn()
            {
                return repo.Where(x => !x.Equals("john", StringComparison.CurrentCultureIgnoreCase)).ToList();
            }          
        }

        public interface IUtilityService
        {
            bool IsPalindrome(string word);
        }

        public class UtilityService : IUtilityService
        {
            public bool IsPalindrome(string word)
            {
                return word == string.Join(string.Empty, word.ToCharArray().Reverse());
            }
        }


    }
    
}
