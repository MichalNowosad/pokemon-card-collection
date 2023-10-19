using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCardCollection.Application.Constants
{
    public static class ValidationConstants
    {
        public const string ValueEmptyErrorMessage = "{PropertyName} is required.";
        public const string MaxLengthErrorMessage = "{PropertyName} must not exceed {MaxLength} characters.";
        public const string FileNotUploadedErrorMessage = "There was no file uploaded.";
    }
}
