namespace SynetecAssessmentApi.Bl.Constants
{
    public class ResultMessages
    {
        public class Base
        {
            public const string Ok = "All good.";
            public const string BadRequest = "Bad request.";
        }

        public class Employee : Base
        {
            public const string NotFound = "Employee has not been found.";
        }
    }
}
