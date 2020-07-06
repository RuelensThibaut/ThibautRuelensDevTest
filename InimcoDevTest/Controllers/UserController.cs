using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Business_Layer.Interfaces;
using InimcoDevTest.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InimcoDevTest.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {

        public List<User> users;
        private readonly ITextAnalyserService textAnalyserService;

        public UserController(ITextAnalyserService textAnalyserService)
        {
            this.textAnalyserService = textAnalyserService;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return this.users;
        }

        [HttpPost]
        public UserResultObject AnalyseUserData([FromBody] User user)
        {
            try
            {
                var userResultObject = new UserResultObject();
                //This is not necessary but for perfomance this can be a big advantage if we were appending more than 1 time the string itself
                StringBuilder firstAndLastName = new StringBuilder();
                firstAndLastName.Append(user.FirstName);
                firstAndLastName.Append(" ");
                firstAndLastName.Append(user.LastName);
                userResultObject.firstAndLastName = firstAndLastName.ToString();
                //returns the amount of vowels in the string
                userResultObject.amountOfVowels = this.textAnalyserService.calculateAmountOfVowels(firstAndLastName.ToString());

                //returns the amount of constenants in the string
                userResultObject.amountOfConstenants = this.textAnalyserService.calculateAmountOfConstenants(firstAndLastName.ToString());

                //returns the amount of vowels in the string
                userResultObject.reversedFirstAndLastName = this.textAnalyserService.reverseString(firstAndLastName.ToString());

                userResultObject.jsonString = JsonConvert.SerializeObject(user);
                return userResultObject;
            }
            catch (Exception e)
            { 
                throw e; 
            }
        }
    }
}

