// This code was generated by Hypar.
// Edits to this code will be overwritten the next time you run 'hypar init'.
// DO NOT EDIT THIS FILE.

using Elements;
using Elements.GeoJSON;
using Elements.Geometry;
using Elements.Geometry.Solids;
using Elements.Validators;
using Elements.Serialization.JSON;
using Hypar.Functions;
using Hypar.Functions.Execution;
using Hypar.Functions.Execution.AWS;
using System;
using System.Collections.Generic;
using System.Linq;
using Line = Elements.Geometry.Line;
using Polygon = Elements.Geometry.Polygon;

namespace GridInputs
{
    #pragma warning disable // Disable all warnings

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v12.0.0.0)")]
    
    public  class GridInputsInputs : S3Args
    
    {
        [Newtonsoft.Json.JsonConstructor]
        
        public GridInputsInputs(Grid2dInput @grid2d, Grid1dInput @grid1d, Grid1dInput @otherGrid, Grid1dInput @grid1dWithNoDefault, Overrides @overrides, string bucketName, string uploadsBucket, Dictionary<string, string> modelInputKeys, string gltfKey, string elementsKey, string ifcKey):
        base(bucketName, uploadsBucket, modelInputKeys, gltfKey, elementsKey, ifcKey)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<GridInputsInputs>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @grid2d, @grid1d, @otherGrid, @grid1dWithNoDefault, @overrides});
            }
        
            this.Grid2d = @grid2d;
            this.Grid1d = @grid1d;
            this.OtherGrid = @otherGrid;
            this.Grid1dWithNoDefault = @grid1dWithNoDefault;
            this.Overrides = @overrides;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("Grid 2d", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Grid2dInput Grid2d { get; set; }
    
        [Newtonsoft.Json.JsonProperty("Grid 1d", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Grid1dInput Grid1d { get; set; }
    
        [Newtonsoft.Json.JsonProperty("Other Grid", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Grid1dInput OtherGrid { get; set; }
    
        [Newtonsoft.Json.JsonProperty("Grid 1d with no default", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Grid1dInput Grid1dWithNoDefault { get; set; }
    
        [Newtonsoft.Json.JsonProperty("overrides", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Overrides Overrides { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v12.0.0.0)")]
    public enum Grid1dInputSubdivisionMode
    {
        [System.Runtime.Serialization.EnumMember(Value = @"Manual")]
        Manual = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Divide by count")]
        Divide_by_count = 1,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Divide by approximate length")]
        Divide_by_approximate_length = 2,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Divide by fixed length")]
        Divide_by_fixed_length = 3,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Divide by pattern")]
        Divide_by_pattern = 4,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v12.0.0.0)")]
    
    public partial class SubdivisionSettings 
    
    {
        [Newtonsoft.Json.JsonConstructor]
        public SubdivisionSettings(int @count, double @targetLength, double @length, SubdivisionSettingsRemainderMode @remainderMode, SubdivisionSettingsCycleMode @cycleMode)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<SubdivisionSettings>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @count, @targetLength, @length, @remainderMode, @cycleMode});
            }
        
            this.Count = @count;
            this.TargetLength = @targetLength;
            this.Length = @length;
            this.RemainderMode = @remainderMode;
            this.CycleMode = @cycleMode;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("Count", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Count { get; set; } = 1;
    
        [Newtonsoft.Json.JsonProperty("Target Length", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double TargetLength { get; set; } = 1D;
    
        [Newtonsoft.Json.JsonProperty("Length", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double Length { get; set; } = 1D;
    
        [Newtonsoft.Json.JsonProperty("Remainder Mode", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public SubdivisionSettingsRemainderMode RemainderMode { get; set; } = SubdivisionSettingsRemainderMode.Remainder_at_both_ends;
    
        [Newtonsoft.Json.JsonProperty("Cycle Mode", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public SubdivisionSettingsCycleMode CycleMode { get; set; } = SubdivisionSettingsCycleMode.Cycle;
    
        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();
    
        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v12.0.0.0)")]
    
    public partial class Overrides 
    
    {
        [Newtonsoft.Json.JsonConstructor]
        public Overrides(IList<GridsOverride> @grids, IList<DGridsOverride> @dGrids)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<Overrides>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @grids, @dGrids});
            }
        
            this.Grids = @grids;
            this.DGrids = @dGrids;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("Grids", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public IList<GridsOverride> Grids { get; set; }
    
        [Newtonsoft.Json.JsonProperty("2d Grids", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public IList<DGridsOverride> DGrids { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v12.0.0.0)")]
    public enum SubdivisionSettingsRemainderMode
    {
        [System.Runtime.Serialization.EnumMember(Value = @"Remainder at end")]
        Remainder_at_end = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Remainder at start")]
        Remainder_at_start = 1,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Remainder at both ends")]
        Remainder_at_both_ends = 2,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v12.0.0.0)")]
    public enum SubdivisionSettingsCycleMode
    {
        [System.Runtime.Serialization.EnumMember(Value = @"Repeat Last")]
        Repeat_Last = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Cycle")]
        Cycle = 1,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Wrap")]
        Wrap = 2,
    
        [System.Runtime.Serialization.EnumMember(Value = @"None")]
        None = 3,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v12.0.0.0)")]
    
    public partial class GridsOverride 
    
    {
        [Newtonsoft.Json.JsonConstructor]
        public GridsOverride(string @id, GridsIdentity @identity, GridsValue @value)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<GridsOverride>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @id, @identity, @value});
            }
        
            this.Id = @id;
            this.Identity = @identity;
            this.Value = @value;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("Identity", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public GridsIdentity Identity { get; set; }
    
        [Newtonsoft.Json.JsonProperty("Value", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public GridsValue Value { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v12.0.0.0)")]
    
    public partial class DGridsOverride 
    
    {
        [Newtonsoft.Json.JsonConstructor]
        public DGridsOverride(string @id, DGridsIdentity @identity, DGridsValue @value)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<DGridsOverride>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @id, @identity, @value});
            }
        
            this.Id = @id;
            this.Identity = @identity;
            this.Value = @value;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("Identity", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DGridsIdentity Identity { get; set; }
    
        [Newtonsoft.Json.JsonProperty("Value", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DGridsValue Value { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v12.0.0.0)")]
    
    public partial class GridsIdentity 
    
    {
        [Newtonsoft.Json.JsonConstructor]
        public GridsIdentity(Vector3 @roughPosition)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<GridsIdentity>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @roughPosition});
            }
        
            this.RoughPosition = @roughPosition;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("RoughPosition", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Vector3 RoughPosition { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v12.0.0.0)")]
    
    public partial class GridsValue 
    
    {
        [Newtonsoft.Json.JsonConstructor]
        public GridsValue(Grid1dInput @grid)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<GridsValue>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @grid});
            }
        
            this.Grid = @grid;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("Grid", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Grid1dInput Grid { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v12.0.0.0)")]
    
    public partial class DGridsIdentity 
    
    {
        [Newtonsoft.Json.JsonConstructor]
        public DGridsIdentity(Vector3 @roughPosition)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<DGridsIdentity>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @roughPosition});
            }
        
            this.RoughPosition = @roughPosition;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("RoughPosition", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Vector3 RoughPosition { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v12.0.0.0)")]
    
    public partial class DGridsValue 
    
    {
        [Newtonsoft.Json.JsonConstructor]
        public DGridsValue(Grid2dInput @grid)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<DGridsValue>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @grid});
            }
        
            this.Grid = @grid;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("Grid", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Grid2dInput Grid { get; set; }
    
    
    }
}