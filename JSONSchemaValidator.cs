using System;

namespace SchemaValidation {
    public class JSONSchemaValidator : SchemaValidator {
        public SchemaValidationResult validate(object unvalidated, dynamic schema) {
            if(unvalidated is string) {
                return this.validateString((string)unvalidated, schema);             
            }
            return SchemaValidationResult.invalidResultWithMessage("Invalid object! Object type cannot be validated with schema.");
        }

        public SchemaValidationResult validateString(string stringToValidate, dynamic schema) {
            Console.WriteLine(schema.GetType().GetProperty("type") );
                
            if(schema.GetType().GetProperty("type") != null && ((string)schema.type).Equals("string", StringComparison.Ordinal)) {
                
                Console.WriteLine(schema.minLength);
                if(schema.GetType().GetProperty("minLength") != null && stringToValidate.Length < (int)schema.minLength) {
                    return SchemaValidationResult.invalidResultWithMessage("Too short!");
                }
                if(schema.GetType().GetProperty("maxLength") != null && stringToValidate.Length > (int)schema.maxLength) {
                    return SchemaValidationResult.invalidResultWithMessage("Too long!");
                }

                return SchemaValidationResult.validResultWithMessage("Okay!");
            }
            return SchemaValidationResult.invalidResultWithMessage("Invalid string! Type not defined in string schema.");
        }   
    }
}