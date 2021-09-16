using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExercises
{
    public class Student : Person
    {
        public Student(
            string firstName,
            string lastName,
            DateTime dateOfBirth,
            Gender gender,
            string universityName)
            : base(firstName, lastName, dateOfBirth, gender)
        {
            this.UniversityName = universityName ?? throw new ArgumentNullException(nameof(universityName));
        }

        public string UniversityName { get; }
    }
}
