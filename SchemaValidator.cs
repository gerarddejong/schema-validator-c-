namespace SchemaValidation {
    interface SchemaValidator {
        SchemaValidationResult validate(object unvalidated, dynamic schema);
    }
}