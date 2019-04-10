﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using WebDataReader.Domain;
using WebDataReader.Domain.ValueObjects.Transform;
using Xunit;

namespace WebDataReader.DomainTest
{
  public class TransformTemplateTest
  {
    [Fact]
    public void TransfornLine_SimpleTest()
    {
      string template = "public {{Type}} {{Name}} { get; set; }";
      var result = new TransformTemplate().TransformLine(template, new ColumnMetadata() { ColumnName  = "Nombre", DataType = "String"});
      result.Should().Be(@"public String Nombre { get; set; }");
    }

    [Fact]
    public void Nullable_String_TransfornLine_SimpleTest()
    {
      string template = "public {{Type}} {{Name}} { get; set; }";
      var result = new TransformTemplate().TransformLine(template, new ColumnMetadata() { ColumnName = "Nombre", DataType = "String", AllowDbNull = true});
      result.Should().Be(@"public String Nombre { get; set; }");
    }
    [Fact]
    public void Nullable_int_TransfornLine_SimpleTest()
    {
      string template = "public {{Type}} {{Name}} { get; set; }";
      var result = new TransformTemplate().TransformLine(template, new ColumnMetadata() { ColumnName = "Nombre", DataType = "int", AllowDbNull = true });
      result.Should().Be(@"public int? Nombre { get; set; }");
    }

    [Fact]
    public void TransfornMultiple_SimpleTest()
    {
      string template = "public {{Type}} {{Name}} { get; set; }";
      var result = new TransformTemplate().Transform(template, new List<ColumnMetadata>() {
        new ColumnMetadata() { ColumnName  = "Nombre", DataType =  "string"},
        new ColumnMetadata() { ColumnName = "Cantidad", DataType =  "int"}
        }
      );
      result.Should().Be(@"public string Nombre { get; set; }
public int Cantidad { get; set; }
");
    }
  }
}
