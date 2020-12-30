using Newtonsoft.Json;

namespace Quest_Project.Models
{
    /// <summary>
    /// This model is used to persist the requested multiply operation and its result.
    ///
    /// The <see cref="JsonPropertyAttribute"/> usage it to make the serialized documents use
    /// typical JSON camelCase naming.  There may be a way to make this happen automatically.
    /// </summary>
    public class MathMultiplyOperationModel
    {
        /// <summary>
        /// the ID for this operation
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// the first number we're multiplying
        /// </summary>
        [JsonProperty("multiplicand")]
        public double Multiplicand { get; set; }

        /// <summary>
        /// the second number we're multiplying
        /// </summary>
        [JsonProperty("multiplier")]
        public double Multiplier { get; set; }

        /// <summary>
        /// The result of the operation.
        /// this gets set after the "Perform" Function gets called
        /// </summary>
        [JsonProperty("result")]
        public double? Result { get; set; }
    }
}
