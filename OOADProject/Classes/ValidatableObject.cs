using System;
using System.Collections.Generic;
using System.Linq;

namespace OOADProject
{
    public class ValidatableObject<T>
    {
        public ValidatableObject()
        {

            _validations = new List<IValidationRule<T>>();

            Errors = new List<string>();

            IsValid = false;
        }

        

        private List<IValidationRule<T>> _validations; //Change IVal.. to Val?

        public List<IValidationRule<T>> Validations; //Change IVal.. to Val?

        public List<string> Errors; //Make this an empty list?? or IEnumerable?

        public bool IsValid;

        public T Value; //String

        public bool Validate()
        {
            Errors.Clear();

            IEnumerable<string> errors = _validations
                .Where(v => !v.Check(Value))
                .Select(v => v.ValidationMessage);

            Errors = errors.ToList();
            IsValid = !Errors.Any();

            return this.IsValid;
        }


    }


}
