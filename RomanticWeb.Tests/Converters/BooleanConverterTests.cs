﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
using RomanticWeb.Converters;
using RomanticWeb.Vocabularies;

namespace RomanticWeb.Tests.Converters
{
    public class BooleanConverterTests : XsdConverterTestsBase<BooleanConverter>
    {
        protected override IEnumerable<Uri> SupportedXsdTypes
        {
            get
            {
                yield return Xsd.Boolean;
            }
        }

        [TestCase("true", true)]
        [TestCase("false", false)]
        [TestCase("1", true)]
        [TestCase("0", false)]
        public void Should_convert_valid_booleans(string literal, bool expected)
        {
            Assert.That(Converter.Convert(Node.ForLiteral(literal)), Is.EqualTo(expected));
        }
    }
}