using NUnit.Framework;
using QAWorkshop;

namespace Tests
{
    [TestFixture]
    public class ProductCodeValidatorTest
    {
        [Test]
        public void it_validates_the_length()
        {
            ProductCodeValidator productCodeValidator = new ProductCodeValidator();
            Assert.False(productCodeValidator.Validate("BBB45678"));
            Assert.True(productCodeValidator.Validate("AAA456789"));
            Assert.False(productCodeValidator.Validate("ABC4567890"));
        }
        
        [Test]
        public void it_can_check_for_beginning_with_three_uppercase_letters()
        {
            ProductCodeValidator productCodeValidator = new ProductCodeValidator();
            Assert.False(productCodeValidator.Validate("123456789"));
            Assert.True(productCodeValidator.Validate("HEY456789"));
            Assert.False(productCodeValidator.Validate("hey456789"));
        }

        [Test]
        public void it_accepts_codes_with_one_dash()
        {
            ProductCodeValidator productCodeValidator = new ProductCodeValidator();
            Assert.True(productCodeValidator.Validate("MEK1234-5"));
            Assert.True(productCodeValidator.Validate("MEK-12345"));
            // maybe you'd want to exclude this case as it doesn't make much sense
            Assert.True(productCodeValidator.Validate("MEK12345-"));
        }
    }
}