namespace SchemaValidation {
    public class SchemaValidationResult {
        public bool isValid;
        public string message;
        public static SchemaValidationResult validResultWithMessage(string message) {
            SchemaValidationResult result = new SchemaValidationResult();
            result.isValid = true;
            result.message = message;
            return result;
        }
        public static SchemaValidationResult invalidResultWithMessage(string message) {
            SchemaValidationResult result = new SchemaValidationResult();
            result.isValid = false;
            result.message = message;
            return result;
        }
    }
}