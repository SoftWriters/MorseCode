using System;
using System.Collections.Generic;
using Xunit;
using MorseCode;
using System.Linq;

namespace MorseCode.Tests {
	public class MorseTests {
		public static IEnumerable<object[]> MorseStringTestPairs() {
			return new Dictionary<string, string> {
				[
					"-..||---||--."
					] = "dog",//Multiple letters
				[
					"....||.||.-..||.-..||---||||.--||---||.-.||.-..||-.."
					] = "hello world",//Multiple words
				[
					""
					] = " ",//Empty
				[
					"||"
					] = "  ",//Single bordered break
				[
					"||||"
					] = "   ",//Multiple sequential breaks
			}.Select(pair => new object[] { pair.Key, pair.Value });
		}

		[Theory, MemberData(nameof(MorseStringTestPairs))]
		public void EncodeString(string cipherText, string plainText) {

			//Default separator should produce correct result
			Assert.Equal(cipherText, Morse.EncodeString(plainText));

			//Specified separator should produce correct result
			Assert.Equal(cipherText, Morse.EncodeString(plainText, "||"));

			//Specified bad separator should produce incorrect result until substituted if it isn't empty
			if (cipherText.Length > 0) {
				var badSeparator = "!!";
				var badResult = Morse.EncodeString(plainText, badSeparator);
				Assert.NotEqual(cipherText, badResult);
				Assert.Equal(cipherText, badResult.Replace(badSeparator, "||"));
			}
		}

		[Theory, MemberData(nameof(MorseStringTestPairs))]
		public void DecodeString(string cipherText, string plainText) {

			//Default separator should produce correct result
			Assert.Equal(plainText, Morse.DecodeString(cipherText));

			//Specified separator should produce correct result
			Assert.Equal(plainText, Morse.DecodeString(cipherText, "||"));

			//Specified bad separator should throw if the string is longer than 0 and
			//does not contain it or a single morse character
			{
				var badSeparator = "!!";
				if (cipherText.Length > 0 && !cipherText.Contains(badSeparator) && !Morse.MorseMapping.ContainsKey(cipherText)) {
					Assert.Throws<KeyNotFoundException>(() => {
						Morse.DecodeString(cipherText, "!!");
					});
				}
			}
		}

		public static IEnumerable<object[]> MorseCharacterTestPairs() {
			return Morse.MorseMapping.Select(pair => new object[] { pair.Key, pair.Value });
		}

		[Theory, MemberData(nameof(MorseCharacterTestPairs))]
		public void DecodeCharacters(string toDecode, char expectedResult) {
			Assert.Equal(expectedResult, Morse.DecodeCharacter(toDecode));
		}

		[Theory, MemberData(nameof(MorseCharacterTestPairs))]
		public void EncodeCharacters(string expectedResult, char toEncode) {
			Assert.Equal(expectedResult, Morse.EncodeCharacter(toEncode));
		}

		[Fact]
		public void EncodeBadCharacter() {
			var badChar = '^';
			Assert.DoesNotContain<char>(badChar, Morse.MorseInverseMapping.Keys);
			Assert.Throws<KeyNotFoundException>(() => {
				Morse.EncodeCharacter(badChar);
			});
		}

	}
}
