using Xunit;
using Newtonsoft.Json;
using SchemaValidation;

namespace SchemaValidator_Tests{
    public class SchemaValidator_String_Tests {
        protected dynamic validator;
        public SchemaValidator_String_Tests() {
            this.validator = new JSONSchemaValidator();
        }
        [Fact]
        public void StringValidationTest() {
            dynamic schema = JsonConvert.DeserializeObject("{'type':'string'}");
            Assert.True(this.validator.validate("This is a string", schema).isValid);
            Assert.True(this.validator.validate("Déjà vu", schema).isValid);
            Assert.True(this.validator.validate("42", schema).isValid);
            Assert.False(this.validator.validate(42, schema).isValid);
        }
        [Fact]
        public void StringLengthValidation() {
            dynamic schema = JsonConvert.DeserializeObject("{'type':'string', 'minLength':2, 'maxLength': 3}");
            Assert.False(this.validator.validate("A", schema).isValid);
            // Assert.True(this.validator.validate("AB", schema).isValid);
            // Assert.True(this.validator.validate("ABC", schema).isValid);
            // Assert.False(this.validator.validate("ABCD", schema).isValid);
        }


    }
}
